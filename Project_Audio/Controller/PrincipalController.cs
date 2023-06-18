using System;
using System.Collections.Generic;
using Project_Audio.Model;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.IO;
using NAudio.Wave;

namespace Project_Audio.Controller
{
    public class PrincipalController
    {
        private Principal view;

        

        LinkedList<ShapeType> imageLinkedList = new LinkedList<ShapeType>();


        public PrincipalController(Principal view)
        {
            this.view = view;
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

        //----------------------------------


        //--COMPARAÇÃO DE TEXTO--



        //-----------------------






        /*public Shape GenerateImageListFromButton(Image shape)
        {
            imageLinkedList.AddLast(shape);
        }*/

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

    }
}
