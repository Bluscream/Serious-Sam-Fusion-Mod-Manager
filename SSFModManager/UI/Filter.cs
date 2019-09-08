using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSFModManager
{
    public partial class MainForm {
        private void FilterMenuItem_Click(object sender, EventArgs e) => SwitchFilter((ToolStripMenuItem)sender);
        private void SwitchFilter(ToolStripMenuItem selectedMenuItem) {
            if (selectedMenuItem.Name == "searchInEverything") {
                foreach (var ltoolStripMenuItem in from object item in selectedMenuItem.Owner.Items 
                        let ltoolStripMenuItem = item as ToolStripMenuItem where ltoolStripMenuItem != null select ltoolStripMenuItem)
                    ltoolStripMenuItem.Checked = true;
            } else {
                selectedMenuItem.Checked = true;
                foreach (var ltoolStripMenuItem in from object item in selectedMenuItem.Owner.Items 
                        let ltoolStripMenuItem = item as ToolStripMenuItem
                        where ltoolStripMenuItem != null 
                        where !item.Equals(selectedMenuItem) 
                        select ltoolStripMenuItem)
                    ltoolStripMenuItem.Checked = false;
            }
            selectedMenuItem.Owner.Show();
        }

        private void Txt_mods_filter_TextChanged(object sender, EventArgs e) => FilterByText();
        private async void FilterByText()
        {
            var txt = txt_mods_filter.Text.ToLowerInvariant();
            List<SSF.Mod> matchingMods = new List<SSF.Mod>();
            if (!txt.IsNullOrEmpty()) {
                if (searchInEverything.Checked) matchingMods.AddRange(modsInCategory.Where(m => m.ToJson().ToLowerInvariant().Contains(txt)).ToList());
                else if (searchInNames.Checked) matchingMods.AddRange(modsInCategory.Where(m => m.Name.ToLowerInvariant().Contains(txt)).ToList());
                else if (searchInDescriptions.Checked) {
                    foreach (var mod in modsInCategory) {
                        if (mod.Details is null) await mod.UpdateModDetailsAsync(webClient);
                        if (mod.Details != null && mod.Details.description != null && mod.Details.description.ToLowerInvariant().Contains(txt)) matchingMods.Add(mod);
                    }
                }
            } else { matchingMods.AddRange(modsInCategory); }
            FillModList(matchingMods);
        }
    }
}
