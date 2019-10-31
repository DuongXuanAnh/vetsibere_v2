using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetsiBere
{
    public partial class Form1 : Form
    {
        int pocetHracu = 5;
        List<Karta> celyBalik;
        List<Karta> kartyNaStole;
        List<Karta> karty_V_Balicku_Ktery_Byl_Kliknuty;
        List<Karta> otevreneKarty;
        List<Hrac> hraci;
        

        Color barvaKaret = Color.Aqua;

        public Form1()
        {
            InitializeComponent();
            vytvoritCelyBaleniKaret();
            //celyBalik = celyBalik.OrderBy(a => Guid.NewGuid()).ToList(); // Zamichat karty
            rozdelitKarty();
            
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Karta k = new Karta();
            vykreslitVsechnyBalicky(g);

        }


        private void vytvoritCelyBaleniKaret()
        {
            celyBalik = new List<Karta>();
            int[] hodnota = { 4, 5, 6, 7, 8, 9, 10, 11 };
            int id = 0;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Karta karta = new Karta(id, hodnota[i]);
                    karta.img = Image.FromFile(@"..\..\resources\karty\" + id + ".jpg");
                    celyBalik.Add(karta);
                    id++;
                }
            }
        }

        private void rozdelitKarty()
        {
            kartyNaStole = new List<Karta>();
            hraci = new List<Hrac>();
            for( int i = 0; i < pocetHracu; i++)
            {
                Hrac h = new Hrac(i,"Hrac"+i);
                hraci.Add(h);

                for(int j = 0; j < celyBalik.Count/ pocetHracu; j++)
                {
                    celyBalik[j + (pocetHracu + 1) * i].vlastnikKarty = h; // Nastavit vlastnika na tu kartu
                    hraci[i].PrijmoutKartu(celyBalik[j + (pocetHracu + 1)*i]);
                    kartyNaStole.Add(celyBalik[j + (pocetHracu + 1) * i]);

                }
            }
        }

        private void vykreslitVsechnyBalicky(Graphics g)
        {
            karty_V_Balicku_Ktery_Byl_Kliknuty = new List<Karta>();
            otevreneKarty = new List<Karta>();
          
            for (int i = 0; i < pocetHracu; i++)
            {
                if (i % 2 == 0)
                {
                    foreach (Karta k in hraci[i].balicek)
                    {
                        k.vykresliSe(g, 25 + 80 * i, 50);
                    }
                }
                else
                {
                    foreach (Karta k in hraci[i].balicek)
                    {
                        k.vykresliSe(g, 25 + 80 * i - 80, 300);
                    }
                }
                   
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Karta k in kartyNaStole)
            {
                if ((k.x <= e.X && k.x + k.width >= e.X) && (k.y <= e.Y && k.y+k.height >= e.Y))
                {
                    karty_V_Balicku_Ktery_Byl_Kliknuty.Add(k);
                }
            }

            if(karty_V_Balicku_Ktery_Byl_Kliknuty.Count > 0)
            otevriKartu();
         
        }

        private void otevriKartu()
        {
            Karta otevrenaKarta = karty_V_Balicku_Ktery_Byl_Kliknuty[karty_V_Balicku_Ktery_Byl_Kliknuty.Count - 1];
            otevrenaKarta.otevrena = true;

            PictureBox picture = new PictureBox
            {
                Size = new Size(otevrenaKarta.width, otevrenaKarta.height),
                Location = new Point(otevrenaKarta.x, otevrenaKarta.y),
                Image = otevrenaKarta.img,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            canvas.Controls.Add(picture);
            otevreneKarty.Add(otevrenaKarta);
            canvas.Refresh();
            porovnavatKarty();
        }

        private void porovnavatKarty()
        {
            foreach(Karta k in kartyNaStole)
            {
                if (k.otevrena)
                {
                    otevreneKarty.Add(k);
                }
            }
            if(otevreneKarty.Count == pocetHracu)
            {
                vyhodnoceniKaret();
            }
        }

        List<Hrac> winner = new List<Hrac>();

        private void vyhodnoceniKaret()
        {
            int maxHodnota = otevreneKarty.Max(x => x.hodnota);

            foreach(Karta k in otevreneKarty)
            {
                if(k.hodnota == maxHodnota)
                {
                    winner.Add(k.vlastnikKarty);
                }
            }

            if (winner.Count == 1) {
                sebratKarty(winner[0]);
            }
            else if (winner.Count > 1)
            {

            }
        }

        List<Karta> WinnerDostane = new List<Karta>();

        void sebratKarty(Hrac hrac)
        {
           for(int i = 0; i < otevreneKarty.Count; i++)
            {
                for(int j = 0; j < pocetHracu; j++)
                {
                    if (otevreneKarty[i].vlastnikKarty == hraci[j])
                    {
                        hraci[j].balicek.Remove(otevreneKarty[i]);
                    }
                }
                
            }

            foreach (Karta k in otevreneKarty)
            {
                hrac.balicek.Insert(0, k);
                kartyNaStole.Add(k);
            }

            Console.WriteLine(hraci[0].balicek.Count);
            Console.WriteLine(hraci[1].balicek.Count);
            Console.WriteLine(hraci[2].balicek.Count);
            Console.WriteLine(hraci[3].balicek.Count);
            Console.WriteLine(hraci[4].balicek.Count);
        }

    }
}
