using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using VRCModManager.Dependencies;
using Microsoft.Win32;

namespace SSFModManager.Setup
{
    public class PathLogic
    {
        public DirectoryInfo GetInstallationPath()
        {
            var steam = GetSteamLocation();
            if (steam != null) {
                if (steam.Exists) {
                    if (steam.CombineFile(SSF.Game.AppFileName).Exists) {
                        return steam;
                    }
                }
            }

            var local = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            if (local.CombineFile(SSF.Game.AppFileName).Exists) {
                return local;
            }

            var fallback = GetFallbackDirectory();
            return fallback;
        }
        private DirectoryInfo GetFallbackDirectory()
        {
            bool folder = false;
            MessageBoxManager.Yes = "Browse exe";
            MessageBoxManager.No = "Browse dir";
            MessageBoxManager.Register();
            var result = MessageBox.Show("We couldn't seem to find your Serious Sam Fusion installation, please show us where it is located.", "Error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            MessageBoxManager.Unregister();
            if (result == DialogResult.Cancel)
                Application.Exit();
            else if (result == DialogResult.No) folder = true;
            return NotFoundHandler(folder);
        }
        private DirectoryInfo GetSteamLocation()
        {
            try {
                var steamFinder = new SteamFinder();
                if (!steamFinder.FindSteam())
                    return null;
                return new DirectoryInfo(steamFinder.FindGameFolder(SSF.Game.SteamAppId));
            } catch (Exception ex) {
                return null;
            }
        }
        /* Logger.Warn("Game not found, setup required!");
            var confirmResult = MessageBox.Show("VRChat.exe was not found in the same directory as this launcher.\n\nHowever it needs to be in the same folder to work properly, please select your game to move this launcher next to it and restart.", "Game not found!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Cancel) Application.Exit();
            var gameSelector = new OpenFileDialog();
            gameSelector.Title = "Select the VRChat.exe file";
            gameSelector.InitialDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\VRChat";
            gameSelector.Filter = "VRChat Executable|VRChat.exe|All Executables|*.exe";
            if (gameSelector.ShowDialog() == DialogResult.OK)
            {
                var Game = new FileInfo(gameSelector.FileName);
                var Launcher = Utils.Utils.getOwnPath();
                var newPath = new FileInfo(Path.Combine(Game.DirectoryName, Launcher.Name));
                Launcher.CopyTo(newPath.FullName);
                Utils.Utils.StartProcess(newPath, "--vrclauncher.keep", Launcher.FullName.Quote());
            }
            Utils.Utils.Exit();
        }
        */
        private DirectoryInfo NotFoundHandler(bool folder)
        {
            var found = string.Empty;
            while (found == string.Empty)
            {
                if (folder) found = FindFolder();
                else found = FindFile();
            }
            return found == string.Empty ? null : new DirectoryInfo(found);
        }
        public string FindFile()
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = $"Select the {SSF.Game.AppFileName} file";
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                fileDialog.Filter = "Serious Sam Fusion Executables|Sam2017*.exe|All Executables|*.exe";
                fileDialog.Multiselect = false;
                var result = fileDialog.ShowDialog();
                if (result == DialogResult.Cancel) { Application.Exit(); }
                else if (result == DialogResult.OK)
                {
                    var path = new FileInfo(fileDialog.FileName);
                    if (File.Exists(Path.Combine(path.DirectoryName, SSF.Game.AppFileName)))
                    {
                        return path.DirectoryName;
                    }
                    else
                    {
                        MessageBox.Show($"The directory you selected doesn't contain {SSF.Game.AppFileName}! please try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return string.Empty;
            }
        }
        public string FindFolder()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = $"Select the folder in which {SSF.Game.AppFileName} is located.";
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderDialog.ShowNewFolderButton = false;
                var result = folderDialog.ShowDialog();
                    if (result == DialogResult.Cancel) { Application.Exit(); }
                    else if (result == DialogResult.OK)
                    {
                        string path = folderDialog.SelectedPath;
                        if (File.Exists(Path.Combine(path, SSF.Game.AppFileName)))
                        {
                            return folderDialog.SelectedPath;
                        }
                        else
                        {
                            MessageBox.Show($"The directory you selected doesn't contain {SSF.Game.AppFileName}! please try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
            return string.Empty;
        }
    }
}
