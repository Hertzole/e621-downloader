using FolderSelect;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace E621MassDownloader
{
    public partial class Form1 : Form
    {
        private bool downloading = false;
        private bool cancelDownload = false;
        private const string NOT_DOWNLOADING_TEXT = "Not downloading anything";

        public Form1()
        {
            InitializeComponent();
            downloadDestBox.TextChanged += ValidateDownloadDestination;
            downloadDestBox.Text = Prefs.Default.DownloadDestination;
            searchTagsBox.Text = Prefs.Default.Search;
            animatedCheckBox.Checked = Prefs.Default.Animated;
            downloadAmountBar.ValueChanged += DownloadAmountBar_ValueChanged;
            downloadAmountBar.Value = Prefs.Default.Amount;
            downloadProgressBar.Value = 0;
            startDownloadButton.Enabled = !string.IsNullOrWhiteSpace(downloadDestBox.Text);
            downloadAmountLabel.Text = "Amount - " + downloadAmountBar.Value.ToString();
            downloadingLabel.Text = NOT_DOWNLOADING_TEXT;
            cancelDownloadButton.Enabled = false;
        }

        private void DownloadAmountBar_ValueChanged(object sender, EventArgs e)
        {
            downloadAmountLabel.Text = "Amount - " + downloadAmountBar.Value.ToString();
        }

        private void ValidateDownloadDestination(object sender, EventArgs e)
        {
            startDownloadButton.Enabled = !string.IsNullOrWhiteSpace(downloadDestBox.Text);
        }

        private void browseDownloadDestButton_Click(object sender, EventArgs e)
        {
            FolderSelectDialog dialog = new FolderSelectDialog()
            {
                Title = "Select download destination"
            };
            if (dialog.ShowDialog())
            {
                downloadDestBox.Text = dialog.FileName;
            }
        }

        void SavePrefs()
        {
            Prefs.Default.DownloadDestination = downloadDestBox.Text;
            Prefs.Default.Animated = animatedCheckBox.Checked;
            Prefs.Default.Search = searchTagsBox.Text;
            Prefs.Default.Amount = downloadAmountBar.Value;
            Prefs.Default.Save();
        }

        private async void startDownloadButton_Click(object sender, EventArgs e)
        {
            SavePrefs();
            startDownloadButton.Enabled = false;

            cancelDownload = false;

            if (!Directory.Exists(downloadDestBox.Text))
            {
                MessageBox.Show("The download destination does not exist!", "Problem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tags = searchTagsBox.Text.Trim();
            string[] tagsArray = string.IsNullOrEmpty(tags) ? new string[0] : tags.Split(' ');
            if (tagsArray.Length > 4)
            {
                MessageBox.Show("You can only search with a maximum of 4 tags!", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                using (var http = new HttpClient())
                {
                    http.DefaultRequestHeaders.Clear();
                    http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1");
                    http.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

                    StringBuilder linkBuilder = new StringBuilder();
                    linkBuilder.Append("https://e621.net/post/index.xml?tags=rating%3Ae%20");
                    if (!animatedCheckBox.Checked)
                        linkBuilder.Append("type%3Apng%20");
                    else
                        linkBuilder.Append("type%3Agif%20");

                    tags = tags.Replace(" ", "%20");

                    linkBuilder.Append(tags).Append($"%20order:random&limit={downloadAmountBar.Value}");
                    //string json = await GetJson(linkBuilder.ToString());
                    //JArray array = JArray.Parse(json);
                    Clipboard.SetText(linkBuilder.ToString());
                    var data = await http.GetStreamAsync(linkBuilder.ToString());
                    var doc = XDocument.Load(data);
                    int amount = doc.Descendants("posts").Nodes().ToArray().Length;
                    //MessageBox.Show(doc.Descendants("posts").ElementAt(0).Descendants("file_url").FirstOrDefault().Value.ToString());
                    if (amount > 0)
                    {
                        using (WebClient client = new WebClient())
                        {
                            downloading = true;
                            client.DownloadProgressChanged += Client_DownloadProgressChanged;
                            cancelDownloadButton.Enabled = true;
                            //await client.DownloadFileTaskAsync(array[0]["file_url"].ToString(), downloadDestBox.Text + "\\" + array[0]["id"].ToString() + "." + array[0]["file_ext"].ToString());
                            //for (int i = 0; i < amount; i++)
                            //{
                            //    downloadingLabel.Text = "Downloading " + (i + 1).ToString() + "/" + amount.ToString();
                            //    string url = doc.Descendants("posts").ElementAt(i).Descendants("file_url").FirstOrDefault().Value.ToString();
                            //    string downloadDest = downloadDestBox.Text + "\\" + doc.Descendants("posts").ElementAt(i).Descendants("id").FirstOrDefault().Value.ToString() + "." + doc.Descendants("posts").ElementAt(i).Descendants("file_ext").FirstOrDefault().Value.ToString();
                            //    //await client.DownloadFileTaskAsync(array[i]["file_url"].ToString(), downloadDestBox.Text + "\\" + array[i]["id"].ToString() + "." + array[i]["file_ext"].ToString());
                            //    await client.DownloadFileTaskAsync(url, downloadDest);
                            //}
                            //MessageBox.Show(doc.Descendants("posts").ToArray().Length.ToString());
                            int dlIndex = 0;
                            foreach (XElement element in doc.Descendants("posts").Nodes())
                            {
                                if (cancelDownload)
                                {
                                    client.DownloadProgressChanged -= Client_DownloadProgressChanged;
                                    downloading = false;
                                    startDownloadButton.Enabled = true;
                                    downloadProgressBar.Value = 0;
                                    downloadingLabel.Text = NOT_DOWNLOADING_TEXT;
                                    return;
                                }
                                //MessageBox.Show(element.Descendants("id").FirstOrDefault().Value.ToString());
                                downloadingLabel.Text = "Downloading " + (dlIndex + 1).ToString() + "/" + amount.ToString();
                                string url = element.Descendants("file_url").FirstOrDefault().Value.ToString();
                                string downloadDest = downloadDestBox.Text + "\\" + element.Descendants("id").FirstOrDefault().Value.ToString() + "." + element.Descendants("file_ext").FirstOrDefault().Value.ToString();
                                await client.DownloadFileTaskAsync(url, downloadDest);
                                dlIndex++;
                            }
                            client.DownloadProgressChanged -= Client_DownloadProgressChanged;
                            downloadingLabel.Text = NOT_DOWNLOADING_TEXT;
                            MessageBox.Show("Downloads done", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            startDownloadButton.Enabled = true;
                            cancelDownloadButton.Enabled = false;
                            downloading = false;
                            downloadProgressBar.Value = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Couldn't find any results with those search tags.", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        startDownloadButton.Enabled = true;
                        downloading = false;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n\n" + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startDownloadButton.Enabled = true;
                downloading = false;
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadProgressBar.Value = e.ProgressPercentage;
        }

        public async Task<string> GetJson(string link)
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1");
                http.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

                return await http.GetStringAsync(link);
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (downloading)
            {
                MessageBox.Show("Files are currently being downloaded. You can't close the program now.", "Notice", MessageBoxButtons.OK);
                e.Cancel = true;
            }
        }

        private void cancelDownloadButton_Click(object sender, EventArgs e)
        {
            if (downloading)
            {
                cancelDownload = true;
                cancelDownloadButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Not downloading. You shouldn't even see this box.");
            }
        }
    }
}
