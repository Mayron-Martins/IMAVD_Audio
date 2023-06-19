using System.Speech.Synthesis;

namespace Project_Audio.Controller
{
    public class RecognitionTextController
    {
        public void ConvertTextToAudio(string texto, string language)
        {
            using (var synthesizer = new SpeechSynthesizer())
            {
                synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, new System.Globalization.CultureInfo(language));
                synthesizer.Speak(texto);
            }
        }

    }
}
