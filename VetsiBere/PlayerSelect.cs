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
    public partial class PlayerSelect : Form
    {
        public static string[] playerNames = new string[0];
        public static int playerCount => playerNames.Length;
        public static string[] defaultNames = new string[]{ "Pepa","Duong","Xuan anh"};
        Random r = new Random();
        public PlayerSelect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player p = new Player();
            flowLayoutPanel1.Controls.Add(p);
            p.deleteMe += (Player) =>
            {
                flowLayoutPanel1.Controls.Remove(Player);
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            foreach (Player p in flowLayoutPanel1.Controls)
            {
                if (p.Name == "")
                {
                    names.Add(defaultNames[r.Next(0, defaultNames.Length)]);
                }
                else {
                    names.Add(p.Name);
                }
            }
            playerNames = names.ToArray();

            Form1 f = new Form1();
            Hide();
            f.ShowDialog();
            Show();
        }
    }
}
