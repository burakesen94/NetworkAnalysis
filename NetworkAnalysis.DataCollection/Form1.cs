using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkAnalysis.DataCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckTmr_CollectData();
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
            }
            else
            {
                btn_Start.BackColor = Color.Green;
                btn_Start.Text = "Start";
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
                            AddTagToLists(tag, weight);
                        }
                        else
                        {
                            MessageBox.Show($"Empty value when {selectedTag} parsing...");
                        }
                    }
                }
            }
        }

        private void AddTagToLists(string tag, string weight)
        {
            string _tag = tag.Trim();
            string _weight = weight.Trim();

            lb_RelatedTags.Items.Add($"{_tag.PadRight(50)}{_weight.PadLeft(15)}");
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

        private void AddTagToDb(string tag, string weight)
        {
            string _tag = tag.Trim();
            string _weight = weight.Trim();

            lb_RelatedTags.Items.Add($"{_tag}\t\t{_weight}"); 
            lbl_RelatedTags.Text = $"Related Tags ({lb_RelatedTags.Items.Count})";

            if (!lb_tagsToCollectData.Items.Contains(_tag))
            {
                lb_tagsToCollectData.Items.Add(_tag);
                lbl_TagsToCollection.Text = $"Tags to Collection ({lb_tagsToCollectData.Items.Count})"; ;
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            tmr_CollectData.Enabled = !tmr_CollectData.Enabled;
            CheckTmr_CollectData();
        }
    }
}
