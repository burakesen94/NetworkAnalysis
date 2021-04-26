
namespace NetworkAnalysis.DataCollection
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_RelatedTags = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_SelectedTag = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.tb_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_tagsToCollectData = new System.Windows.Forms.ListBox();
            this.lbl_RelatedTags = new System.Windows.Forms.Label();
            this.lbl_TagsToCollection = new System.Windows.Forms.Label();
            this.btn_TestDb = new System.Windows.Forms.Button();
            this.tmr_CollectData = new System.Windows.Forms.Timer(this.components);
            this.btn_saveFile = new System.Windows.Forms.Button();
            this.btn_loadFile = new System.Windows.Forms.Button();
            this.tmr_AutoSave = new System.Windows.Forms.Timer(this.components);
            this.lbl_Event = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_RelatedTags
            // 
            this.lb_RelatedTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_RelatedTags.FormattingEnabled = true;
            this.lb_RelatedTags.IntegralHeight = false;
            this.lb_RelatedTags.ItemHeight = 16;
            this.lb_RelatedTags.Location = new System.Drawing.Point(20, 112);
            this.lb_RelatedTags.Margin = new System.Windows.Forms.Padding(4);
            this.lb_RelatedTags.Name = "lb_RelatedTags";
            this.lb_RelatedTags.Size = new System.Drawing.Size(425, 418);
            this.lb_RelatedTags.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected Tag";
            // 
            // tb_SelectedTag
            // 
            this.tb_SelectedTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_SelectedTag.Location = new System.Drawing.Point(135, 44);
            this.tb_SelectedTag.Margin = new System.Windows.Forms.Padding(4);
            this.tb_SelectedTag.Name = "tb_SelectedTag";
            this.tb_SelectedTag.Size = new System.Drawing.Size(223, 22);
            this.tb_SelectedTag.TabIndex = 2;
            this.tb_SelectedTag.Text = "javascript";
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Red;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.ForeColor = System.Drawing.Color.White;
            this.btn_Start.Location = new System.Drawing.Point(577, 537);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(127, 42);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // tb_Address
            // 
            this.tb_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Address.Location = new System.Drawing.Point(135, 12);
            this.tb_Address.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Address.Name = "tb_Address";
            this.tb_Address.Size = new System.Drawing.Size(571, 22);
            this.tb_Address.TabIndex = 5;
            this.tb_Address.Text = "https://stackoverflow.com/questions/tagged/{tag}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base Url";
            // 
            // lb_tagsToCollectData
            // 
            this.lb_tagsToCollectData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tagsToCollectData.FormattingEnabled = true;
            this.lb_tagsToCollectData.ItemHeight = 16;
            this.lb_tagsToCollectData.Location = new System.Drawing.Point(455, 112);
            this.lb_tagsToCollectData.Margin = new System.Windows.Forms.Padding(4);
            this.lb_tagsToCollectData.Name = "lb_tagsToCollectData";
            this.lb_tagsToCollectData.Size = new System.Drawing.Size(249, 420);
            this.lb_tagsToCollectData.TabIndex = 6;
            // 
            // lbl_RelatedTags
            // 
            this.lbl_RelatedTags.AutoSize = true;
            this.lbl_RelatedTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RelatedTags.Location = new System.Drawing.Point(16, 89);
            this.lbl_RelatedTags.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_RelatedTags.Name = "lbl_RelatedTags";
            this.lbl_RelatedTags.Size = new System.Drawing.Size(103, 16);
            this.lbl_RelatedTags.TabIndex = 7;
            this.lbl_RelatedTags.Text = "Related Tags";
            // 
            // lbl_TagsToCollection
            // 
            this.lbl_TagsToCollection.AutoSize = true;
            this.lbl_TagsToCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TagsToCollection.Location = new System.Drawing.Point(452, 89);
            this.lbl_TagsToCollection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TagsToCollection.Name = "lbl_TagsToCollection";
            this.lbl_TagsToCollection.Size = new System.Drawing.Size(134, 16);
            this.lbl_TagsToCollection.TabIndex = 8;
            this.lbl_TagsToCollection.Text = "Tags to Collection";
            // 
            // btn_TestDb
            // 
            this.btn_TestDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TestDb.Location = new System.Drawing.Point(19, 538);
            this.btn_TestDb.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TestDb.Name = "btn_TestDb";
            this.btn_TestDb.Size = new System.Drawing.Size(76, 42);
            this.btn_TestDb.TabIndex = 9;
            this.btn_TestDb.Text = "Test DB";
            this.btn_TestDb.UseVisualStyleBackColor = true;
            this.btn_TestDb.Click += new System.EventHandler(this.btn_TestDb_Click);
            // 
            // tmr_CollectData
            // 
            this.tmr_CollectData.Interval = 10000;
            this.tmr_CollectData.Tick += new System.EventHandler(this.tmr_CollectData_Tick);
            // 
            // btn_saveFile
            // 
            this.btn_saveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveFile.Location = new System.Drawing.Point(103, 538);
            this.btn_saveFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_saveFile.Name = "btn_saveFile";
            this.btn_saveFile.Size = new System.Drawing.Size(97, 42);
            this.btn_saveFile.TabIndex = 10;
            this.btn_saveFile.Text = "Save Lists To File";
            this.btn_saveFile.UseVisualStyleBackColor = true;
            this.btn_saveFile.Click += new System.EventHandler(this.btn_saveFile_Click);
            // 
            // btn_loadFile
            // 
            this.btn_loadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadFile.Location = new System.Drawing.Point(208, 538);
            this.btn_loadFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_loadFile.Name = "btn_loadFile";
            this.btn_loadFile.Size = new System.Drawing.Size(97, 42);
            this.btn_loadFile.TabIndex = 11;
            this.btn_loadFile.Text = "Load Lists From File";
            this.btn_loadFile.UseVisualStyleBackColor = true;
            this.btn_loadFile.Click += new System.EventHandler(this.btn_loadFile_Click);
            // 
            // tmr_AutoSave
            // 
            this.tmr_AutoSave.Interval = 120000;
            this.tmr_AutoSave.Tick += new System.EventHandler(this.tmr_AutoSave_Tick);
            // 
            // lbl_Event
            // 
            this.lbl_Event.AutoSize = true;
            this.lbl_Event.BackColor = System.Drawing.Color.White;
            this.lbl_Event.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Event.Location = new System.Drawing.Point(8, 590);
            this.lbl_Event.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Event.Name = "lbl_Event";
            this.lbl_Event.Padding = new System.Windows.Forms.Padding(10);
            this.lbl_Event.Size = new System.Drawing.Size(110, 36);
            this.lbl_Event.TabIndex = 12;
            this.lbl_Event.Text = "2020 Ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 635);
            this.Controls.Add(this.lbl_Event);
            this.Controls.Add(this.btn_loadFile);
            this.Controls.Add(this.btn_saveFile);
            this.Controls.Add(this.btn_TestDb);
            this.Controls.Add(this.lbl_TagsToCollection);
            this.Controls.Add(this.lbl_RelatedTags);
            this.Controls.Add(this.lb_tagsToCollectData);
            this.Controls.Add(this.tb_Address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.tb_SelectedTag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_RelatedTags);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Data Collection - Network Analysis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_RelatedTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SelectedTag;
        private System.Windows.Forms.TextBox tb_Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_tagsToCollectData;
        private System.Windows.Forms.Label lbl_RelatedTags;
        private System.Windows.Forms.Label lbl_TagsToCollection;
        private System.Windows.Forms.Button btn_TestDb;
        private System.Windows.Forms.Timer tmr_CollectData;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_saveFile;
        private System.Windows.Forms.Button btn_loadFile;
        private System.Windows.Forms.Timer tmr_AutoSave;
        private System.Windows.Forms.Label lbl_Event;
    }
}

