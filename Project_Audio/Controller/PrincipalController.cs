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

namespace Project_Audio.Controller
{
    public class PrincipalController
    {
        private Principal view;
        LinkedList<ShapeType> imageLinkedList = new LinkedList<ShapeType>();
        private Dictionary<string, Action> voiceCommands;
        private List<CommandAction> commandList;
        private string actualAction;


        public PrincipalController(Principal view)
        {
            this.view = view;
            voiceCommands = new Dictionary<string, Action>();
            commandList = new List<CommandAction>();
            setVoiceCommands();
        }

        //--TRANSFORMAÇÃO DE TEXTO EM AUDIO--
        public void ConverterTextoEmAudio(string texto)
        {
            RecognitionController recognitionController = new RecognitionController();

            recognitionController.ConvertTextToAudio(texto);

        }

        //-------------------------------------

        //--TRANSFORMAÇÃO DE ÁUDIO EM TEXTO--

        public async Task<string> ConverterAudioEmTextoAsync(string audioFilePath)
        {
            string extension = Path.GetExtension(audioFilePath).ToLower();

            string pathWAV = (extension.Equals(".wav")) ? audioFilePath :
                ConvertToWav(audioFilePath);

            var config = SpeechConfig.FromSubscription("53819328f1534023a155cd721fbe9a31", "brazilsouth");

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

            //Color cor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

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
            captureVoice = captureVoice.Replace(".", "");

            bool existCommand = false;
            foreach (CommandAction command in commandList)
            {
                if (command.name.ToLower() == captureVoice.ToLower())
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

        private void setVoiceCommands()
        {
            voiceCommands.Add("Rotate", ActionRotate);
            voiceCommands.Add("Move to", ActionMoveTo);
            voiceCommands.Add("Resize", ActionResize);
            voiceCommands.Add("Color", ActionColor);
            voiceCommands.Add("Create", ActionCreate);
            voiceCommands.Add("Duplicate", ActionDuplicate);

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
                for(int i=0; i<shapes.Count; i++)
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
                for(int i=0; i<faces.Count; i++)
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
            int x =0 , y = 0;
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
                        view.CreateShapeInPictureBox(shapes.ElementAt(i));
                        continue;
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

        }

        private void ActionColor()
        {

        }

        private void ActionCreate()
        {

        }

        private void ActionDuplicate()
        {

        }

    }
}
