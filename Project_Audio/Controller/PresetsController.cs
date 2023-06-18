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
                                command["action"] = mainCommand + " " + action + " " + shape;

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
                                command["action"] = mainCommand + " " + action;

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

        private class CommandAction
        {
            public string name { get; set; }
            public string action { get; set; }
        }
    }
}
