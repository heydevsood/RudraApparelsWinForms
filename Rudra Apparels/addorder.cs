using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Rudra_Apparels
{

    public partial class addorder : Form
    {
        public addorder()
        {
            InitializeComponent();
          


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            int artno = Convert.ToInt32(textBox2.Text);
            string customer = textBox3.Text.ToUpper();
            string dateformat;
            string yr = dateTimePicker1.Value.Year.ToString();
            string month = dateTimePicker1.Value.Month.ToString();
            string date = dateTimePicker1.Value.Day.ToString();
            dateformat = yr + "-" + month + "-" + date;
            string colour;
            if(checkBox1.Checked == true)
            {
                colour = textBox16.Text;
            }
            else
            {
                colour = comboBox1.SelectedItem.ToString();
            }
            int _2024 = Convert.ToInt32(textBox4.Text);
            int _2630 = Convert.ToInt32(textBox5.Text);
            int _3236 = Convert.ToInt32(textBox6.Text);
            int _L = Convert.ToInt32(textBox7.Text);
            int _XL = Convert.ToInt32(textBox8.Text);

            int _2024n = Convert.ToInt32(textBox9.Text);
            int _2630n= Convert.ToInt32(textBox10.Text);
            int _3236n = Convert.ToInt32(textBox11.Text);
            int _Ln = Convert.ToInt32(textBox12.Text);
            int _XLn = Convert.ToInt32(textBox13.Text);

            int tp = (_2024 + _2630 + _3236 + _L + _XL);
            int total = (_2024*_2024n) + (_2630*_2630n) + (_3236*_3236n) + (_L*_Ln) + (_XL*_XLn);
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try { 
            MySqlConnection conn = new MySqlConnection(connect);
            MySqlCommand com = conn.CreateCommand();
            com.CommandText = "insert into orders(artno,customer,date,colour,_2024,_2630,_3236,L,XL,pieces,total) values(" + artno + ",'" + customer + "','" + dateformat + "','" + colour + "', " + _2024 + ", " + _2630 + ", " + _3236 + ", " + _L + ","+_XL+", "+tp +", "+ total+ ")";

            conn.Open();
            com.ExecuteNonQuery();
                DialogResult res = MessageBox.Show("ORDER ADDED");
                if(res == DialogResult.OK)
                {
                    addorder ao = new addorder();
                    ao.Visible = true;
                    this.Close();
                }


            conn.Close();
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





}

private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void addorder_Load(object sender, EventArgs e)
        {
            textBox16.Enabled = false;
            button2.Enabled = false;
           
            List<string> colours = new List<string>();
            colours.Add("BLACK");
            colours.Add("WHITE");
            colours.Add("CREAM");
            colours.Add("CAMEL");
            colours.Add("PINK");
            colours.Add("RED");
            colours.Add("RANI");
            colours.Add("ROYAL BLUE");
            colours.Add("GOLD");
            colours.Add("NAVY");
            colours.Add("MEHROON");
            colours.Add("CARROT");
            colours.Add("PEACH");
            colours.Add("COFFEE");
            colours.Add("GREEN");
            colours.Add("ORANGE");
            colours.Add("RAINBOW");
           
            
            comboBox1.DataSource = colours;


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox16.Enabled = true;
            }
            else
            {
                textBox16.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            orders or = new orders();
            or.Visible = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
           
            int _2024 = Convert.ToInt32(textBox4.Text);
            int _2630 = Convert.ToInt32(textBox5.Text);
            int _3236 = Convert.ToInt32(textBox6.Text);
            int _L = Convert.ToInt32(textBox7.Text);
            int _XL = Convert.ToInt32(textBox8.Text);

            int _2024n = Convert.ToInt32(textBox9.Text);
            int _2630n = Convert.ToInt32(textBox10.Text);
            int _3236n = Convert.ToInt32(textBox11.Text);
            int _Ln = Convert.ToInt32(textBox12.Text);
            int _XLn = Convert.ToInt32(textBox13.Text);

            int tp = (_2024 + _2630 + _3236 + _L + _XL);
            int total = (_2024 * _2024n) + (_2630 * _2630n) + (_3236 * _3236n) + (_L * _Ln) + (_XL * _XLn);
            textBox14.Text = tp.ToString();
            textBox15.Text = total.ToString();

        }
    }
    
}
