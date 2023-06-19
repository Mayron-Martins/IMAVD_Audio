using Project_Audio.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Audio.View
{
    public partial class Automatic : Form
    {
        private Presets presets;
        private AutomaticController controller;
        public Automatic(Presets presets)
        {
            InitializeComponent();
            this.presets = presets;
            controller = new AutomaticController(this);
            StartPosition = FormStartPosition.CenterScreen;

            controller.UpdateList();
        }

        private async void commandVoice_Click(object sender, EventArgs e)
        {
            bool active = ActiveVoiceCommands();

            if (active)
            {
                listCommands.Text = await controller.AddCommand(listCommands.Text);
                ActiveVoiceCommands();
            }
        }

        public bool ActiveVoiceCommands()
        {
            Color bg = commandVoice.BackColor;

            if (bg.Equals(Color.FromArgb(179, 179, 179)))
            {
                commandVoice.BackColor = Color.White;
                return true;
            }
            else
            {
                commandVoice.BackColor = Color.FromArgb(179, 179, 179);
                return false;
            }
        }

        private void commandVoice_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Voice Commands";
        }

        private void commandVoice_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void saveList_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Save List Commands";
        }

        private void saveList_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void saveList_Click(object sender, EventArgs e)
        {
            controller.saveAutomaticCommandList(listName.Text, listCommands.Text);
        }

        private void deleteList_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Remove Automatic List";
        }

        private void deleteList_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void deleteList_Click(object sender, EventArgs e)
        {
            string listName = (existingCommands.SelectedItem != null) ?
                existingCommands.SelectedItem.ToString() : "";
            controller.RemoveCommandList(listName);
        }

        public bool getMicrophoneStatus()
        {
            return presets.getMicrophoneStatus();
        }

        public string getDefaultPreset()
        {
            return presets.getDefaultPreset();
        }

        public string getDefaultLanguage()
        {
            return presets.getDefaultLanguage();
        }

        private void existingCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.UpdateCommandsPanel();
        }

        private void cleanContent_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Clean All Content";
        }

        private void cleanContent_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void cleanContent_Click(object sender, EventArgs e)
        {
            listName.Text = "";
            listCommands.Text = "";
        }
    }
}
