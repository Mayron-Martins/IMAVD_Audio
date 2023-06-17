using Project_Audio.Controller;
using Project_Audio.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Audio
{
    public partial class Principal : Form
    {
        private PrincipalController controller;
        public bool microphoneStatus;
        public LinkedList<Image> imageStack;
        public Principal()
        {
            InitializeComponent();
            controller = new PrincipalController(this);
            microphoneStatus = false;
            imageStack = new LinkedList<Image>();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void openFile_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Open File Audio Or Image";
        }

        private void openFile_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void textToSpeech_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Text to Speech: Performs the conversion of typed text.";
        }

        private void textToSpeech_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void speechToText_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Speech to Text: Performs the conversion of audio captured by the microphone or from a file.";
        }

        private void speechToText_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void textToSpeech_Click(object sender, EventArgs e)
        {
            ActiveButton(textToSpeech, speechToText, voiceCommands);
        }

        private void speechToText_Click(object sender, EventArgs e)
        {
            ActiveButton(speechToText, textToSpeech, voiceCommands);
        }

        private void ActiveButton(Button button, Button otherButton1, Button otherButton2)
        {
            Color bg = button.BackColor;

            if (bg.Equals(Color.FromArgb(179, 179, 179)))
            {
                button.BackColor = Color.White;
                otherButton1.BackColor = Color.FromArgb(179, 179, 179);
                otherButton2.BackColor = Color.FromArgb(179, 179, 179);
            }
            else
            {
                button.BackColor = Color.FromArgb(179, 179, 179);
            }

            panelTextInteraction.Enabled =
                (textToSpeech.BackColor == speechToText.BackColor) ? false : true;
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

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select an Audio or Image File";
            fileDialog.Filter = "Arquivos de Áudio|*.wav;*.mp3;*.ogg|Arquivos de Imagem|*.jpg;*.png;*.gif";

            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = fileDialog.FileName;
                string fileExtension = System.IO.Path.GetExtension(selectedFilePath);

                string[] audioExtensions = { ".wav", ".mp3", ".ogg" };
                bool fileTypeAudio = (Array.IndexOf(audioExtensions, 
                    fileExtension.ToLower()) != -1);

                if (fileTypeAudio)
                {
                    //Armazenar no arquivo de áudio correspondente
                    pathAudioFile.Text = selectedFilePath;
                }
                else
                {
                    imageStack.AddLast(Image.FromFile(selectedFilePath));
                }
            }
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

        private void geometricShapes_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Generate Geometric Shapes: Inserts the shapes generated according to random creation, automatically resizing according to quantity.";
        }

        private void geometricShapes_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void voiceCommands_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Voice Commands: Speak the corresponding command to perform an action with the objects on the screen.";
        }

        private void voiceCommands_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void peoplesFaces_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Generate People's Faces: Inserts the faces on the screen according to selected images or using the defaults.";
        }

        private void peoplesFaces_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void listPresets_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Presets List: Create lists of commands and interactions to be executed with the objects on the canvas.";
        }

        private void listPresets_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void trashImages_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Clean Images Panel";
        }

        private void cleanImages_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void voiceCommands_Click(object sender, EventArgs e)
        {
            ActiveButton(voiceCommands, textToSpeech, speechToText);
        }

        private void listPresets_Click(object sender, EventArgs e)
        {
            Presets presets = new Presets(this);
            presets.Show();
        }
    }
}
