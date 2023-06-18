using Project_Audio.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Audio.Controller
{
    public class PresetsController
    {
        private Presets view;
        public PresetsController(Presets view) {
            this.view = view;
            this.generateDefault();
        }

        private void generateDefault()
        {

        }
    }
}
