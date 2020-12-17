using MMR.Randomizer.Models.Settings;
using MMR.Randomizer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace MMR.UI.Forms
{
    public partial class RandomSettingsForm : Form
    {
        public string[] RANDOM_SETTINGS_POOL = new string[]
        {
            // Item Pool Options
            "Exclude Song of Soaring",
            "Dungeon Items",
            "Shop Items",
            "Caught bottle contents",
            "Cow Milk",
            "Skulltula Tokens",
            "Mundane Rewards",
            "Moon Items",
            "Great Fairy Rewards",
            "Everything Else",
            "Pre-Clocktown Deku Nut",
            "Crazy Starting Items",
            "Stray Fairies",
            // Other Customizations
            "Dungeon Entrances",
            "Mix songs with items",
            "Progressive Upgrades",
            "No Starting Items",
            "Enemies",
            // Gimmicks
            "Damage mode",
            "Damage effects",
            "Movement",
            "Floor types",
            "Clock speed",
            "Blast Mask Cooldown",
            "Ice Trap amount",
            "Ice Trap appearance",
            "Hide Clock UI",
            "Underwater Ocarina",
            "Enable Sun's Song",
            "Allow Fierce Diety's Mask anywhere",
            "BYO Ammo",
            "Death is Moon Crash",
            "Continuous Deku Hopping",
            "Enable Ice Trap Quirks",
            // Speed Ups
            "Skip Younger Beaver",
            "Faster Lab Fish",
            "Faster Bank",
            "Good Dampe RNG",
            "Good Dog Race RNG",
            // Comfort Options
            "Disable crit wiggle",
            "Shorten cutscenes",
            "Quick text",
            "Increase push speed",
            "Close Cows",
            "Update shops",
            "Update chests",
            "Update world models",
            "No downgrades",
            "Fix Epona sword",
            "Quest item extra storage",
            "Arrow cycling",
            "Elegy speedups",
            // Hint Distribution
            "Hint Distribution",
            "Free hints",
            "Clear Hints",
            // Cosmetic Customization
            "Player Model",
        };

        bool updating = false;

        public List<int> CustomRandomSettingsList { get; private set; } = new List<int>();
        public string CustomRandomSettingsString { get; private set; }

        public RandomSettingsForm()
        {
            InitializeComponent();

            for (int i = 0; i < RANDOM_SETTINGS_POOL.Length; i++)
            {
                lSettings.Items.Add(RANDOM_SETTINGS_POOL[i]);
            }
            if (CustomRandomSettingsList != null)
            {
                UpdateString(CustomRandomSettingsList);
            }
            else
            {
                tSetting.Text = "-----------";
            }

        }

        private void UpdateString(List<int> selections)
        {
            int[] n = new int[13];
            string[] ns = new string[13];
            for (int i = 0; i < selections.Count; i++)
            {
                int j = selections[i] / 32;
                int k = selections[i] % 32;
                n[j] |= (int)(1 << k);
                ns[j] = Convert.ToString(n[j], 16);
            }
            tSetting.Text = ns[12] + "-" + ns[11] + "-" + ns[10] + "-" + ns[9] + "-" + ns[8] + "-" + ns[7] + "-" + ns[6] + "-" + ns[5] + "-" + ns[4] + "-"
                + ns[3] + "-" + ns[2] + "-" + ns[1] + "-" + ns[0];
            CustomRandomSettingsString = tSetting.Text;
        }

        public void UpdateChecks(string c)
        {
            updating = true;
            try
            {
                tSetting.Text = c;
                CustomRandomSettingsString = c;
                CustomRandomSettingsList.Clear();
                string[] v = c.Split('-');
                int[] vi = new int[13];
                if (v.Length != vi.Length)
                {
                    CustomRandomSettingsList.Add(-1);
                    return;
                }
                for (int i = 0; i < 13; i++)
                {
                    if (v[12 - i] != "")
                    {
                        vi[i] = Convert.ToInt32(v[12 - i], 16);
                    }
                }
                for (int i = 0; i < 32 * 13; i++)
                {
                    int j = i / 32;
                    int k = i % 32;
                    if (((vi[j] >> k) & 1) > 0)
                    {
                        if (i >= ItemUtils.AllLocations().Count())
                        {
                            throw new IndexOutOfRangeException();
                        }
                        CustomRandomSettingsList.Add(i);
                    }
                }
                foreach (ListViewItem l in lSettings.Items)
                {
                    if (CustomRandomSettingsList.Contains(l.Index))
                    {
                        l.Checked = true;
                    }
                    else
                    {
                        l.Checked = false;
                    }
                }
            }
            catch
            {
                CustomRandomSettingsList.Clear();
                CustomRandomSettingsList.Add(-1);
            }
            finally
            {
                updating = false;
            }
        }

        private void tSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                UpdateChecks(tSetting.Text);
            }
        }
        
        private void lSettings_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (updating)
            {
                return;
            }
            updating = true;
            if (e.Item.Checked)
            {
                CustomRandomSettingsList.Add(e.Item.Index);
            }
            else
            {
                CustomRandomSettingsList.Remove(e.Item.Index);
            }
            UpdateString(CustomRandomSettingsList);
            updating = false;
        }

        private void fItemEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
