using System.Speech.Synthesis;

namespace Project_Audio.Controller
{
    public class RecognitionController
    {
        public void ConvertTextToAudio(string texto)
        {
            using (var synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Speak(texto);
            }
        }

    }
}
