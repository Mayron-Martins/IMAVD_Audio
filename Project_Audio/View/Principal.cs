using Project_Audio.Controller;
using Project_Audio.View;
using Project_Audio.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace Project_Audio
{

    public partial class Principal : Form
    {
        private PrincipalController controller;
        public bool microphoneStatus;
        public LinkedList<Image> imageStack;
        private int positionInterator;
        private List<ShapeType> randomShape;
        private LinkedList<Shape> shapes;
        private List<Point> point;
        private List<Point> positions;
        Shape shape = new Shape();
        public Principal()
        {
            InitializeComponent();
            controller = new PrincipalController(this);
            microphoneStatus = false;
            imageStack = new LinkedList<Image>();
            StartPosition = FormStartPosition.CenterScreen;
            positionInterator = 0;
            randomShape = new List<ShapeType>();
            shapes = new LinkedList<Shape>();
            point = new List<Point>();
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
            fileDialog.Filter = "Arquivos de Áudio(*.wav,*.mp3,*.ogg,*.jpg,*.png,*.gif)|*.wav;*.mp3;*.ogg;*.jpg;*.png;*.gif";
            
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


        private void button1_Click(object sender, EventArgs e)
        {
            string texto = insertedText.Text;
            controller.ConverterTextoEmAudio(texto);
        }

        private void generatedText_TextChanged(object sender, EventArgs e)
        {

        }

        private void pathAudioFile_TextChanged(object sender, EventArgs e)
        {

        }
        private void geometricShapes_Click(object sender, EventArgs e)
        {

            shape = controller.GenerateImageListFromButton();
            shapes.AddLast(shape);
            CreateShapeInPictureBox(shape);

        }

        private void CreateShapeInPictureBox(Shape shape)
        {
            Graphics g = pictureBox1.CreateGraphics();

            point = GetAvailablePositions();

            switch (shape.type)
            {
                case ShapeType.Triangle:
                    if (point.Count > positionInterator)
                    {
                        randomShape.Add(controller.GetRandomImage());
                        Point position = point[positionInterator];
                        g.DrawImage(shape.GenerateShape(shape.type.ToString()), position.X, position.Y);
                        positionInterator++;
                    }

                    break;
                case ShapeType.Square:
                    if (point.Count > positionInterator)
                    {
                        randomShape.Add(controller.GetRandomImage());
                        Point position = point[positionInterator];
                        g.DrawImage(shape.GenerateShape(shape.type.ToString()), position.X, position.Y);
                        positionInterator++;
                    }
                    break;
                case ShapeType.Circle:
                    if (point.Count > positionInterator)
                    {
                        randomShape.Add(controller.GetRandomImage());
                        Point position = point[positionInterator];
                        g.DrawImage(shape.GenerateShape(shape.type.ToString()), position.X, position.Y);
                        positionInterator++;
                    }
                    break;
            }

            g.Dispose();
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

        public void RemoveShapesFromPictureBox(Shape shape)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(26, 26, 26));

            shapes.Remove(shape);
            positionInterator = 0;
            foreach (Shape s in shapes)
            {
                CreateShapeInPictureBox(s);
            }

            g.Dispose();
        }

        public void RemoveImageFromPictureBox(Image pBImage)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(26, 26, 26));

            positionInterator = 0;

            g.Dispose();
        }

        private void cleanImages_Click(object sender, EventArgs e)
        {
            if (shapes.Count > 0)
            {
                shape = shapes.Last.Value;
                RemoveShapesFromPictureBox(shape);
            }

            if (imageStack.Count != 0 && shapes.Count == 0)
            {
                Image img = imageStack.Last.Value;
                RemoveImageFromPictureBox(img);
            }
        }

        private void insertedText_TextChanged(object sender, EventArgs e)
        {

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
            Graphics g = pictureBox1.CreateGraphics();
            Image faceImage = imageStack.Last.Value;
            faceImage = shape.ResizeFace(faceImage, 50, 50);
            point = GetAvailablePositions();
            if (point.Count > positionInterator)
            {
                Point position = point[positionInterator];
                g.DrawImage(faceImage, position.X, position.Y);
                positionInterator++;
            }
        }
    } 

}
