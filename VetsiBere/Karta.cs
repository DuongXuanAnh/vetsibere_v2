using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetsiBere
{
    class Karta
    {
        public int id;
        public int x;
        public int y;
        public int height = 170;
        public int width = 130;
        public int hodnota;
        public bool otevrena = false;
        public Image img;
        public Color color;
        public Hrac vlastnikKarty;
        public PictureBox pictureBox;
        

        public Karta()
        {

        }

        public Karta(int id, int hodnota)
        {
            this.id = id;
            this.hodnota = hodnota;
        }

        public void nastaveniKarty(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }
    }
}
