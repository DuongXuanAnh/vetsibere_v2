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
    public partial class UC_addPlayer : UserControl
    {
        public UC_addPlayer()
        {
            InitializeComponent();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
        }
    }
}
