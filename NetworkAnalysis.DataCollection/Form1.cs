using HtmlAgilityPack;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkAnalysis.DataCollection
{
    public partial class Form1 : Form
    {
        private MySqlConnection _conn;
        public Form1()
        {
            InitializeComponent();
            CheckTmr_CollectData();
            _conn = OpenDbConnection();
            FireEvent("Program is ready.");
        }

        private async void tmr_CollectData_Tick(object sender, EventArgs e)
        { 
            if (lb_tagsToCollectData.Items.Count > 0)
            {
                tb_SelectedTag.Text = lb_tagsToCollectData.Items[0]?.ToString().Trim();
                lb_tagsToCollectData.Items.RemoveAt(0);
                UpdateLblTagsToCollection();
            }
            await LoadRelatedTags(tb_SelectedTag.Text);
        }

        private void btn_TestDb_Click(object sender, EventArgs e)
        {
  
        }

        private void CheckTmr_CollectData()
        {
            if (tmr_CollectData.Enabled)
            {
                btn_Start.BackColor = Color.Red;
                btn_Start.Text = "Stop";
                OpenDbConnection();
                tmr_AutoSave.Enabled = true; 
                FireEvent("Data collection has started.");
            }
            else
            {
                btn_Start.BackColor = Color.Green;
                btn_Start.Text = "Start";
                CloseDbConnection();
                tmr_AutoSave.Enabled = false;
                FireEvent("Data collection has stopped.");
            }
        }

        private async Task LoadRelatedTags(string selectedTag)
        {
            lb_RelatedTags.Items.Clear();

            using (WebClient client = new WebClient())
            {
                var link = tb_Address.Text.Replace("{tag}", selectedTag); ;
                var uri = new Uri(link); 
                var host = uri.Host; 
                var scheme = uri.Scheme;

                client.Encoding = Encoding.UTF8;

                string html = await client.DownloadStringTaskAsync(uri);
                 
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);
                 

                HtmlNodeCollection htmlNodes = htmlDocument.DocumentNode.SelectNodes(@"//*[@id=""sidebar""]/div[3]/div"); 

                if (htmlNodes != null)
                { 
                    foreach (HtmlNode node in htmlNodes)
                    {  
                        string tag = node.Attributes["data-name"]?.Value;
                        string weight = node.SelectSingleNode(@"./span/span[2]").InnerText;
                        if(!string.IsNullOrEmpty(tag))
                        {
                            await AddTagToDb(selectedTag, tag, weight);
                        }
                        else
                        {
                            FireEvent($"Empty value when {selectedTag} parsing...");
                        }
                    }
                }
            }
        }

        private void AddTagToLists(string tag, string weight)
        {
            string _tag = tag.Trim();
            string _weight = weight.Trim();

            lb_RelatedTags.Items.Add($"{_tag.PadRight(20)}\t\t{_weight.PadLeft(20)}");
            UpdateLbRelatedTags();

            if (!lb_tagsToCollectData.Items.Contains(_tag))
            {
                lb_tagsToCollectData.Items.Add(_tag);
                UpdateLblTagsToCollection();
            }
        }

        private void UpdateLblTagsToCollection()
        {
            lbl_TagsToCollection.Text = $"Tags to Collection ({lb_tagsToCollectData.Items.Count})";
        }

        private void UpdateLbRelatedTags()
        {
            lbl_RelatedTags.Text = $"Related Tags ({lb_RelatedTags.Items.Count})";
        }

        private async Task AddTagToDb(string src, string trg, string weight)
        {
            using (var command = _conn.CreateCommand())
            {
                command.CommandText = $@"CALL AddTagConnection('{src}', '{trg}', {weight});";
                await command.ExecuteNonQueryAsync(); 
                AddTagToLists(trg, weight);
            }
        }        

        private void btn_Start_Click(object sender, EventArgs e)
        {
            tmr_CollectData.Enabled = !tmr_CollectData.Enabled;
            CheckTmr_CollectData();
        }

        private MySqlConnection OpenDbConnection()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = " ",
                Database = " ",
                UserID = " ",
                Password = " ", 
                SslMode = MySqlSslMode.Required,
            };

            if (_conn == null)
                _conn = new MySqlConnection(builder.ConnectionString);

            _conn.OpenAsync();
            return _conn;
        }

        private void CloseDbConnection()
        {
            if(_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }

        private void StopTimer()
        {
            tmr_CollectData.Enabled = false;
            CheckTmr_CollectData();
        }

        private void btn_saveFile_Click(object sender, EventArgs e)
        {
            SaveFile(); 
        }

        private void btn_loadFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void SaveFile(bool isAutoSave = false)
        {
            try
            {
                //StopTimer();
                if (lb_tagsToCollectData.Items.Count > 0)
                {
                    var fileName = "save";
                    if (isAutoSave) {
                        fileName += DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
                    }
                    using (StreamWriter writetext = new StreamWriter(fileName + ".txt"))
                    {
                        writetext.Flush();
                        writetext.WriteLine(tb_SelectedTag.Text);
                        foreach (var item in lb_tagsToCollectData.Items)
                        {
                            writetext.WriteLine(item.ToString());
                        }
                    }
                    FireEvent("Items are saved.");
                }
                else
                {
                    FireEvent("No items found in list.");
                }
            }
            catch (Exception ex)
            {
                FireEvent(ex.Message);
            }
        }

        private void LoadFile()
        {
            try
            {
                //StopTimer();
                if (lb_tagsToCollectData.Items.Count == 0)
                {
                    using (StreamReader readtext = new StreamReader("save.txt"))
                    {
                        lb_tagsToCollectData.Items.Clear();
                        string line;
                        while ((line = readtext.ReadLine()) != null)
                            lb_tagsToCollectData.Items.Add(line);
                    }
                }
                else
                {
                    FireEvent("List is not epty.");
                }

            }
            catch (Exception ex)
            {
                FireEvent(ex.Message);
            }
        }

        private void tmr_AutoSave_Tick(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void FireEvent(string msg)
        {
            lbl_Event.Text = $"{DateTime.Now} : {msg}";
        }
    }
}
