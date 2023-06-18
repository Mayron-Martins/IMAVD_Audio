using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.CognitiveServices.Speech;
using System.Speech.Synthesis;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Project_Audio.Controller
{
    public class PrincipalController
    {
        private Principal view;

        private SpeechRecognizer recognizer;

        LinkedList<Image> imageLinkedList = new LinkedList<Image>();


        public PrincipalController(Principal view)
        {
            this.view = view;
        }

        //--TRANSFORMAÇÃO DE TEXTO EM AUDIO--
        public void ConverterTextoEmAudio(string texto)
        {
            using (var synthesizer = new System.Speech.Synthesis.SpeechSynthesizer())
            {
                synthesizer.Speak(texto);
            }
        }

        //-------------------------------------

        //--TRANSFORMAÇÃO DE ÁUDIO EM TEXTO--

        public async Task<string> ConverterAudioEmTexto(string audioFilePath)
        {
            var config = SpeechConfig.FromSubscription("53819328f1534023a155cd721fbe9a31", "brazilsouth");
            recognizer = new SpeechRecognizer(config);

            using (var audioInput = AudioConfig.FromWavFileInput(audioFilePath))
            {
                var result = await recognizer.RecognizeOnceAsync();
                return result.Text;
            }
        }

        //-----------------------------------

        //--TRANSFORMAÇÃO DE FALA EM TEXTO--

        public async Task<string> ConverterFalaEmTexto()
        {
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

<<<<<<< HEAD
        //--COMPARAÇÃO DE TEXTO--
      
        

        //-----------------------





=======
>>>>>>> b9e204491eff1bc6b14376d74c768e53dd1c44bb
        public void GenerateImageListFromButton(Image shape)
        {
            imageLinkedList.AddLast(shape);
        }

        public Image GetRandomImage()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, imageLinkedList.Count);

            LinkedListNode<Image> currentNode = imageLinkedList.First;
            for (int i = 0; i < randomIndex; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Value;
        }

        public void DeleteImageListFromButton()
        {
            while (imageLinkedList.Count != 0)
            {
                imageLinkedList.RemoveLast();
            }
        }

    }
}
