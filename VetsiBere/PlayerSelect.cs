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
        //public static string[] playerNames = new string[0];
        public static List<string> playerNames = new List<string>();
        public static int playerCount => playerNames.Count;
        public static string[] defaultNames = new string[]{ "Pepa","Duong","Xuan Anh", "David", "Zajda", "Smolik", "Xuan", "Anh"};
        Random r = new Random();

        public PlayerSelect()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                Player p = new Player(defaultNames[r.Next(0, defaultNames.Length)]);
                flowLayoutPanel1.Controls.Add(p);
                p.deleteMe += (Player) =>
                {
                    flowLayoutPanel1.Controls.Remove(Player);
                };
            }     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(flowLayoutPanel1.Controls.Count < 10)
            {
                Player p = new Player();
                flowLayoutPanel1.Controls.Add(p);
                p.deleteMe += (Player) =>
                {
                    flowLayoutPanel1.Controls.Remove(Player);
                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            foreach (Player p in flowLayoutPanel1.Controls)
            {
                if (p.playerName == "")
                {
                    names.Add(defaultNames[r.Next(0, defaultNames.Length)]);
                }
                else
                {
                    names.Add(p.playerName); // z p.Name
                }
            }

            playerNames = names;

            Form1 f = new Form1();
            Hide();
            f.TakeThis(playerNames);
            f.ShowDialog();
            Show();
        }
    }
}
