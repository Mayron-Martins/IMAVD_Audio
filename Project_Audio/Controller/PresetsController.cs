using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_Audio.Model;
using Project_Audio.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Project_Audio.Controller
{
    public class CommandAction
    {
        public string name { get; set; }
        public string action { get; set; }
    }

    public class PresetsController
    {
        private string pathPresets;

        private Presets view;
        public PresetsController(Presets view)
        {
            this.view = view;

            CreatePathPresets();
        }

        private void CreatePathPresets()
        {
            string pathPresets = Path.Combine(AppContext.BaseDirectory, "Presets");

            if (!Directory.Exists(pathPresets))
            {
                Directory.CreateDirectory(pathPresets);
            }

            this.pathPresets = pathPresets;
        }

        public void GenerateDefault(Dictionary<string, object[]> commandList, Dictionary<string, object[]> commandListPT)
        {
            string defaultPreset = Path.Combine(pathPresets, "Default.json");
            string defaultPresetPT = Path.Combine(pathPresets, "Default Portuguese.json");

            if (!File.Exists(defaultPreset) || !File.Exists(defaultPresetPT))
            {   
                JArray contentJson = new JArray();
                JArray contentJsonPT = new JArray();

                object[] shapes = { "Square", "Triangle", "Circle", "Face" };
                object[] shapesPT = { "Quadrado", "Triângulo", "Círculo", "Rosto" };

                int countMain = 0;
                int countSpecific = 0;
                int countShape = 0;

                Dictionary<string, object[]>.KeyCollection mainCommandPT = commandListPT.Keys;

                foreach (string mainCommand in commandList.Keys)
                {
                    object[] actionPT = commandListPT[mainCommandPT.ElementAt(countMain)];

                    if (mainCommand != "Create" && mainCommand != "Duplicate")
                    {
                        foreach (object action in commandList[mainCommand])
                        {
                            foreach (object shape in shapes)
                            {
                                JObject command = new JObject();
                                command["name"] = shape + " " + mainCommand + " " + action;
                                command["action"] = mainCommand + ";" + action + ";" + shape;

                                contentJson.Add(command);

                                JObject commandPT = new JObject();
                                commandPT["name"] = shapesPT[countShape] + " " + mainCommandPT.ElementAt(countMain) + " " + actionPT[countSpecific];

                                commandPT["action"] = mainCommand + ";" + action + ";" + shape;

                                contentJsonPT.Add(commandPT);
                                countShape++;
                            }
                            countSpecific++;
                            countShape = 0;
                        }
                    }
                    else
                    {
                        foreach (object action in commandList[mainCommand])
                        {

                            JObject command = new JObject();
                            command["name"] = mainCommand + " " + action;
                            command["action"] = mainCommand + ";" + action;

                            contentJson.Add(command);

                            JObject commandPT = new JObject();
                            commandPT["name"] = mainCommandPT.ElementAt(countMain) + " " + actionPT[countSpecific];

                            commandPT["action"] = mainCommand + ";" + action;

                            contentJsonPT.Add(commandPT);

                            countSpecific++;
                        }
                    }
                    countMain++;
                    countSpecific = 0;
                }

                string strContent = contentJson.ToString();
                string strContentPT = contentJsonPT.ToString();

                File.WriteAllText(defaultPreset, strContent);
                File.WriteAllText(defaultPresetPT, strContentPT);
            }

            UpdateList();
        }

        public void CreatePreset(string presetName)
        {
            if (!String.IsNullOrEmpty(presetName))
            {
                string preset = Path.Combine(pathPresets, presetName + ".json");
                if (!File.Exists(preset))
                {
                    File.WriteAllText(preset, "{}");

                    UpdateList();

                    SucessfullMessage("Success in saving new preset.");
                }
                else
                {
                    ErrorMensage("It is not possible to create a file with this name, it currently already exists.");
                }

            }
        }

        private void ErrorMensage(string message)
        {
            MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SucessfullMessage(string message)
        {
            MessageBox.Show(message, "Sucessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateList()
        {
            string[] presets = Directory.GetFiles(pathPresets);

            view.presetsList.Items.Clear();

            foreach (string file in presets)
            {
                view.presetsList.Items.Add(Path.GetFileNameWithoutExtension(file));
            }


            view.presetsList.SelectedItem = "Default";

        }

        public void UpdateTable()
        {
            string presetName = (view.presetsList.SelectedItem != null) ?
                view.presetsList.SelectedItem.ToString() : "";

            if (String.IsNullOrEmpty(presetName))
            {
                return;
            }

            string preset = Path.Combine(pathPresets, presetName + ".json");

            string contentJson = File.ReadAllText(preset);

            if (contentJson.Equals("{}"))
            {
                view.presetDetails.DataSource = new DataTable();
                return;
            }

            List<CommandAction> objectList = JsonConvert.DeserializeObject<List<CommandAction>>(contentJson);

            DataTable table = new DataTable();
            table.Columns.Add("Command");
            table.Columns.Add("Action");

            foreach (CommandAction obj in objectList)
            {
                table.Rows.Add(obj.name, obj.action);
            }

            view.presetDetails.DataSource = table;
        }



        public CommandAction GetCommand(DataGridViewCellEventArgs e)
        {
            CommandAction command = new CommandAction();

            if (!(e.RowIndex >= 0 && e.RowIndex < view.presetDetails.Rows.Count))
            {
                command.name = "";
                command.action = "";

                return command;
            }

            DataGridViewRow row = view.presetDetails.Rows[e.RowIndex];
            string name = row.Cells["Command"].Value.ToString();
            string action = row.Cells["Action"].Value.ToString();

            command.name = name;
            command.action = action;

            return command;
        }

        public void AddComand(string name, string action)
        {
            string pathPreset = GetPathPreset();
            if (string.IsNullOrEmpty(pathPreset))
            {
                ErrorMensage("Failed to locate preset folder.");
                return;
            }
            JArray contentJson = GetContentPreset();

            JObject command = new JObject();
            command["name"] = name;
            command["action"] = action;

            if (!contentJson.Equals("{}"))
            {
                bool commandExist = false;

                foreach (JObject obj in contentJson)
                {
                    if (obj["action"]?.ToString() == command["action"]?.ToString())
                    {
                        commandExist = true;
                        break;
                    }
                }

                if (commandExist)
                {
                    ErrorMensage("There is a command with these same actions in the selected preset.");
                    return;
                }
            }

            contentJson.Add(command);

            File.WriteAllText(pathPreset, contentJson.ToString());

            SucessfullMessage("Command successfully added.");

            UpdateTable();
        }

        public void UpdateCommand(string name, string action)
        {
            string pathPreset = GetPathPreset();
            if (string.IsNullOrEmpty(pathPreset))
            {
                ErrorMensage("Failed to locate preset folder.");
                return;
            }
            JArray contentJson = GetContentPreset();

            JObject command = new JObject();
            command["name"] = name;
            command["action"] = action;

            if (!contentJson.Equals("{}"))
            {
                bool commandExist = false;
                int commandIndex = -1;
                foreach (JObject obj in contentJson)
                {
                    commandIndex++;
                    if (obj["action"]?.ToString() == command["action"]?.ToString())
                    {
                        commandExist = true;
                        break;
                    }
                }

                if (!commandExist)
                {
                    ErrorMensage("The command could not be found so that it could be updated.");
                    return;
                }

                contentJson[commandIndex] = command;

                File.WriteAllText(pathPreset, contentJson.ToString());
                SucessfullMessage("Command successfully updated.");
                UpdateTable();
            }
        }

        private string GetPathPreset()
        {
            string presetName = (view.presetsList.SelectedItem != null) ?
                view.presetsList.SelectedItem.ToString() : "";

            if (String.IsNullOrEmpty(presetName))
            {
                return null;
            }

            string preset = Path.Combine(pathPresets, presetName + ".json");

            return preset;
        }

        private JArray GetContentPreset()
        {
            string preset = GetPathPreset();

            if (string.IsNullOrEmpty(preset))
            {
                return new JArray();
            }

            string contentJson = File.ReadAllText(preset);

            bool contentExist = !string.IsNullOrEmpty(contentJson) && !contentJson.Equals("{}");

            return (contentExist) ? JArray.Parse(contentJson) :
                new JArray();
        }

        public CommandAction RemoveCommand(CommandAction command)
        {
            
            
            if (string.IsNullOrEmpty(command.name))
            {
                return command;
            }

            DialogResult question = MessageBox.Show("Do you wish to remove the " + command.name + " command?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(question != DialogResult.Yes)
            {
                return command;
            }

            string pathPreset = GetPathPreset();
            if (string.IsNullOrEmpty(pathPreset))
            {
                ErrorMensage("Failed to locate preset folder.");
                return command;
            }
            JArray contentJson = GetContentPreset();

            if (contentJson.Equals("{}"))
            {
                return command;
            }

            bool commandExist = false;
            int commandIndex = -1;
            foreach (JObject obj in contentJson)
            {
                commandIndex++;
                if (obj["action"]?.ToString() == command.action)
                {
                    commandExist = true;
                    contentJson.RemoveAt(commandIndex);
                    break;
                }
            }

            if (!commandExist)
            {
                return command;
            }

            File.WriteAllText(pathPreset, contentJson.ToString());
            SucessfullMessage("Command successfully removed.");

            UpdateTable();

            return new CommandAction();

        }
    }
}
