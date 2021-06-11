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
    public partial class mainpage : Form
    {
        public mainpage()
        {
            InitializeComponent();
        }

        private void mainpage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate_bill bill = new generate_bill();
            bill.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            catalouge ct = new catalouge();
            ct.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WISH TO LOGOUT?", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(res == DialogResult.Yes)
            {
                this.Close();
                welcome wl = new welcome();
                wl.Show();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            this.Visible = false;
            emp.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            orders or = new orders();
            or.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inventory i = new inventory();
            i.Visible = true;
            this.Visible = false;
        }
    }
}
