using Project_Audio.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Audio.View
{
    public partial class Presets : Form
    {
        public bool microphoneStatus;
        private LinkedList<Button> buttonList;
        private Dictionary<Button, Panel> panelList;
        private Principal principal;
        private PresetsController controller;
        public Presets(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
            this.controller = new PresetsController(this);

            microphoneStatus = false;
            presetsList.SelectedIndex = 0;
            buttonList = new LinkedList<Button> ();
            panelList = new Dictionary<Button, Panel>();

            buttonList.AddLast(addPreset);
            buttonList.AddLast(addComand);
            buttonList.AddLast(updateCommand);
            buttonList.AddLast(removeCommand);

            panelList.Add(addPreset, panelNewPreset);
            panelList.Add(addComand, panelCommands);
            panelList.Add(updateCommand, panelCommands);

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void addPreset_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Add Preset: Creates a new preset file without any commands.";
        }

        private void addPreset_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void addComand_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Add Voice Command: Creates a new command that directs to an action.";
        }

        private void addComand_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void updateCommand_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Update Command: Updates the action selected in the table.";
        }

        private void updateCommand_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void removeCommand_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Drop Command: Removes the selected action from the table.";
        }

        private void removeCommand_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void microphone_MouseEnter(object sender, EventArgs e)
        {
            description.Text = microphoneStatus ? "Microphone is activated" :
                "Microphone is disabled";
        }

        private void microphone_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void ActiveButton(Button button)
        {
            Color bg = button.BackColor;

            if(bg.Equals(Color.FromArgb(179, 179, 179)))
            {
                button.BackColor = Color.White;

                foreach (Button btn in buttonList)
                {
                    if(btn != button)
                    {
                        btn.BackColor = Color.FromArgb(179, 179, 179);
                        if (panelList.ContainsKey(btn)) panelList[btn].Enabled = false;
                    }
                }
                
            }
            else
            {
                button.BackColor = Color.FromArgb(179, 179, 179);
            }

            if (panelList.ContainsKey(button)) 
                panelList[button].Enabled = panelList[button].Enabled ? false : true;
        }

        private void addPreset_Click(object sender, EventArgs e)
        {
            ActiveButton(addPreset);
        }

        private void addComand_Click(object sender, EventArgs e)
        {
            ActiveButton(addComand);
        }

        private void updateCommand_Click(object sender, EventArgs e)
        {
            ActiveButton(updateCommand);
        }

        private void removeCommand_Click(object sender, EventArgs e)
        {
            ActiveButton(removeCommand);
        }

        private void microphone_Click(object sender, EventArgs e)
        {
            Image img = microphone.Image;

            bool status = CompareImages(microphone.Image, global::Project_Audio.Properties.Resources.audioOff);

            microphone.Image = status ? global::Project_Audio.Properties.Resources.audioOn : global::Project_Audio.Properties.Resources.audioOff;

            microphone.BackColor = status ? Color.White : Color.FromArgb(179, 179, 179);

            microphoneStatus = status;
        }

        private bool CompareImages(Image img1, Image img2)
        {
            using (Bitmap image1 = new Bitmap(img1))
            using (Bitmap image2 = new Bitmap(img2))
            {
                if (image1.Width != image2.Width || image1.Height != image2.Height)
                {
                    return false;
                }

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color pixel1 = image1.GetPixel(x, y);
                        Color pixel2 = image2.GetPixel(x, y);

                        if (pixel1 != pixel2)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void panelNewPreset_EnabledChanged(object sender, EventArgs e)
        {
            savePreset.Enabled = panelNewPreset.Enabled;
            savePreset.Visible = panelNewPreset.Enabled;
        }

        private void panelCommands_EnabledChanged(object sender, EventArgs e)
        {
            saveCommand.Enabled = panelCommands.Enabled;
            saveCommand.Visible = panelCommands.Enabled;
        }

        private void definePreset_Click(object sender, EventArgs e)
        {
            principal.actualPresets.Text = "Presets: "+presetsList.SelectedItem.ToString();
        }
    }
}
