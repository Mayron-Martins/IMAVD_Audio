using NAudio.Wave;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace Project_Audio.Controller
{
    public class RecognitionController
    {
        //--TRANSFORMAÇÃO DE ÁUDIO EM TEXTO--

        public string ConvertAudioToText(string audioFilePath)
        {


            string extension = Path.GetExtension(audioFilePath).ToLower();

            WaveStream waveStream = (extension.Equals(".wav")) ?
               new WaveFileReader(audioFilePath) :
               WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(audioFilePath));




            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine())
            {
                //GrammarBuilder builder = new GrammarBuilder();
                //Grammar grammar = new Grammar(builder);
                // Configura o reconhecimento para ditado livre
                recognizer.LoadGrammar(new DictationGrammar());
                //recognizer.SetInputToDefaultAudioDevice();

                // Define o evento SpeechRecognized para lidar com o texto reconhecido
                // recognizer.SpeechRecognized += Recognizer_SpeechRecognized;

                // Define a entrada do reconhecimento como o arquivo de áudio
                recognizer.SetInputToWaveStream(waveStream);

                // Inicia o reconhecimento
                RecognitionResult result = recognizer.Recognize();

                return (result != null) ? result.Text : string.Empty;

            }

        }


        public void ConvertTextToAudio(string texto)
        {
            using (var synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Speak(texto);
            }
        }

        //-----------------------------------

    }
}
