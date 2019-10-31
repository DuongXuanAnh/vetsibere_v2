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
    public partial class Nastaveni : Form
    {

        List<UC_addPlayer> UC_AddPlayers = new List<UC_addPlayer>();

        public Nastaveni()
        {
            InitializeComponent();
            generujHrace();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UC_addPlayer formAddPlayer = new UC_addPlayer();
            formAddPlayer.Location = new Point(UC_AddPlayers[UC_AddPlayers.Count - 1].Location.X, UC_AddPlayers[UC_AddPlayers.Count - 1].Location.Y + 50);
            UC_AddPlayers.Add(formAddPlayer);
            panel.Controls.Add(formAddPlayer);
        }

        private void generujHrace()
        {
            for (int i = 0; i < 2; i++)
            {
                UC_addPlayer formAddPlayer = new UC_addPlayer();
                formAddPlayer.Location = new Point(6, 5 + 50 * i);
                UC_AddPlayers.Add(formAddPlayer);
                panel.Controls.Add(formAddPlayer);
            }
        }
    }
}
