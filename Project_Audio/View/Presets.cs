using Project_Audio.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Audio.View
{
    public partial class Presets : Form
    {
        private LinkedList<Button> buttonList;
        private Dictionary<Button, Panel> panelList;
        private Principal principal;
        private PresetsController controller;
        private Dictionary<string, object[]> commandAction;
        private Dictionary<string, object[]> commandActionPT;
        private CommandAction selectedCommand;
        public Presets(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
            this.controller = new PresetsController(this);
            buttonList = new LinkedList<Button> ();
            panelList = new Dictionary<Button, Panel>();

            buttonList.AddLast(addPreset);
            buttonList.AddLast(addComand);
            buttonList.AddLast(updateCommand);

            panelList.Add(addPreset, panelNewPreset);
            panelList.Add(addComand, panelCommands);
            panelList.Add(updateCommand, panelCommands);

            StartPosition = FormStartPosition.CenterScreen;

            commandAction = new Dictionary<string, object[]>
            {
                { "Rotate", new object[] { "Right", "Left", "Horizontal", "Vertical" } },
                { "Move to", new object[] { "Right", "Left", "Up", "Down" } },
                { "Resize", new object[] { "Grow", "Reduce" } },
                { "Color", new object[] { "Red", "Blue", "Green", "White", "Black", "Yellow", "Orange", "Brown", "Purple" } },
                { "Create", new object[] { "Square", "Triangle", "Circle", "Face" } },
                { "Duplicate", new object[] { "Square", "Triangle", "Circle", "Face" } }
            };

            commandActionPT = new Dictionary<string, object[]>
            {
                { "Rotacionar para", new object[] { "Direita", "Esquerda", "Horizontal", "Vertical" } },
                { "Mover para", new object[] { "Direita", "Esquerda", "Cima", "Baixo" } },
                { "Redimensionar para", new object[] { "Aumentar", "Reduzir" } },
                { "Cor", new object[] { "Vermelho", "Azul", "Verde", "Branco", "Preto", "Amarelo", "Laranja", "Marrom", "Roxo" } },
                { "Criar", new object[] { "Quadrado", "Triângulo", "Círculo", "Rosto" } },
                { "Duplicar", new object[] { "Quadrado", "Triângulo", "Círculo", "Rosto" } }
            };

            controller.GenerateDefault(commandAction, commandActionPT);
            
            selectedCommand = new CommandAction();
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

        private void automaticCommands_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Automatic Commands: Generate a list of commands for automatic execution of actions when called.";
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
            {
                panelList[button].Enabled = panelList[button].Enabled ? false : true;
            }

            bool enableActions = (updateCommand.BackColor == Color.White) ?
                false : true;
            mainAction.Enabled = enableActions;
            specificAction.Enabled = enableActions;
            diretiveAction.Enabled = enableActions;

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
           selectedCommand = controller.RemoveCommand(selectedCommand);
        }

        private void automaticCommands_Click(object sender, EventArgs e)
        {
            Automatic automatic = new Automatic(this);
            automatic.Show();
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

            principal.defaultPreset = presetsList.SelectedItem.ToString();
        }

        private void mainAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectValue = mainAction.SelectedItem.ToString();

            specificAction.Items.Clear();

            specificAction.Items.AddRange(commandAction[selectValue]);
            
            if(selectValue != "Create" && selectValue != "Duplicate")
            {
                diretiveAction.Visible = true;
                diretiveAction.Enabled = true;
            }
            else
            {
                diretiveAction.Visible = false;
                diretiveAction.Enabled = false;
            }
            
        }

        private void savePreset_Click(object sender, EventArgs e)
        {
            controller.CreatePreset(presetName.Text);
            
        }

        private void presetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.UpdateTable();
        }

        private void presetDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CommandAction command = controller.GetCommand(e);

            if (string.IsNullOrEmpty(command.name))
            {
                return;
            }

            commandName.Text = command.name;

            string[] actions = command.action.Split(';');

            string main = actions[0];
            string specific = actions[1];
            string diretive = (actions.Length == 3) ? actions[2] : "";

            mainAction.SelectedItem = main;
            specificAction.SelectedItem = specific;
            if (!string.IsNullOrEmpty(diretive))
            {
                diretiveAction.SelectedItem = diretive;
            }

            selectedCommand = command;
        }

        private void saveCommand_Click(object sender, EventArgs e)
        {
            string name = commandName.Text;

            string main = (mainAction.SelectedItem != null) ?
            mainAction.SelectedItem.ToString() : "";
            string specific = (specificAction.SelectedItem != null) ? specificAction.SelectedItem.ToString() : "";
            string diretive = (diretiveAction.SelectedItem != null) ? diretiveAction.SelectedItem.ToString() : "";

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(main)
                || string.IsNullOrEmpty(specific))
            {
                return;
            }

            string action = main + ";" + specific;

            if(main != "Duplicate" && main != "Create")
            {
                if (string.IsNullOrEmpty(diretive))
                {
                    return;
                }

                action += ";" + diretive;
            }

            if(addComand.BackColor == Color.White)
            {
                controller.AddComand(name, action);
            }
            else
            {
                controller.UpdateCommand(name, action);
            }

            presetsList.SelectedItem = presetsList.SelectedItem;
        }

        public bool getMicrophoneStatus()
        {
            return principal.microphoneStatus;
        }

        public string getDefaultPreset()
        {
            return principal.defaultPreset;
        }

        public string getDefaultLanguage()
        {
            return principal.defaultLanguage;
        }
    }
}
