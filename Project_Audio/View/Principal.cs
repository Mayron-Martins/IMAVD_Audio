using Project_Audio.Controller;
using Project_Audio.View;
using Project_Audio.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Linq;

namespace Project_Audio
{

    public partial class Principal : Form
    {
        private PrincipalController controller;
        public bool microphoneStatus;
        public LinkedList<Face> imageStack;
        public LinkedList<Face> faces;
        private int positionInterator;
        private List<ShapeType> randomShape;
        public LinkedList<Shape> shapes;
        private List<Point> point;
        private List<Point> positions;
        private Presets presets;
        Shape shape = new Shape();
        public string shapeOnPicture = "Shape";
        public string defaultLanguage = "en-US";
        public Principal()
        {
            InitializeComponent();
            controller = new PrincipalController(this);
            microphoneStatus = false;
            imageStack = new LinkedList<Face>();
            StartPosition = FormStartPosition.CenterScreen;
            positionInterator = 0;
            randomShape = new List<ShapeType>();
            shapes = new LinkedList<Shape>();
            faces = new LinkedList<Face>();
            point = GetAvailablePositions();
            presets = new Presets(this);
            actualPresets.Text = "Presets: Default";
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

        private async void speechToText_Click(object sender, EventArgs e)
        {
            bool active = ActiveButton(speechToText, textToSpeech, voiceCommands);
            if (!active)
            {
                return;
            }
            string audioFilePath = pathAudioFile.Text;
            string textoConvertido = string.Empty;

            if (microphoneStatus)
            {
                // Converter a fala em texto
                textoConvertido = await controller.ConverterFalaEmTexto();
            }
            else if (!string.IsNullOrEmpty(audioFilePath))
            {
                // Converter o arquivo de áudio em texto
                textoConvertido = await controller.ConverterAudioEmTextoAsync(audioFilePath);
            }

            // Exibir o texto traduzido na TextBox
            generatedText.Text = textoConvertido;

            ActiveButton(speechToText, textToSpeech, voiceCommands);
        }

        private bool ActiveButton(Button button, Button otherButton1, Button otherButton2)
        {
            bool active = false;
            Color bg = button.BackColor;

            if (bg.Equals(Color.FromArgb(179, 179, 179)))
            {
                button.BackColor = Color.White;
                otherButton1.BackColor = Color.FromArgb(179, 179, 179);
                otherButton2.BackColor = Color.FromArgb(179, 179, 179);

                active = true;
            }
            else
            {
                button.BackColor = Color.FromArgb(179, 179, 179);
                active = false;
            }

            panelTextInteraction.Enabled =
                (textToSpeech.BackColor == speechToText.BackColor) ? false : true;

            generateAudio.Enabled = (textToSpeech.BackColor == Color.White) ? true : false;

            compareTexts.Enabled = (speechToText.BackColor == Color.White) ? true : false;

            return active;
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

            if (fileDialog.ShowDialog() == DialogResult.OK)
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
                    if (imageStack.Count == 11)
                    {
                        imageStack.RemoveFirst();
                    }
                    imageStack.AddLast(new Face(Image.FromFile(selectedFilePath)));
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
            bool active = ActiveButton(voiceCommands, textToSpeech, speechToText);

            if (active && microphoneStatus)
            {
                controller.LaunchVoiceCommands();
            }
            else
            {
                ActiveButton(voiceCommands, textToSpeech, speechToText);
            }
        }

        private void listPresets_Click(object sender, EventArgs e)
        {
            presets = new Presets(this);
            presets.Show();
        }


        private void generateAudio_Click(object sender, EventArgs e)
        {
            string texto = insertedText.Text;
            controller.ConverterTextoEmAudio(texto);
        }


        private void geometricShapes_Click(object sender, EventArgs e)
        {
            CreateShape(-1);
        }

        public void CreateShape(int type)
        {
            if (shapes.Count <= 11)
            {
                shape = (type == -1) ? controller.GenerateImageListFromButton() :
                    controller.GenerateShape((ShapeType)type);

                shapes.AddLast(shape);
                CreateShapeInPictureBox(shape);
            }
        }

        public void CreateShapeInPictureBox(Shape shape)
        {
            if (shapeOnPicture.Equals("Face"))
            {
                removeAllImages();
            }

            Graphics g = pictureBox1.CreateGraphics();


            if (point.Count > positionInterator)
            {
                randomShape.Add(controller.GetRandomImage());
                Point position = point[positionInterator];
                if (shape.shape == null)
                {
                    g.DrawImage(shape.GenerateShape(shape.type.ToString()), position.X, position.Y);
                }
                else
                {
                    g.DrawImage(shape.shape, position.X + shape.x, position.Y + shape.y);
                }

                positionInterator++;
            }

            g.Dispose();

            shapeOnPicture = "Shape";
        }

        private List<Point> GetAvailablePositions()
        {
            positions = new List<Point>();

            int cellSize = 80;
            int offsetX = -10;
            int offsetY = -10;

            int rows = pictureBox1.Height / cellSize;
            int columns = pictureBox1.Width / cellSize;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int x = col * cellSize + offsetX + cellSize / 2;
                    int y = row * cellSize + offsetY + cellSize / 2;
                    positions.Add(new Point(x, y));
                }
            }

            return positions;
        }

        public void RemoveShapesFromPictureBox()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(26, 26, 26));

            shapes.RemoveLast();
            positionInterator = 0;
            foreach (Shape s in shapes)
            {
                CreateShapeInPictureBox(s);
            }

            g.Dispose();
        }

        public void RemoveImageFromPictureBox()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(26, 26, 26));

            faces.RemoveLast();
            positionInterator = 0;

            foreach (Face face in faces)
            {
                CreateImageInPictureBox(face);
            }

            g.Dispose();
        }

        private void cleanImages_Click(object sender, EventArgs e)
        {
            if (shapeOnPicture.Equals("Shape"))
            {
                if (shapes.Count > 0)
                {
                    RemoveShapesFromPictureBox();
                }
            }
            else
            {
                if (faces.Count > 0)
                {
                    RemoveImageFromPictureBox();
                }
            }
        }


        private void compareTexts_Click(object sender, EventArgs e)
        {
            string textoEscrito = insertedText.Text;
            string textoFalado = generatedText.Text;

            string[] palavrasEscritas = textoEscrito.Split(' ');
            string[] palavrasFaladas = textoFalado.Split(' ');

            StringBuilder textoDiferenca = new StringBuilder();

            for (int i = 0; i < palavrasFaladas.Length; i++)
            {
                if (i < palavrasEscritas.Length && palavrasEscritas[i] != palavrasFaladas[i])
                {
                    textoDiferenca.Append($"\"{palavrasFaladas[i]}\" ");
                }
                else
                {
                    textoDiferenca.Append($"{palavrasFaladas[i]} ");
                }
            }


            differenceTexts.Text = textoDiferenca.ToString();



        }




        private void peoplesFaces_Click(object sender, EventArgs e)
        {
            CreateImage();
        }

        public void CreateImage()
        {
            if (imageStack.Count > 0)
            {

                Random random = new Random();
                int randomIndex = random.Next(0, imageStack.Count);

                Face faceImage = new Face(imageStack.ElementAt(randomIndex).image);
                CreateImageInPictureBox(faceImage);

                if (faces.Count <= 11)
                {
                    faces.AddLast(faceImage);
                }
            }
        }

        public void CreateImageInPictureBox(Face faceImage)
        {
            if (shapeOnPicture.Equals("Shape"))
            {
                removeAllShapes();
            }
            Graphics g = pictureBox1.CreateGraphics();
            if (point.Count > positionInterator)
            {
                Point position = point[positionInterator];
                g.DrawImage(faceImage.image, position.X + faceImage.x, position.Y + faceImage.y);
                positionInterator++;
            }

            shapeOnPicture = "Face";

        }

        private void actualPresets_TextChanged(object sender, EventArgs e)
        {
            string presetName = actualPresets.Text.Remove(0, 9);
            controller.DefineCommandList(presetName);
        }

        public void removeAllShapes()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(26, 26, 26));

            positionInterator = 0;
            while (shapes.Count > 0)
            {
                shapes.RemoveLast();
            }

            g.Dispose();
        }

        public void removeAllImages()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(26, 26, 26));

            positionInterator = 0;
            while (faces.Count > 0)
            {
                faces.RemoveLast();
            }

            g.Dispose();
        }

        private void engLanguage_Click(object sender, EventArgs e)
        {
            bool active = ModifyLanguage(engLanguage, porLanguage);

            if (active)
            {
                ModifyImageLanguage(true, false);
            }
            else
            {
                ModifyImageLanguage(false, true);
            }
        }

        private void porLanguage_Click(object sender, EventArgs e)
        {
            bool active = ModifyLanguage(porLanguage, engLanguage);

            if (active)
            {
                ModifyImageLanguage(false, true);
            }
            else
            {
                ModifyImageLanguage(true, false);
            }
        }

        private bool ModifyLanguage(Button button, Button other)
        {
            bool active = false;
            Color bg = button.BackColor;

            if (bg.Equals(Color.FromArgb(179, 179, 179)))
            {
                button.BackColor = Color.White;
                other.BackColor = Color.FromArgb(179, 179, 179);

                active = true;
            }
            else
            {
                button.BackColor = Color.FromArgb(179, 179, 179);
                other.BackColor = Color.White;
                active = false;
            }

            return active;
        }

        private void ModifyImageLanguage(bool engEnabled, bool porEnabled)
        {

            defaultLanguage = (engEnabled) ? "en-US" : defaultLanguage;

            engLanguage.Image = (engEnabled) ? global::Project_Audio.Properties.Resources.engLanguage :
                global::Project_Audio.Properties.Resources.engLanguageDisabled;

            defaultLanguage = (porEnabled) ? "pt-BR" : defaultLanguage;

            porLanguage.Image = (porEnabled) ? global::Project_Audio.Properties.Resources.porLanguage :
                global::Project_Audio.Properties.Resources.porLanguageDisabled;

        }
    }
}
