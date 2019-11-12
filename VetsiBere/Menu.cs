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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_SpustitHru_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void btn_Pomoc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\nKarty se rozdají tak, aby každý z hráčů měl právě polovinu karet. Hráči položí své karty v balíčku rubem navrch před sebe.\n\n Oba otočí vrchní kartu lícem navrch.Hráč, který otočil kartu vyšší hodnoty, vezme svoji i protivníkovu kartu a umístí si je dospod balíku.Poté oba hráči otočí další kartu a postup se opakuje.V případě, že otočí oba kartu stejné hodnoty, otočí ještě tři karty a třetí otočená karta rozhodne, kterému hráči připadnou všechny otočené karty.V případě, že třetí otočené karty jsou stejné hodnoty, postup se opakuje.\n\n Vítězí hráč, který získá všechny karty. ");
        }

        private void btn_Nastaveni_Click(object sender, EventArgs e)
        {
            PlayerSelect n = new PlayerSelect();
            n.Show();
            this.Hide();
        }

        private void btn_Konec_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
