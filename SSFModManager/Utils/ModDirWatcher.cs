using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Talifun.FileWatcher;

namespace SSFModManager
{
    public class ModDirWatcher
    {
        public static DirectoryInfo logDir;
        private static readonly object Lock = new object();
        public static IEnhancedFileSystemWatcher FSWatcher;
        public static List<Log> watching = new List<Log>();
        private MainForm MainForm;

        public void Init(MainForm mainForm)
        {
            logDir = mainForm.Game.GetModsDirs().First();
            FSWatcher = EnhancedFileSystemWatcherFactory.Instance.CreateEnhancedFileSystemWatcher(logDir.FullName, "*", 1000, false);
            FSWatcher.DirectoryCreatedEvent += OnDirectoryCreatedEvent;
            FSWatcher.DirectoryDeletedEvent += OnDirectoryDeletedEvent;
            FSWatcher.Start();
        }

        private void OnDirectoryDeletedEvent(object sender, DirectoryDeletedEventArgs e)
        {
            lock (Lock)
            {
                var modDir = new DirectoryInfo(e.FilePath);
                var mod = MainForm.Game.Mods.SingleOrDefault(m => m.Id == modDir.Name);
                if (mod != null)
                {
                    MainForm.Game.Mods.Remove(mod);
                    MainForm.InitModList();
                }
            }
        }

        private async void OnDirectoryCreatedEvent(object sender, DirectoryCreatedEventArgs e)
        {
            var modDir = new DirectoryInfo(e.FilePath);
            var mod = new SSF.Mod(modDir, MainForm.Game);
            await mod.UpdateModDetailsAsync(MainForm.webClient);
            MainForm.Game.Mods.Add(mod);
            MainForm.InitModList();
        }

        public static DirectoryInfo getLatestMod()
        {
            return logDir.GetDirectories().OrderByDescending(f => f.LastWriteTime).First();
        }

        public static string ReadLastLine(string path, Encoding encoding = null, string newline = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            if (newline == null) newline = Environment.NewLine;
            int charsize = encoding.GetByteCount(newline);
            byte[] buffer = encoding.GetBytes(newline);
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long endpos = stream.Length / charsize;
                for (long pos = charsize; pos < endpos; pos += charsize)
                {
                    stream.Seek(-pos, SeekOrigin.End);
                    stream.Read(buffer, 0, buffer.Length);
                    if (encoding.GetString(buffer) == newline)
                    {
                        buffer = new byte[stream.Length - stream.Position];
                        stream.Read(buffer, 0, buffer.Length);
                        return encoding.GetString(buffer);
                    }
                }
            }
            return null;
        }

        public void Dispose()
        {
            if (FSWatcher != null)
            {
                FSWatcher.DirectoryDeletedEvent -= OnDirectoryDeletedEvent;
                FSWatcher.DirectoryCreatedEvent -= OnDirectoryCreatedEvent;
                FSWatcher.Dispose();
            }
        }

        public class Log
        {
            public FileInfo File { get; set; }
            public string LastLine { get; set; }

            public Log(FileInfo file)
            {
                File = file;
            }
        }
    }
}