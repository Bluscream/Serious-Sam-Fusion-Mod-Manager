﻿using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Http;

using SteamSharp;
using System.Collections.Generic;
using System.Drawing;

namespace SSFModManager
{
    public partial class MainForm : Form
    {
        private static Regex tabRegex = new Regex(@"(.*) \(\d+\)");
        public SSF.Game Game;
        // public SteamClient steam;
        public HttpClient webClient;
        private ModDirWatcher ModDirWatcher;
        private List<SSF.Mod> modsInCategory;
        private async void PreInit()
        {
            var path = new Setup.PathLogic();
            var binPath = path.GetInstallationPath();
            if (!binPath.Exists) {
                MessageBox.Show("Sorry the game wasn't found, exiting.."); Application.Exit();
            }
            Game = new SSF.Game(binPath.Parent.Parent);

        }
        public MainForm()
        {
            PreInit();
            InitializeComponent();
            Init();
        }

        private async void Init() {
            webClient = new HttpClient();
            Game.OnDetailsLoaded += Game_OnDetailsLoaded;
            await Game.UpdateModDetailsAsync(webClient);
            // if (_ != null) FillTabs(Game.Mods);
            // steam = new SteamClient();
            // steam.Timeout = 5;
            modsInCategory = Game.Mods;
            Log($"Loaded {SSF.Game.Name} with {Game.Mods.Count} mods.", Color.Green);
        }

        private void Game_OnDetailsLoaded(object sender)
        {
            InitModList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Console.WriteLine(game.Mods.Where(t => t.Disabled).ToJson());
            txt_brief.Text = Game.ToJson();
            InitModList();
        }

        public void InitModList()
        {
            // lst_mods.DataSource = game.Mods;
            FillModList(Game.Mods);
            FillTabs(Game.Mods);
        }

        private void FillTabs(List<SSF.Mod> mods)
        {
            tabs_tags.TabPages.Clear();
            tabs_tags.TabPages.Add(new TabPage() { Text = $"All ({Game.Mods.Count})" });
            var tags = new HashSet<string>();
            foreach (var mod in mods) {
                if (mod.Tags is null) continue;
                foreach (var tag in mod.Tags) {
                    tags.Add(tag);
                }
            }
            foreach (var tag in tags.OrderBy(t => t).ToList()) {
                tabs_tags.TabPages.Add(new TabPage() { Text = $"{tag} ({Game.Mods.Where(m => m.Tags.Contains(tag)).Count()})" });
            }
        }

        private void Tabs_tags_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = (sender as TabControl).SelectedIndex;
            if (i < 0) return;
            var text = tabs_tags.TabPages[i].Text;
            if (text is null) return;
            text = tabRegex.Match(text).Groups[1].Value;
            if (text != "All") modsInCategory = Game.Mods.Where(m => m.Tags.Contains(text)).ToList();
            else modsInCategory = Game.Mods;
            FillModList(modsInCategory);
            FilterByText();
        }

        private void FillModList(List<SSF.Mod> mods) {
            lst_mods.Items.Clear();
            foreach (var mod in mods.OrderBy(m => m.Name)) {
                lst_mods.Items.Add(mod);
            }
            // lst_mods.SelectedIndex = 0;
        }

        private void Menu_mods_Opening(object sender, CancelEventArgs e)
        {
            if (lst_mods.SelectedItems.Count < 1) { e.Cancel = true; return; }
            var mod = (SSF.Mod)lst_mods.SelectedItems[0];
            if (mod == null) { e.Cancel = true; return; }
            if (lst_mods.SelectedItems.Count > 1) {
                openFolderToolStripMenuItem.Visible = false;
            }
            menu_mods.Items[1].Text = mod.Disabled ? "Enable" : "Disable";
        }

        private void Lst_mods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_mods.SelectedItems.Count < 1) return;
            var mod = (SSF.Mod)lst_mods.SelectedItems[0];
            txt_brief.Text = mod.ToJson();
        }

        private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            var mod = (SSF.Mod)lst_mods.SelectedItems[0];
            if (mod == null) return;
            Utils.OpenFolderInExplorer(mod.Directory);
        }

        private async void DisableToolStripMenuItem_Click(object sender, EventArgs e) {
            var menuItem = (ToolStripMenuItem)sender;
            var state = (menuItem.Text == "Disable" ? true : false);
            var mods = lst_mods.SelectedItems.Cast<SSF.Mod>().ToList();
            mods.ForEach(m => m.Disabled = state);
            if (mods.Count < 1) {
                MessageBox.Show("No mods selected", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (mods.Count > 1) {
                MessageBox.Show($"{mods.Count} mods {(!mods.First().Disabled).ToEnabledDisabled()}", Text);
            } else if (mods.Count == 1) {
                var mod = mods.First();
                MessageBox.Show($"{(!mod.Disabled).ToEnabledDisabled()} {mod.Name}", Text);
            }
        }

        private void OpenDisabledFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenFolderInExplorer(Game.DisabledModsDir);
        }

        private bool CheckGameRunning() {
            if (!Game.Running()) return true;
            var list = Game.Processes.Select(p => $"{p.ProcessName} ({p.Id})").ToList();
            var result = MessageBox.Show($"We have detected that {Game.Processes.Count} game processes are already running:\n\n{string.Join("\n", list)}\n\nDo you want to kill them before starting the game?", "Game already running", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel) return false;
            else if (result == DialogResult.Yes) {
                foreach (var proc in Game.Processes) {
                    if (!proc.HasExited) proc.Kill();
                }
            }
            return true;
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckGameRunning()) return;
            var file = ModifierKeys == Keys.Shift ? Game.Binaries.Main.File(Game, SSF.Architecture.WIN_64) : Game.Binaries.Modded.File(Game, SSF.Architecture.WIN_64);
            Utils.StartProcess(file);
        }

        private void StartEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void KillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var proc in Game.Processes) {
                if (!proc.HasExited) proc.Kill();
            }
            MessageBox.Show($"Killed {Game.Processes.Where(p => p.HasExited).Count()} / {Game.Processes.Count} processes");
        }
        private void FocusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ReloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitModList();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            return;
            if (e.Shift) {
                startToolStripMenuItem.Text = "Start";
            } else {
                startToolStripMenuItem.Text = "Start (Modded)";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModDirWatcher != null) ModDirWatcher.Dispose();
        }

        public void Log(string message, Color color)
        {
            if (!color.IsEmpty) status.ForeColor = color;
            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            status.Text = $"[{timestamp}] {message}";
        }

        private void Txt_mods_filter_TextChanged(object sender, EventArgs e) => FilterByText();
        private void FilterByText()
        {
            var txt = txt_mods_filter.Text.ToLowerInvariant();
            List<SSF.Mod> matchingMods = modsInCategory;
            if (!txt.IsNullOrEmpty()) {
                matchingMods = matchingMods.Where(m => m.Name.ToLowerInvariant().Contains(txt)).ToList();
            }
            FillModList(matchingMods);
        }
    }
}

/*
 *         private async void users_node_selectedAsync(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "Me") {
                FillMe(); return;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Text == "Offline") {
                    FillOfflineFriends(); return;
                } else if (e.Node.Text == "Outgoing") {
                    FillOutgoingRequests(); return;
                }
                if (!(e.Node.Tag is TreeNodeTag tag)) return;
                // Logger.Warn(tag.ToJson());
                if (tag.userResponse != null) { FillUser(tag.userResponse); return; }
                else if (tag.userBriefResponse != null) { FillUser(tag.userBriefResponse); return; }
                else if (tag.Type == NodeType.Notification) {
                    var id = "";
                    if (tag.notificationResponse.ReceiverUserId == me.id) id = tag.notificationResponse.SenderUserId;
                    else if (tag.notificationResponse.SenderUserId == me.id) id = tag.notificationResponse.ReceiverUserId;
                    if (string.IsNullOrEmpty(id)) return;
                    var user = await vrcapi.UserApi.GetById(id); tag.userBriefResponse = user; e.Node.Tag = tag; FillUser(user); return;
                } else if (tag.Type == NodeType.Moderation) {
                    var id = "";
                    if (tag.playerModeratedResponse.targetUserId == me.id) { id = tag.playerModeratedResponse.sourceUserId; }
                    else if (tag.playerModeratedResponse.sourceUserId == me.id) { id = tag.playerModeratedResponse.targetUserId; }
                    if (string.IsNullOrEmpty(id)) return;
                    var user = await vrcapi.UserApi.GetById(id); tag.userBriefResponse = user; e.Node.Tag = tag; FillUser(user); return;
                }
            } else if (e.Button == MouseButtons.Right) {
                if (Program.Arguments.Launcher.Verbose.IsTrue) { // Todo Change
                    for (int i = 0; i < menu_users.Items.Count; i++) {
                        Logger.Trace(i, menu_users.Items[i].Text);
                    }
                }
                tree_users.SelectedNode = e.Node;
                for (int i = 0; i < menu_users.Items.Count; i++) { menu_users.Items[i].Visible = false; }
                if (e.Node.Nodes.Count > 0 || e.Node.Index == 0) menu_users.Items[10].Visible = true; // Refresh
                if(e.Node.Text.StartsWith("Friends ("))
                {
                    menu_users.Items[5].Visible = true; menu_users.Items[6].Visible = true; // Import/Export
                    menu_users.Items[12].Visible = true; // Discord Names
                }
                else if(e.Node.Tag != null)
                {
                    var tag = (TreeNodeTag)tree_users.SelectedNode.Tag;
                    if (tag.Type == NodeType.Me || tag.Type == NodeType.User || tag.Type == NodeType.Moderation || tag.Type == NodeType.Notification) {
                        if (tag.Type == NodeType.Me) {
                            menu_users.Items[11].Visible = true; // Set Status
                        }
                        // if(tag.notificationResponse != null && tag.notificationResponse.)
                        if (!me.friends.Contains(tag.Id)) { menu_users.Items[1].Visible = true; // Unfriend
                        } else {
                            menu_users.Items[2].Visible = true; //Friend
                    }
                        var isBlocked = false;
                        if (tag.Type != NodeType.Moderation) { // Todo: proper implementation
                            foreach (TreeNode node in tree_users.Nodes[2].Nodes)
                            {
                                var nodetag = (TreeNodeTag)node.Tag;
                                if (nodetag.playerModeratedResponse.targetUserId == tag.Id) { isBlocked = true; break; }
                            }
                        } else { isBlocked = true; }
                        if (isBlocked) menu_users.Items[4].Visible = true; // Unblock
                        else { menu_users.Items[3].Visible = true; /*Block}
                        menu_users.Items[0].Visible = true; // Profile
                        menu_users.Items[7].Visible = true; // Message
                        menu_users.Items[8].Visible = true; // Invite
                        menu_users.Items[9].Visible = true; // Chat
                    }
                }
                // if (menu_users.Items.Cast<ToolStripMenuItem>().ToList().Any(p => p.Visible))
                    menu_users.Show(tree_users, e.Location);
            }
        }
        */