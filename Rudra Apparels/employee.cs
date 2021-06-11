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
   
   
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
   
        }

        private void employee_Load(object sender, EventArgs e)
        {
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainpage mp = new mainpage();
            mp.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            empdisplay emp = new empdisplay("search");
            emp.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            empdisplay emp = new empdisplay("add");
            emp.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            empdisplay emp = new empdisplay("delete");
            emp.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            empdisplay emp = new empdisplay("update");
            emp.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            empdisplay emp = new empdisplay("view");
            emp.Visible = true;
        }
    }
}
