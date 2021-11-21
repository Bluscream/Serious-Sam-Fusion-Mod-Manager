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
            this.txt_mods_filter = new System.Windows.Forms.TextBox();
            this.lst_mods = new System.Windows.Forms.ListBox();
            this.menu_mods = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs_modinfo = new System.Windows.Forms.TabControl();
            this.tab_modinfo = new System.Windows.Forms.TabPage();
            this.panel_modinfo = new System.Windows.Forms.FlowLayoutPanel();
            this.tab_modinfo_description = new System.Windows.Forms.TabPage();
            this.txt_mod_description = new System.Windows.Forms.RichTextBox();
            this.tab_modinfo_raw = new System.Windows.Forms.TabPage();
            this.txt_brief = new System.Windows.Forms.RichTextBox();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.focusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_filters = new System.Windows.Forms.ToolStripMenuItem();
            this.searchInEverything = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.searchInNames = new System.Windows.Forms.ToolStripMenuItem();
            this.searchInDescriptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.onlyShowDisabled = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyShowEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.SteamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.campaignsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDisabledFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs_tags = new System.Windows.Forms.TabControl();
            this.tab_all = new System.Windows.Forms.TabPage();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.workshopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menu_mods.SuspendLayout();
            this.tabs_modinfo.SuspendLayout();
            this.tab_modinfo.SuspendLayout();
            this.tab_modinfo_description.SuspendLayout();
            this.tab_modinfo_raw.SuspendLayout();
            this.menu_main.SuspendLayout();
            this.tabs_tags.SuspendLayout();
            this.status.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txt_mods_filter);
            this.splitContainer1.Panel1.Controls.Add(this.lst_mods);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabs_modinfo);
            this.splitContainer1.Size = new System.Drawing.Size(858, 522);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 1;
            // 
            // txt_mods_filter
            // 
            this.txt_mods_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_mods_filter.Location = new System.Drawing.Point(4, 4);
            this.txt_mods_filter.Name = "txt_mods_filter";
            this.txt_mods_filter.Size = new System.Drawing.Size(279, 20);
            this.txt_mods_filter.TabIndex = 1;
            this.txt_mods_filter.TextChanged += new System.EventHandler(this.Txt_mods_filter_TextChanged);
            // 
            // lst_mods
            // 
            this.lst_mods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_mods.ContextMenuStrip = this.menu_mods;
            this.lst_mods.FormattingEnabled = true;
            this.lst_mods.Location = new System.Drawing.Point(0, 26);
            this.lst_mods.Name = "lst_mods";
            this.lst_mods.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_mods.Size = new System.Drawing.Size(286, 485);
            this.lst_mods.TabIndex = 0;
            this.lst_mods.SelectedIndexChanged += new System.EventHandler(this.Lst_mods_SelectedIndexChanged);
            // 
            // menu_mods
            // 
            this.menu_mods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.disableToolStripMenuItem,
            this.workshopToolStripMenuItem});
            this.menu_mods.Name = "menu_mods";
            this.menu_mods.Size = new System.Drawing.Size(181, 92);
            this.menu_mods.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_mods_Opening);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.DisableToolStripMenuItem_Click);
            // 
            // tabs_modinfo
            // 
            this.tabs_modinfo.Controls.Add(this.tab_modinfo);
            this.tabs_modinfo.Controls.Add(this.tab_modinfo_description);
            this.tabs_modinfo.Controls.Add(this.tab_modinfo_raw);
            this.tabs_modinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_modinfo.Location = new System.Drawing.Point(0, 0);
            this.tabs_modinfo.Name = "tabs_modinfo";
            this.tabs_modinfo.SelectedIndex = 0;
            this.tabs_modinfo.Size = new System.Drawing.Size(568, 522);
            this.tabs_modinfo.TabIndex = 1;
            // 
            // tab_modinfo
            // 
            this.tab_modinfo.Controls.Add(this.panel_modinfo);
            this.tab_modinfo.Location = new System.Drawing.Point(4, 22);
            this.tab_modinfo.Name = "tab_modinfo";
            this.tab_modinfo.Padding = new System.Windows.Forms.Padding(3);
            this.tab_modinfo.Size = new System.Drawing.Size(560, 496);
            this.tab_modinfo.TabIndex = 0;
            this.tab_modinfo.Text = "Infos";
            this.tab_modinfo.UseVisualStyleBackColor = true;
            // 
            // panel_modinfo
            // 
            this.panel_modinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_modinfo.Location = new System.Drawing.Point(3, 3);
            this.panel_modinfo.Name = "panel_modinfo";
            this.panel_modinfo.Size = new System.Drawing.Size(554, 490);
            this.panel_modinfo.TabIndex = 0;
            // 
            // tab_modinfo_description
            // 
            this.tab_modinfo_description.Controls.Add(this.txt_mod_description);
            this.tab_modinfo_description.Location = new System.Drawing.Point(4, 22);
            this.tab_modinfo_description.Name = "tab_modinfo_description";
            this.tab_modinfo_description.Padding = new System.Windows.Forms.Padding(3);
            this.tab_modinfo_description.Size = new System.Drawing.Size(560, 496);
            this.tab_modinfo_description.TabIndex = 2;
            this.tab_modinfo_description.Text = "Description";
            this.tab_modinfo_description.UseVisualStyleBackColor = true;
            // 
            // txt_mod_description
            // 
            this.txt_mod_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_description.Location = new System.Drawing.Point(3, 3);
            this.txt_mod_description.Name = "txt_mod_description";
            this.txt_mod_description.ReadOnly = true;
            this.txt_mod_description.Size = new System.Drawing.Size(554, 490);
            this.txt_mod_description.TabIndex = 1;
            this.txt_mod_description.Text = "";
            // 
            // tab_modinfo_raw
            // 
            this.tab_modinfo_raw.Controls.Add(this.txt_brief);
            this.tab_modinfo_raw.Location = new System.Drawing.Point(4, 22);
            this.tab_modinfo_raw.Name = "tab_modinfo_raw";
            this.tab_modinfo_raw.Padding = new System.Windows.Forms.Padding(3);
            this.tab_modinfo_raw.Size = new System.Drawing.Size(560, 496);
            this.tab_modinfo_raw.TabIndex = 1;
            this.tab_modinfo_raw.Text = "Raw";
            this.tab_modinfo_raw.UseVisualStyleBackColor = true;
            // 
            // txt_brief
            // 
            this.txt_brief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_brief.Location = new System.Drawing.Point(3, 3);
            this.txt_brief.Name = "txt_brief";
            this.txt_brief.Size = new System.Drawing.Size(554, 490);
            this.txt_brief.TabIndex = 0;
            this.txt_brief.Text = "";
            // 
            // menu_main
            // 
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.menu_filters,
            this.SteamToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.reloadToolStripMenuItem1});
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(882, 24);
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
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.startToolStripMenuItem.Text = "Start (Modded)";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.KillToolStripMenuItem_Click);
            // 
            // focusToolStripMenuItem
            // 
            this.focusToolStripMenuItem.Name = "focusToolStripMenuItem";
            this.focusToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.focusToolStripMenuItem.Text = "Focus";
            this.focusToolStripMenuItem.Click += new System.EventHandler(this.FocusToolStripMenuItem_Click);
            // 
            // startEditorToolStripMenuItem
            // 
            this.startEditorToolStripMenuItem.Name = "startEditorToolStripMenuItem";
            this.startEditorToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.startEditorToolStripMenuItem.Text = "Start Editor";
            this.startEditorToolStripMenuItem.Click += new System.EventHandler(this.StartEditorToolStripMenuItem_Click);
            // 
            // menu_filters
            // 
            this.menu_filters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchInEverything,
            this.toolStripSeparator1,
            this.searchInNames,
            this.searchInDescriptions,
            this.toolStripSeparator2,
            this.onlyShowDisabled,
            this.onlyShowEnabled});
            this.menu_filters.Name = "menu_filters";
            this.menu_filters.Size = new System.Drawing.Size(45, 20);
            this.menu_filters.Text = "Filter";
            // 
            // searchInEverything
            // 
            this.searchInEverything.Name = "searchInEverything";
            this.searchInEverything.Size = new System.Drawing.Size(190, 22);
            this.searchInEverything.Text = "Search in Everything";
            this.searchInEverything.Click += new System.EventHandler(this.FilterMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // searchInNames
            // 
            this.searchInNames.Checked = true;
            this.searchInNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchInNames.Name = "searchInNames";
            this.searchInNames.Size = new System.Drawing.Size(190, 22);
            this.searchInNames.Text = "Search in Names";
            this.searchInNames.Click += new System.EventHandler(this.FilterMenuItem_Click);
            // 
            // searchInDescriptions
            // 
            this.searchInDescriptions.Name = "searchInDescriptions";
            this.searchInDescriptions.Size = new System.Drawing.Size(190, 22);
            this.searchInDescriptions.Text = "Search in Descriptions";
            this.searchInDescriptions.Click += new System.EventHandler(this.FilterMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // onlyShowDisabled
            // 
            this.onlyShowDisabled.Name = "onlyShowDisabled";
            this.onlyShowDisabled.Size = new System.Drawing.Size(190, 22);
            this.onlyShowDisabled.Text = "Only Show Disabled";
            this.onlyShowDisabled.Click += new System.EventHandler(this.OnlyShowDisabled_Click);
            // 
            // onlyShowEnabled
            // 
            this.onlyShowEnabled.Name = "onlyShowEnabled";
            this.onlyShowEnabled.Size = new System.Drawing.Size(190, 22);
            this.onlyShowEnabled.Text = "Only Show Enabled";
            this.onlyShowEnabled.Click += new System.EventHandler(this.OnlyShowEnabled_Click);
            // 
            // SteamToolStripMenuItem
            // 
            this.SteamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.campaignsToolStripMenuItem,
            this.weaponsToolStripMenuItem});
            this.SteamToolStripMenuItem.Name = "SteamToolStripMenuItem";
            this.SteamToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.SteamToolStripMenuItem.Text = "Steam";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Tag = "steam://openurl/https://steamcommunity.com/app/564310/workshop/";
            this.openToolStripMenuItem.Text = "Workshop";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.onLinkClicked);
            // 
            // campaignsToolStripMenuItem
            // 
            this.campaignsToolStripMenuItem.Name = "campaignsToolStripMenuItem";
            this.campaignsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.campaignsToolStripMenuItem.Tag = "steam://openurl/https://steamcommunity.com/workshop/browse/?appid=564310&required" +
    "tags%5B0%5D=Custom+Campaign&actualsort=totaluniquesubscribers&browsesort=totalun" +
    "iquesubscribers&p=1";
            this.campaignsToolStripMenuItem.Text = "Campaigns";
            this.campaignsToolStripMenuItem.Click += new System.EventHandler(this.onLinkClicked);
            // 
            // weaponsToolStripMenuItem
            // 
            this.weaponsToolStripMenuItem.Name = "weaponsToolStripMenuItem";
            this.weaponsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.weaponsToolStripMenuItem.Tag = resources.GetString("weaponsToolStripMenuItem.Tag");
            this.weaponsToolStripMenuItem.Text = "Weapons";
            this.weaponsToolStripMenuItem.Click += new System.EventHandler(this.onLinkClicked);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDisabledFolderToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // openDisabledFolderToolStripMenuItem
            // 
            this.openDisabledFolderToolStripMenuItem.Name = "openDisabledFolderToolStripMenuItem";
            this.openDisabledFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openDisabledFolderToolStripMenuItem.Text = "Open Disabled Folder";
            this.openDisabledFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenDisabledFolderToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // reloadToolStripMenuItem1
            // 
            this.reloadToolStripMenuItem1.Name = "reloadToolStripMenuItem1";
            this.reloadToolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.reloadToolStripMenuItem1.Text = "Reload";
            this.reloadToolStripMenuItem1.Click += new System.EventHandler(this.ReloadToolStripMenuItem1_Click);
            // 
            // tabs_tags
            // 
            this.tabs_tags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_status});
            this.status.Location = new System.Drawing.Point(0, 589);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(882, 22);
            this.status.TabIndex = 4;
            this.status.Text = "Status";
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(0, 17);
            // 
            // workshopToolStripMenuItem
            // 
            this.workshopToolStripMenuItem.Name = "workshopToolStripMenuItem";
            this.workshopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.workshopToolStripMenuItem.Text = "Workshop";
            this.workshopToolStripMenuItem.Click += new System.EventHandler(this.workshopToolStripMenuItem_Click);
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
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menu_mods.ResumeLayout(false);
            this.tabs_modinfo.ResumeLayout(false);
            this.tab_modinfo.ResumeLayout(false);
            this.tab_modinfo_description.ResumeLayout(false);
            this.tab_modinfo_raw.ResumeLayout(false);
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.tabs_tags.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
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
        private System.Windows.Forms.TextBox txt_mods_filter;
        private System.Windows.Forms.TabControl tabs_modinfo;
        private System.Windows.Forms.TabPage tab_modinfo;
        private System.Windows.Forms.TabPage tab_modinfo_raw;
        private System.Windows.Forms.ToolStripMenuItem menu_filters;
        private System.Windows.Forms.ToolStripMenuItem searchInNames;
        private System.Windows.Forms.ToolStripMenuItem searchInEverything;
        private System.Windows.Forms.ToolStripMenuItem searchInDescriptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status;
        private System.Windows.Forms.FlowLayoutPanel panel_modinfo;
        private System.Windows.Forms.TabPage tab_modinfo_description;
        private System.Windows.Forms.RichTextBox txt_mod_description;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem onlyShowDisabled;
        private System.Windows.Forms.ToolStripMenuItem onlyShowEnabled;
        private System.Windows.Forms.ToolStripMenuItem SteamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem campaignsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weaponsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workshopToolStripMenuItem;
    }
}

