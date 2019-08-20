using System;
using System.Data;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Http;

using SteamSharp;

namespace SSFModManager
{
    public partial class MainForm : Form
    {
        private SSF.Game game;
        // public SteamClient steam;
        private HttpClient webClient;
        private void PreInit()
        {
            var path = new Setup.PathLogic();
            var binPath = path.GetInstallationPath();
            if (!binPath.Exists) {
                MessageBox.Show("Sorry the game wasn't found, exiting.."); Application.Exit();
            }
            game = new SSF.Game(binPath.Parent.Parent);
        }
        public MainForm()
        {
            PreInit();
            InitializeComponent();
            Init();
        }

        private void Init() {
            webClient = new HttpClient();
            // steam = new SteamClient();
            // steam.Timeout = 5;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine(game.Mods.Where(t => t.Disabled).ToJson());
            txt_brief.Text = game.ToJson();
            InitModList();
        }

        private void InitModList()
        {
            lst_mods.DataSource = game.Mods;
            return;
            foreach (var mod in game.Mods) {
                lst_mods.Items.Add(mod);
            }
        }

        private void Menu_mods_Opening(object sender, CancelEventArgs e)
        {
            if (lst_mods.SelectedItems.Count < 1) { e.Cancel = true; return; }
            var mod = (SSF.Mod)lst_mods.SelectedItems[0];
            if (mod == null) { e.Cancel = true; return; }
            menu_mods.Items[1].Text = mod.Disabled ? "Enable" : "Disable";
        }

        private void Lst_mods_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mod = (SSF.Mod)lst_mods.SelectedItems[0];
            txt_brief.Text = mod.ToJson();
        }

        private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            var mod = (SSF.Mod)lst_mods.SelectedItems[0];
            if (mod == null) return;
            Utils.OpenFolderInExplorer(mod.Directory);
        }

        private async void DisableToolStripMenuItem_Click(object sender, EventArgs e) {
            var mod = (SSF.Mod)lst_mods.SelectedItems[0];
            var details = await mod.UpdateModDetailsAsync(webClient);
            Console.WriteLine(details.ToJson());
            Console.WriteLine(mod.ToJson());
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