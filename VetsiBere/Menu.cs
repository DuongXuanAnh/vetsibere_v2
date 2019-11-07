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
