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
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortDateString();
            textBox2.Text = DateTime.Now.ToLongTimeString();
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "heydev" && textBox4.Text == "abcd1234")
            {
                MessageBox.Show("LOGIN SUCCESSFUL", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Visible = false;
                mainpage mp = new mainpage();
                mp.Show();
            }
            else
            {
                MessageBox.Show("USERNAME OR PASSWORD IS WRONG!", "LOGIN ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WISH TO EXIT?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else if(res == DialogResult.No)
            {
                MessageBox.Show("LOGIN TO PROCEED");
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
