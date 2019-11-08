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
        //int pocetHracu = 10;

        List<Karta> celyBalik;
        List<Karta> kartyNaStole;
        List<Hrac> hraci;
        List<Karta> otevreneKarty = new List<Karta>();
        List<Karta> minoBalicek = new List<Karta>();
        List<Label> labels = new List<Label>();

        bool kolaNavic = false;
        


        public Form1()
        {
            InitializeComponent();
            vytvoritCelyBaleniKaret();
            celyBalik = celyBalik.OrderBy(a => Guid.NewGuid()).ToList(); // Zamichat karty
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
                Hrac h = new Hrac(i, PlayerSelect.playerNames[i]);
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
                    Label l = new Label();
                    l.Text = hraci[i].name + " " + 32 / pocetHracu;
                    l.Location = new Point(25 + 80 * i, 30);
                    labels.Add(l);
                    this.Controls.Add(l);
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
                    Label l = new Label();
                    l.Text = hraci[i].name + " " + 32 / pocetHracu;
                    l.Location = new Point(25 + 80 * i - 80, 270);
                    labels.Add(l);
                    this.Controls.Add(l);
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

        List<Hrac> winners = new List<Hrac>();

        void card_Click(object sender, EventArgs e)
        {
     
            PictureBox pictureBox = sender as PictureBox;            
            foreach(Karta k in kartyNaStole)
            {
                if(k.pictureBox == pictureBox && k.otevrena == false)
                {
                    pictureBox.Image = k.img;
                    otevreneKarty.Add(k);
                    minoBalicek.Add(k);
                    k.otevrena = true;
                   
                    if(kolaNavic == true)
                    {
                        if(winners.Count == otevreneKarty.Count)
                        {
                            porovnatKarty();
                        }
                    }
                }
            }
           
            if (otevreneKarty.Count == pocetHracu)
            {
                porovnatKarty();
            }
        }

       

        void porovnatKarty()
        {
            winners = new List<Hrac>();
      
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
                    zahajitDalsiTurnProVyhranyHrace(winners.Count);
                    
            }
        }

        //---------------------------------------------------------------
        void zahajitDalsiTurnProVyhranyHrace(int pocetVyhranyHracu)
        {
            MessageBox.Show("Aspon 2 hrace maji stejne karty");
            kolaNavic = true;
            smazatOtevrenyKarty();
            odebratPristupHrace();
           
        }

        //---------------------------------------------------------------


        void sebratVsechnyKarty(Hrac vitez)
        {
            MessageBox.Show("Bere hrac " + vitez.name);

  

            for (int i = 0; i < minoBalicek.Count; i++)
            {
                vitez.balicek.Insert(0, minoBalicek[i]); // Dat vitezovy vsechny karty
            }
            smazatOtevrenyKarty();
            for( int i = 0; i < labels.Count; i++)
            {
                labels[i].Text = hraci[i].name + " " + hraci[i].balicek.Count;
            }

           // odebratHrace();
            oznamitVyteze();
            zacitNovyTurn();
        }

        void zacitNovyTurn()
        {
            minoBalicek = new List<Karta>();
            otevreneKarty = new List<Karta>();
            winners = new List<Hrac>();
            kolaNavic = false;
            foreach(Hrac h in hraci)
            {
                foreach (Hrac hrac in hraci)
                {
                    foreach (Karta k in hrac.balicek)
                    {
                        k.otevrena = false;
                    }
                }
            }
        }

        void smazatOtevrenyKarty()
        {
          
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
            otevreneKarty = new List<Karta>();
        }

        void odebratPristupHrace()
        {
            var items = hraci.Except(winners);

            foreach (Hrac hrac in items.ToArray())
            {
                foreach (Karta k in hrac.balicek)
                {
                    k.otevrena = true;
                }
            }
        }

        void oznamitVyteze()
        {
            if(hraci.Count == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Vyhrál hráč " + hraci[0].name + "\nChcete začít novou hru", "Oznámení", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
    }
}
