using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetsiBere
{
    public partial class Player : UserControl
    {

        public string plyerName => textBox1.Text;
        public event Action<Player> deleteMe;

        public Player()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteMe?.Invoke(this);
        }
    }
}
