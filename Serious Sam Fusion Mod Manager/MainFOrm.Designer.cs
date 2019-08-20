namespace SSFModManager
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lst_mods = new System.Windows.Forms.ListBox();
            this.txt_brief = new System.Windows.Forms.RichTextBox();
            this.menu_mods = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menu_mods.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lst_mods);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_brief);
            this.splitContainer1.Size = new System.Drawing.Size(882, 596);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 1;
            // 
            // lst_mods
            // 
            this.lst_mods.ContextMenuStrip = this.menu_mods;
            this.lst_mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_mods.FormattingEnabled = true;
            this.lst_mods.Location = new System.Drawing.Point(0, 0);
            this.lst_mods.Name = "lst_mods";
            this.lst_mods.Size = new System.Drawing.Size(294, 596);
            this.lst_mods.TabIndex = 0;
            this.lst_mods.SelectedIndexChanged += new System.EventHandler(this.Lst_mods_SelectedIndexChanged);
            // 
            // txt_brief
            // 
            this.txt_brief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_brief.Location = new System.Drawing.Point(0, 0);
            this.txt_brief.Name = "txt_brief";
            this.txt_brief.Size = new System.Drawing.Size(584, 596);
            this.txt_brief.TabIndex = 0;
            this.txt_brief.Text = "";
            // 
            // menu_mods
            // 
            this.menu_mods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.disableToolStripMenuItem});
            this.menu_mods.Name = "menu_mods";
            this.menu_mods.Size = new System.Drawing.Size(145, 48);
            this.menu_mods.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_mods_Opening);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.DisableToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 596);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Serious Sam Fusion Mod Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menu_mods.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txt_brief;
        private System.Windows.Forms.ContextMenuStrip menu_mods;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ListBox lst_mods;
    }
}

