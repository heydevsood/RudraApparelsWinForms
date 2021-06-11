using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rudra_Apparels
{
    public partial class orders : Form
    {
        public orders()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             mainpage mp = new mainpage();
            mp.Visible = true;
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            addorder ao = new addorder();
            ao.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vieworders v = new vieworders();
            this.Visible = false;
            v.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trackorder to = new trackorder();
            this.Visible = false;
            to.Visible = true;
        }
    }
}
