using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Synthesis;
using System.IO;

namespace Project_Audio.Controller
{
    public class PrincipalController
    {
        private Principal view;

        public PrincipalController(Principal view)
        {
            this.view = view;
        }
    }

    //- CONVERTER TEXTO PARA AUDIO 

    public byte[] ConverterTextoEmAudio(string texto)
    {
        using (var synthesizer = new SpeechSynthesizer())
        {
            using (var outputStream = new MemoryStream())
            {
                synthesizer.SetOutputToWaveStream(outputStream);
                synthesizer.Speak(texto);
                return outputStream.ToArray();
            }
        }
    }


}

