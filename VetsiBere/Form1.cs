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
        int pocetHracu = PlayerSelect.playerCount;
        List<Karta> celyBalik;
        List<Karta> kartyNaStole;
        List<Hrac> hraci;
        List<Karta> otevreneKarty = new List<Karta>();
        List<Karta> minoBalicek = new List<Karta>();
        

        Color barvaKaret = Color.Aqua;

        public Form1()
        {
            InitializeComponent();
            vytvoritCelyBaleniKaret();
          //  celyBalik = celyBalik.OrderBy(a => Guid.NewGuid()).ToList(); // Zamichat karty
            rozdelitKarty();
            zobrazitBalicky();
         
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

        private void rozdelitKarty() // Hrac prijme karty ze zacatku 
        {
            kartyNaStole = new List<Karta>();
            hraci = new List<Hrac>();
            for (int i = 0; i < pocetHracu; i++)
            {
                Hrac h = new Hrac(i, "Hrac" + i);
                hraci.Add(h);

                for (int j = 0; j < celyBalik.Count / pocetHracu; j++)
                {
                    celyBalik[j + (32/pocetHracu) * i].vlastnikKarty = h; // Priradit kartu pro vlastnika
                    hraci[i].PrijmoutKartu(celyBalik[j + (32 / pocetHracu) * i]);
                    kartyNaStole.Add(celyBalik[j + (32 / pocetHracu) * i]);
                }
            }
        }

        void zobrazitBalicky()
        {
            for (int i = 0; i < pocetHracu; i++)
            {
                if (i % 2 == 0)
                {
                    foreach (Karta k in hraci[i].balicek)
                    {
                        PictureBox pictureBox = pictureBox = new PictureBox
                        {
                            Size = new Size(k.width, k.height),
                            Location = new Point(25 + 80 * i, 50),
                            Image = Image.FromFile(@"..\..\resources\karty\pozadi.jpg"),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = k.id
                        };
                        pictureBox.MouseClick += new MouseEventHandler(card_Click);
                        k.nastaveniKarty(pictureBox);
                        this.Controls.Add(pictureBox);                 
                    }
                }
                else
                {
                    foreach (Karta k in hraci[i].balicek)
                    {
                        PictureBox pictureBox = pictureBox = new PictureBox
                        {
                            Size = new Size(k.width, k.height),
                            Location = new Point(25 + 80 * i - 80, 300),
                            Image = Image.FromFile(@"..\..\resources\karty\pozadi.jpg"),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = k.id
                        };
                        pictureBox.MouseClick += new MouseEventHandler(card_Click);
                        k.nastaveniKarty(pictureBox);
                        this.Controls.Add(pictureBox);
                    }
                }

            }
        }

        int count = 0;

        void card_Click(object sender, EventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;            
            foreach(Karta k in kartyNaStole)
            {
                if(k.pictureBox == pictureBox)
                {
                    pictureBox.Image = k.img;
                    otevreneKarty.Add(k);
                    minoBalicek.Add(k);
                    count++;
                }
            }
           
            if (count == pocetHracu)
            {
                porovnatKarty();
                count = 0;
            }
        }

        List<Hrac> winners = new List<Hrac>();

        void porovnatKarty()
        {
            

            int maxHodnota = otevreneKarty.Max(x => x.hodnota);
            foreach (Karta k in otevreneKarty)
            {
                if (k.hodnota == maxHodnota)
                {
                    winners.Add(k.vlastnikKarty);
                }
            }

            if (winners.Count == 1)
            {
                sebratVsechnyKarty(winners[0]);
            }
            else if (winners.Count > 1)
            {
                zahajitDalsiTurnProVyhranyHrace();
            }
        }

        void zahajitDalsiTurnProVyhranyHrace()
        {
            Console.WriteLine("Vyhrali vic");
        }

        void sebratVsechnyKarty(Hrac vitez)
        {
            MessageBox.Show("Bere hrac " + vitez.name);
            for (int i = 0; i < otevreneKarty.Count; i++)
            {
                for (int j = 0; j < pocetHracu; j++)
                {
                    if (otevreneKarty[i].vlastnikKarty == hraci[j])
                    {
                        hraci[j].balicek.Remove(otevreneKarty[i]);
                        this.Controls.Remove(otevreneKarty[i].pictureBox);
                    }
                }

            }

            for (int i = 0; i < minoBalicek.Count; i++)
            {
                vitez.balicek.Insert(0, minoBalicek[i]); // Dat vitezovy vsechny karty
            }


            zacitNovyTurn();
        }

        void zacitNovyTurn()
        {
            minoBalicek = new List<Karta>();
            otevreneKarty = new List<Karta>();
            winners = new List<Hrac>();
        }
    }
}
