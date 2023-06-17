using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Audio.Controller
{
    public class PrincipalController
    {
        private Principal view;

        public PrincipalController(Principal view)
        {
            this.view = view;
        }

        public void teste (String eu)
        {
            MessageBox.Show("sssss");
        }
    }
}
