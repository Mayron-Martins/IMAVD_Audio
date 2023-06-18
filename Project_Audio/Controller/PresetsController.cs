using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_Audio.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public PresetsController(Presets view) {
            this.view = view;

            createPathPresets();
        }

        private void createPathPresets()
        {
            string pathPresets = Path.Combine(AppContext.BaseDirectory, "Presets");

            if (!Directory.Exists(pathPresets))
            {
                Directory.CreateDirectory(pathPresets);
            }

            this.pathPresets = pathPresets;
        }

        public void generateDefault(Dictionary<string, object[]> commandList)
        {
            string defaultPreset = Path.Combine(pathPresets, "Default.json");

            if (!File.Exists(defaultPreset))
            {
                JArray contentJson = new JArray();

                object[] shapes = { "Square", "Triangle", "Circle", "Face" }; 

                foreach(string mainCommand in commandList.Keys)
                {
                    if(mainCommand != "Create" && mainCommand != "Duplicate")
                    {
                        foreach(object action in commandList[mainCommand])
                        {
                            foreach(object shape in shapes){
                                JObject command = new JObject();
                                command["name"] = shape + " " + mainCommand + " " + action;
                                command["action"] = mainCommand + ";" + action + ";" + shape;

                                contentJson.Add(command);
                            }
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
                        }
                    }
                }

                string strContent = contentJson.ToString();
                File.WriteAllText(defaultPreset, strContent);
            }

            updateList();
        }

        public void createPreset(string presetName)
        {
            if (!String.IsNullOrEmpty(presetName))
            {
                string preset = Path.Combine(pathPresets, presetName+".json");
                if (!File.Exists(preset))
                {
                    File.WriteAllText(preset, "{}");

                    updateList();

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

        private void updateList()
        {
            string[] presets = Directory.GetFiles(pathPresets);

            view.presetsList.Items.Clear();

            foreach (string file in presets)
            {
                view.presetsList.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
            

            view.presetsList.SelectedItem = "Default";
            
        }

        public void updateTable()
        {
            string presetName = view.presetsList.SelectedItem.ToString();

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

            foreach(CommandAction obj in objectList)
            {
                table.Rows.Add(obj.name, obj.action);
            }

            view.presetDetails.DataSource = table;
        }

        

        public CommandAction getCommand(DataGridViewCellEventArgs e)
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

        public void addComand(string name, string action)
        {
            string pathPreset = getPathPreset();
            if (string.IsNullOrEmpty(pathPreset))
            {
                ErrorMensage("Failed to locate preset folder.");
                return;
            }
            JArray contentJson = getContentPreset();

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
        }

        public void updateCommand(string name, string action)
        {
            string pathPreset = getPathPreset();
            if (string.IsNullOrEmpty(pathPreset))
            {
                ErrorMensage("Failed to locate preset folder.");
                return;
            }
            JArray contentJson = getContentPreset();

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
            }
        }

        private string getPathPreset()
        {
            string presetName = view.presetsList.SelectedItem.ToString();

            if (String.IsNullOrEmpty(presetName))
            {
                return null;
            }

            string preset = Path.Combine(pathPresets, presetName + ".json");

            return preset;
        }

        private JArray getContentPreset()
        {
            string preset = getPathPreset();

            if (string.IsNullOrEmpty(preset))
            {
                return new JArray();
            }

            string contentJson = File.ReadAllText(preset);

            bool contentExist = !string.IsNullOrEmpty(contentJson) && !contentJson.Equals("{}");

            return (contentExist) ? JArray.Parse(contentJson) :
                new JArray(); 
        }
    }
}
