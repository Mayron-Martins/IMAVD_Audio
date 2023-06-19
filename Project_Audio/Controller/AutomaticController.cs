using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_Audio.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Audio.Controller
{
    public class AutomaticController
    {
        private Automatic view;
        private string pathCommands;
        private List<CommandAction> commandList;

        public AutomaticController(Automatic view)
        {
            this.view = view;
            CreatePathAutomaticCommands();
            commandList = new List<CommandAction>();
            DefineCommandList();
        }

        private void CreatePathAutomaticCommands()
        {
            string pathCommands = Path.Combine(AppContext.BaseDirectory, "Automatic Commands");

            if (!Directory.Exists(pathCommands))
            {
                Directory.CreateDirectory(pathCommands);
            }

            this.pathCommands = pathCommands;
        }

        private string GetPathCommandList()
        {
            string listName = (view.existingCommands.SelectedItem != null) ?
                view.existingCommands.SelectedItem.ToString() : "";

            if (String.IsNullOrEmpty(listName))
            {
                return null;
            }

            string command = Path.Combine(pathCommands, listName + ".json");

            return command;
        }
        public void saveAutomaticCommandList(string nameList, string commands)
        {
            if (string.IsNullOrEmpty(commands) || string.IsNullOrEmpty(nameList))
            {
                ErrorMensage("There are no actions to be saved in the list.");
                return;
            }

            string commandList = Path.Combine(pathCommands, nameList + ".json");
            //if (!File.Exists(commandList))
            //{
            JArray contentJson = new JArray();

            string[] actions = commands.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string action in actions)
            {
                JObject command = new JObject();
                command["action"] = action;

                contentJson.Add(command);
            }

            File.WriteAllText(commandList, contentJson.ToString());

            UpdateList();

            SucessfullMessage("Success when saving new automatic list.");
            //}
            //else
            //{
            //    ErrorMensage("It is not possible to create a file with this name, it currently already exists.");
            //}
        }

        public void UpdateList()
        {
            string[] presets = Directory.GetFiles(pathCommands);

            if (presets.Length == 0)
            {
                return;
            }

            view.existingCommands.Items.Clear();

            foreach (string file in presets)
            {
                view.existingCommands.Items.Add(Path.GetFileNameWithoutExtension(file));
            }


            view.existingCommands.SelectedIndex = 0;
        }

        public void UpdateCommandsPanel()
        {
            if (view.existingCommands.SelectedItem == null)
            {
                return;
            }
            JArray contentJson = GetContentCommandList();

            string contentpanel = "";

            foreach (JObject obj in contentJson)
            {
                contentpanel += obj["action"]?.ToString() + Environment.NewLine;
            }

            view.listCommands.Text = contentpanel;
            view.listName.Text = view.existingCommands.SelectedItem.ToString();
        }

        private JArray GetContentCommandList()
        {
            string commandList = GetPathCommandList();

            if (string.IsNullOrEmpty(commandList))
            {
                return new JArray();
            }

            string contentJson = File.ReadAllText(commandList);

            bool contentExist = !string.IsNullOrEmpty(contentJson) && !contentJson.Equals("{}");

            return (contentExist) ? JArray.Parse(contentJson) :
                new JArray();
        }

        public void RemoveCommandList(string listName)
        {

            DialogResult question = MessageBox.Show("Do you wish to remove the " + listName + " list?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (question != DialogResult.Yes)
            {
                return;
            }

            if (string.IsNullOrEmpty(listName))
            {
                return;
            }
            string commandList = Path.Combine(pathCommands, listName + ".json");

            if (!File.Exists(commandList))
            {
                File.Delete(commandList);
            }
        }


        public async Task<string> AddCommand(string contentPanel)
        {
            string language = view.getDefaultLanguage();
            bool microphoneStatus = view.getMicrophoneStatus();
            RecognitionVoiceController reconizeVoice = new RecognitionVoiceController();

            string captureVoice = await reconizeVoice.ConvertVoiceToText(language, microphoneStatus);

            if (string.IsNullOrEmpty(captureVoice))
            {
                return contentPanel;
            }

            captureVoice = captureVoice.Replace(".", "").Replace(",", "");


            bool existCommand = false;
            string actualAction = "";

            foreach (CommandAction command in commandList)
            {
                if (NormalizeString(command.name) == NormalizeString(captureVoice))
                {
                    existCommand = true;
                    actualAction = command.action;
                    break;
                }
            }

            if (!existCommand)
            {
                return contentPanel;
            }

            contentPanel += actualAction + Environment.NewLine;

            return contentPanel;
        }

        private string NormalizeString(string str)
        {
            str = str.ToLower();
            string normalize = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalize)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString();
        }

        private void DefineCommandList()
        {
            string presetName = view.getDefaultPreset();
            string pathPresets = Path.Combine(AppContext.BaseDirectory, "Presets");

            string preset = Path.Combine(pathPresets, presetName + ".json");

            string contentJson = File.ReadAllText(preset);

            if (contentJson.Equals("{}"))
            {
                return;
            }

            commandList = JsonConvert.DeserializeObject<List<CommandAction>>(contentJson);
        }

        private void ErrorMensage(string message)
        {
            MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SucessfullMessage(string message)
        {
            MessageBox.Show(message, "Sucessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
