using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Audio.Controller
{
    public class PrincipalController
    {
        private Principal view;
        LinkedList<Image> imageLinkedList = new LinkedList<Image>();

        public PrincipalController(Principal view)
        {
            this.view = view;
        }

        public void teste (String eu)
        {
            MessageBox.Show("sssss");
        }

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
    }
}
