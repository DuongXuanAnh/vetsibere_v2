using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        

        public Karta()
        {

        }

        public Karta(int id, int hodnota)
        {
            this.id = id;
            this.hodnota = hodnota;
            this.color = Color.Black;
        }

        public void vykresliSe(Graphics g, int x, int y)
        {
            this.x = x;
            this.y = y;
            Brush brush = new SolidBrush(color);
            g.FillRectangle(brush, x, y, this.width, this.height);
        }

        public void otevriKartu()
        {

        }
    }
}
