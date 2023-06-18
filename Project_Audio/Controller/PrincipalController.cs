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
            voiceCommands.Add("Move To", ActionMoveTo);
            voiceCommands.Add("Resize", ActionResize);
            voiceCommands.Add("Color", ActionColor);
            voiceCommands.Add("Create", ActionCreate);
            voiceCommands.Add("Duplicate", ActionDuplicate);

        }

        private void ActionRotate()
        {

        }

        private void ActionMoveTo()
        {

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
