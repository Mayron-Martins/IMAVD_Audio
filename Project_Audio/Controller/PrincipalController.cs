using System;
using System.Collections.Generic;
using Project_Audio.Model;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.IO;
using NAudio.Wave;
using Newtonsoft.Json;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Project_Audio.Controller
{
    public class PrincipalController
    {
        private Principal view;
        LinkedList<ShapeType> imageLinkedList = new LinkedList<ShapeType>();
        private Dictionary<string, Action> voiceCommands;
        private Dictionary<string, Color> colorList;
        private List<CommandAction> commandList;
        private string actualAction;


        public PrincipalController(Principal view)
        {
            this.view = view;
            voiceCommands = new Dictionary<string, Action>();
            commandList = new List<CommandAction>();
            colorList = new Dictionary<string, Color>();
            SetVoiceCommands();
            SetColorList();
        }

        //--TRANSFORMAÇÃO DE TEXTO EM AUDIO--
        public void ConverterTextoEmAudio(string texto)
        {
            RecognitionController recognitionController = new RecognitionController();

            recognitionController.ConvertTextToAudio(texto, view.defaultLanguage);

        }

        //-------------------------------------

        //--TRANSFORMAÇÃO DE ÁUDIO EM TEXTO--

        public async Task<string> ConverterAudioEmTextoAsync(string audioFilePath)
        {
            string extension = Path.GetExtension(audioFilePath).ToLower();

            string pathWAV = (extension.Equals(".wav")) ? audioFilePath :
                ConvertToWav(audioFilePath);

            var config = SpeechConfig.FromSubscription("53819328f1534023a155cd721fbe9a31", "brazilsouth");
            config.SpeechRecognitionLanguage = view.defaultLanguage;

            using (var audioInput = AudioConfig.FromWavFileInput(pathWAV))
            {
                using (var recognizer = new SpeechRecognizer(config, audioInput))
                {
                    var result = await recognizer.RecognizeOnceAsync();

                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        return result.Text;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

        }

        private string ConvertToWav(string audioFilePath)
        {
            string wavFilePath = Path.ChangeExtension(audioFilePath, ".wav");

            using (var reader = new Mp3FileReader(audioFilePath))
            {
                WaveFileWriter.CreateWaveFile(wavFilePath, reader);
            }

            return wavFilePath;
        }

        //-----------------------------------

        //--TRANSFORMAÇÃO DE FALA EM TEXTO--

        public async Task<string> ConverterFalaEmTexto()
        {
            if (!view.microphoneStatus)
            {
                return string.Empty;
            }
            var config = SpeechConfig.FromSubscription("53819328f1534023a155cd721fbe9a31", "brazilsouth");
            config.SpeechRecognitionLanguage = view.defaultLanguage;

            using (var recognizer = new SpeechRecognizer(config))
            {
                var resultado = await recognizer.RecognizeOnceAsync();

                if (resultado.Reason == ResultReason.RecognizedSpeech)
                {
                    return resultado.Text;
                }
                else if (resultado.Reason == ResultReason.NoMatch)
                {
                    return "Não foi possível reconhecer a fala.";
                }
                else if (resultado.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(resultado);

                    return $"Cancelado. Motivo: {cancellation.Reason}. Detalhes: {cancellation.ErrorDetails}";
                }

                return string.Empty;
            }
        }


        public Shape GenerateImageListFromButton()
        {
            Random random = new Random();

            int tipoIndex = random.Next(0, 3);

            ShapeType tipo = (ShapeType)tipoIndex;
            imageLinkedList.AddLast(tipo);

            return new Shape { type = tipo };
        }

        public Shape GenerateShape(ShapeType index)
        {
            ShapeType tipo = index;
            imageLinkedList.AddLast(tipo);

            return new Shape { type = tipo };
        }

        public ShapeType GetRandomImage()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, imageLinkedList.Count);

            LinkedListNode<ShapeType> currentNode = imageLinkedList.First;
            for (int i = 0; i < randomIndex; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Value;
        }

        public void DeleteImageListFromButton()
        {
            imageLinkedList.RemoveLast();
        }

        public void DefineCommandList(string presetName)
        {
            string pathPresets = Path.Combine(AppContext.BaseDirectory, "Presets");

            string preset = Path.Combine(pathPresets, presetName + ".json");

            string contentJson = File.ReadAllText(preset);

            if (contentJson.Equals("{}"))
            {
                return;
            }

            commandList = JsonConvert.DeserializeObject<List<CommandAction>>(contentJson);
        }

        public async void LaunchVoiceCommands()
        {
            string captureVoice = await ConverterFalaEmTexto();
            captureVoice = captureVoice.Replace(".", "").Replace(",","");

            bool existCommand = false;
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
                view.voiceCommands.BackColor = Color.FromArgb(179, 179, 179);
                return;
            }

            string[] action = actualAction.Split(';');

            voiceCommands[action[0]]();

            view.voiceCommands.BackColor = Color.FromArgb(179, 179, 179);
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

        private void SetVoiceCommands()
        {
            voiceCommands.Add("Rotate", ActionRotate);
            voiceCommands.Add("Move to", ActionMoveTo);
            voiceCommands.Add("Resize", ActionResize);
            voiceCommands.Add("Color", ActionColor);
            voiceCommands.Add("Create", ActionCreate);
            voiceCommands.Add("Duplicate", ActionDuplicate);

        }

        private void SetColorList()
        {
            colorList.Add("Red", Color.Red);
            colorList.Add("Blue", Color.Blue);
            colorList.Add("Green", Color.Green);
            colorList.Add("White", Color.White);
            colorList.Add("Black", Color.Black);
            colorList.Add("Yellow", Color.Yellow);
            colorList.Add("Orange", Color.Orange);
            colorList.Add("Brown", Color.Brown);
            colorList.Add("Purple", Color.Purple);
        }

        private void ActionRotate()
        {
            string[] action = actualAction.Split(';');

            RotateFlipType type = RotateFlipType.RotateNoneFlipNone;
            switch (action[1])
            {
                case "Right":
                    type = RotateFlipType.Rotate270FlipNone;
                    break;
                case "Left":
                    type = RotateFlipType.Rotate90FlipNone;
                    break;
                case "Horizontal":
                    type = RotateFlipType.RotateNoneFlipX;
                    break;
                case "Vertical":
                    type = RotateFlipType.RotateNoneFlipY;
                    break;

            }

            if (view.shapeOnPicture.Equals("Shape"))
            {
                LinkedList<Shape> shapes = new LinkedList<Shape>(view.shapes);
                view.removeAllShapes();
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes.ElementAt(i).type.ToString().ToLower() == action[2].ToLower())
                    {
                        shapes.ElementAt(i).rotate(type);
                    }
                    view.CreateShapeInPictureBox(shapes.ElementAt(i));
                }
                view.shapes = new LinkedList<Shape>(shapes);
            }
            else
            {
                LinkedList<Face> faces = new LinkedList<Face>(view.faces);
                view.removeAllImages();
                for (int i = 0; i < faces.Count; i++)
                {
                    faces.ElementAt(i).image.RotateFlip(type);
                    view.CreateImageInPictureBox(faces.ElementAt(i));
                }

                view.faces = new LinkedList<Face>(faces);
            }
        }

        private void ActionMoveTo()
        {
            string[] action = actualAction.Split(';');
            int x = 0, y = 0;
            switch (action[1])
            {
                case "Right":
                    x = 15;
                    y = 0;
                    break;
                case "Left":
                    x = -15;
                    y = 0;
                    break;
                case "Up":
                    x = 0;
                    y = -15;
                    break;
                case "Down":
                    x = 0;
                    y = 15;
                    break;
            }

            if (view.shapeOnPicture.Equals("Shape"))
            {
                LinkedList<Shape> shapes = new LinkedList<Shape>(view.shapes);
                view.removeAllShapes();
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes.ElementAt(i).type.ToString().ToLower() == action[2].ToLower())
                    {
                        shapes.ElementAt(i).moveShape(x, y);
                    }
                    view.CreateShapeInPictureBox(shapes.ElementAt(i));
                }
                view.shapes = new LinkedList<Shape>(shapes);
            }
            else
            {
                LinkedList<Face> faces = new LinkedList<Face>(view.faces);
                view.removeAllImages();
                for (int i = 0; i < faces.Count; i++)
                {
                    faces.ElementAt(i).moveFace(x, y);
                    view.CreateImageInPictureBox(faces.ElementAt(i));
                }
                view.faces = new LinkedList<Face>(faces);
            }
        }

        private void ActionResize()
        {
            string[] action = actualAction.Split(';');

            int size = (action[1].Equals("Grow")) ? 10 : -10;

            if (view.shapeOnPicture.Equals("Shape"))
            {
                LinkedList<Shape> shapes = new LinkedList<Shape>(view.shapes);
                view.removeAllShapes();
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes.ElementAt(i).type.ToString().ToLower() == action[2].ToLower())
                    {
                        shapes.ElementAt(i).ResizeShape(size);
                    }
                    view.CreateShapeInPictureBox(shapes.ElementAt(i));
                }
                view.shapes = new LinkedList<Shape>(shapes);
            }
            else
            {
                LinkedList<Face> faces = new LinkedList<Face>(view.faces);
                view.removeAllImages();
                for (int i = 0; i < faces.Count; i++)
                {
                    faces.ElementAt(i).ResizeFace(size);
                    view.CreateImageInPictureBox(faces.ElementAt(i));
                }
                view.faces = new LinkedList<Face>(faces);
            }


        }

        private void ActionColor()
        {
            string[] action = actualAction.Split(';');
            if (!colorList.ContainsKey(action[1]))
            {
                return;
            }
            Color color = colorList[action[1]];

            if (view.shapeOnPicture.Equals("Shape"))
            {
                LinkedList<Shape> shapes = new LinkedList<Shape>(view.shapes);
                view.removeAllShapes();
                for (int i = 0; i < shapes.Count; i++)
                {
                    
                    if (shapes.ElementAt(i).type.ToString().ToLower() == action[2].ToLower())
                    {
                        shapes.ElementAt(i).Paint(color);
                    }

                    view.CreateShapeInPictureBox(shapes.ElementAt(i));
                }
                view.shapes = new LinkedList<Shape>(shapes);
            }
            else
            {
                LinkedList<Face> faces = new LinkedList<Face>(view.faces);
                view.removeAllImages();
                for (int i = 0; i < faces.Count; i++)
                {
                    faces.ElementAt(i).Paint(color);
                    view.CreateImageInPictureBox(faces.ElementAt(i));
                }
                view.faces = new LinkedList<Face>(faces);
            }
        }

        private void ActionCreate()
        {
            string[] action = actualAction.Split(';');

            if (action[1].Equals("Face"))
            {
                view.CreateImage();
            }
            else
            {
                int type = 0;
                switch (action[1])
                {
                    case "Square":
                        type = 1;
                        break;
                    case "Triangle":
                        type = 0;
                        break;
                    case "Circle":
                        type = 2;
                        break;
                }
                view.CreateShape(type);
            }
        }

        private void ActionDuplicate()
        {
            string[] action = actualAction.Split(';');
            if (action[1].Equals("Face"))
            {
                LinkedList<Face> faces = new LinkedList<Face>(view.faces);
                LinkedList<Face> facesDuplicate = new LinkedList<Face>();
                view.removeAllImages();
                for (int i = 0; i < faces.Count; i++)
                {
                    if (facesDuplicate.Count > 10)
                    {
                        break;
                    }

                    facesDuplicate.AddLast(faces.ElementAt(i));
                    view.CreateImageInPictureBox(faces.ElementAt(i));

                    facesDuplicate.AddLast(faces.ElementAt(i));
                    view.CreateImageInPictureBox(faces.ElementAt(i));

                }

                view.faces = new LinkedList<Face>(facesDuplicate);
            }
            else
            {
                LinkedList<Shape> shapes = new LinkedList<Shape>(view.shapes);
                LinkedList<Shape> shapesDuplicate = new LinkedList<Shape>();
                view.removeAllShapes();
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapesDuplicate.Count >= 12)
                    {
                        break;
                    }

                    if (shapes.ElementAt(i).type.ToString().ToLower() == action[1].ToLower() && shapesDuplicate.Count <= 10)
                    {
                        shapesDuplicate.AddLast(shapes.ElementAt(i));
                        view.CreateShapeInPictureBox(shapes.ElementAt(i));
                    }
                    shapesDuplicate.AddLast(shapes.ElementAt(i));
                    view.CreateShapeInPictureBox(shapes.ElementAt(i));
                }
                view.shapes = new LinkedList<Shape>(shapesDuplicate);
            }
        }

    }
}
