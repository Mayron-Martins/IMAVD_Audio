using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Audio
{
    public partial class Principal : Form
    {
        public bool microphoneStatus;
        public Image originalImage;
        public Principal()
        {
            InitializeComponent();
            microphoneStatus = false;
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
            description.Text = "Text to Speech";
        }

        private void textToSpeech_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void speechToText_MouseEnter(object sender, EventArgs e)
        {
            description.Text = "Speech to Text";
        }

        private void speechToText_MouseLeave(object sender, EventArgs e)
        {
            description.Text = "";
        }

        private void textToSpeech_Click(object sender, EventArgs e)
        {
            ActiveButton(textToSpeech, speechToText);
        }

        private void speechToText_Click(object sender, EventArgs e)
        {
            ActiveButton(speechToText, textToSpeech);
        }

        private void ActiveButton(Button button, Button otherButton)
        {
            Color bg = button.BackColor;

            if (bg.Equals(Color.FromArgb(179, 179, 179)))
            {
                button.BackColor = Color.White;
                otherButton.BackColor = Color.FromArgb(179, 179, 179);
            }
            else
            {
                button.BackColor = Color.FromArgb(179, 179, 179);
            }

            panelTextInteraction.Enabled =
                (button.BackColor == otherButton.BackColor) ? false : true;
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
                    originalImage = Image.FromFile(selectedFilePath);
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
    }
}
