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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lst_mods = new System.Windows.Forms.ListBox();
            this.menu_mods = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_brief = new System.Windows.Forms.RichTextBox();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.focusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDisabledFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs_tags = new System.Windows.Forms.TabControl();
            this.tab_all = new System.Windows.Forms.TabPage();
            this.status = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menu_mods.SuspendLayout();
            this.menu_main.SuspendLayout();
            this.tabs_tags.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lst_mods);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_brief);
            this.splitContainer1.Size = new System.Drawing.Size(858, 522);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 1;
            // 
            // lst_mods
            // 
            this.lst_mods.ContextMenuStrip = this.menu_mods;
            this.lst_mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_mods.FormattingEnabled = true;
            this.lst_mods.Location = new System.Drawing.Point(0, 0);
            this.lst_mods.Name = "lst_mods";
            this.lst_mods.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_mods.Size = new System.Drawing.Size(286, 522);
            this.lst_mods.TabIndex = 0;
            this.lst_mods.SelectedIndexChanged += new System.EventHandler(this.Lst_mods_SelectedIndexChanged);
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
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.DisableToolStripMenuItem_Click);
            // 
            // txt_brief
            // 
            this.txt_brief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_brief.Location = new System.Drawing.Point(0, 0);
            this.txt_brief.Name = "txt_brief";
            this.txt_brief.Size = new System.Drawing.Size(568, 522);
            this.txt_brief.TabIndex = 0;
            this.txt_brief.Text = "";
            // 
            // menu_main
            // 
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.reloadToolStripMenuItem1});
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(882, 25);
            this.menu_main.TabIndex = 2;
            this.menu_main.Text = "Main Menu";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.killToolStripMenuItem,
            this.focusToolStripMenuItem,
            this.startEditorToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(54, 21);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "Start (Modded)";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.KillToolStripMenuItem_Click);
            // 
            // focusToolStripMenuItem
            // 
            this.focusToolStripMenuItem.Name = "focusToolStripMenuItem";
            this.focusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.focusToolStripMenuItem.Text = "Focus";
            this.focusToolStripMenuItem.Click += new System.EventHandler(this.FocusToolStripMenuItem_Click);
            // 
            // startEditorToolStripMenuItem
            // 
            this.startEditorToolStripMenuItem.Name = "startEditorToolStripMenuItem";
            this.startEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startEditorToolStripMenuItem.Text = "Start Editor";
            this.startEditorToolStripMenuItem.Click += new System.EventHandler(this.StartEditorToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDisabledFolderToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // openDisabledFolderToolStripMenuItem
            // 
            this.openDisabledFolderToolStripMenuItem.Name = "openDisabledFolderToolStripMenuItem";
            this.openDisabledFolderToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openDisabledFolderToolStripMenuItem.Text = "Open Disabled Folder";
            this.openDisabledFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenDisabledFolderToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // reloadToolStripMenuItem1
            // 
            this.reloadToolStripMenuItem1.Name = "reloadToolStripMenuItem1";
            this.reloadToolStripMenuItem1.Size = new System.Drawing.Size(58, 21);
            this.reloadToolStripMenuItem1.Text = "Reload";
            this.reloadToolStripMenuItem1.Click += new System.EventHandler(this.ReloadToolStripMenuItem1_Click);
            // 
            // tabs_tags
            // 
            this.tabs_tags.Controls.Add(this.tab_all);
            this.tabs_tags.Location = new System.Drawing.Point(12, 28);
            this.tabs_tags.Name = "tabs_tags";
            this.tabs_tags.SelectedIndex = 0;
            this.tabs_tags.Size = new System.Drawing.Size(858, 22);
            this.tabs_tags.TabIndex = 0;
            this.tabs_tags.SelectedIndexChanged += new System.EventHandler(this.Tabs_tags_SelectedIndexChanged);
            // 
            // tab_all
            // 
            this.tab_all.Location = new System.Drawing.Point(4, 22);
            this.tab_all.Name = "tab_all";
            this.tab_all.Padding = new System.Windows.Forms.Padding(3);
            this.tab_all.Size = new System.Drawing.Size(850, 0);
            this.tab_all.TabIndex = 0;
            this.tab_all.Text = "All";
            this.tab_all.UseVisualStyleBackColor = true;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 589);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(882, 22);
            this.status.TabIndex = 4;
            this.status.Text = "Status";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 611);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tabs_tags);
            this.Controls.Add(this.menu_main);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Serious Sam Fusion Mod Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menu_mods.ResumeLayout(false);
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.tabs_tags.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txt_brief;
        private System.Windows.Forms.ContextMenuStrip menu_mods;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ListBox lst_mods;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDisabledFolderToolStripMenuItem;
        private System.Windows.Forms.TabControl tabs_tags;
        private System.Windows.Forms.TabPage tab_all;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem focusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startEditorToolStripMenuItem;
    }
}

