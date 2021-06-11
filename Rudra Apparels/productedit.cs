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
    public partial class productedit : Form
    {
        public productedit()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                MessageBox.Show("PLEASE SELECT THE ITEM TO UPDATE");

            }
            button4.Visible = false;
            button5.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            string color = cd.Color.Name;
            textBox4.Text = color;
            textBox4.BackColor = cd.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            catalouge ct = new catalouge();
            this.Visible = false;
            ct.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
            button5.Visible = false;
            if(radioButton1.Checked == true)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                pictureBox1.ImageLocation = "";
                richTextBox1.Text = "";
            }
        }

        private void productedit_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            button4.Visible = false;
            button5.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            List<string> season = new List<string>();
            season.Add("Summer");
            season.Add("Winter");
            comboBox1.DataSource = season;
            List<string> sizes = new List<string>();
            sizes.Add(@"20/24");
            sizes.Add(@"26/30");
            sizes.Add(@"32/36");
            sizes.Add(@"L");
            sizes.Add(@"XL");
            sizes.Add(@"XXL");
            comboBox2.DataSource = sizes;

            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "Select artno as 'ART NO.',artname as 'NAME',artsize as 'SIZE',season as 'SEASON',colour as'COLOUR',price as 'PRICE' from products";

                conn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter sd = new MySqlDataAdapter(com);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.ShowDialog();
            string path = System.IO.Path.GetFullPath(of.FileName);
            textBox5.Text = path;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int artno = Convert.ToInt32(textBox1.Text);
                string name = textBox2.Text;
                string season = comboBox1.SelectedItem.ToString();
                string size = comboBox2.SelectedItem.ToString();
                string colour = textBox4.Text;
                double price = Convert.ToDouble(textBox6.Text);
                string img = textBox5.Text;
                string path = img.Replace(@"\", @"\\");
                string descript = richTextBox1.Text;
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "insert into products values("+artno+",'"+name+"','"+season+"','"+size+"','"+colour+"',"+price+",'"+path+"','"+descript+"')";

                conn.Open();
                com.ExecuteNonQuery();


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "Select artno as 'ART NO.',artname as 'NAME',artsize as 'SIZE',season as 'SEASON',colour as'COLOUR',price as 'PRICE' from products";

                conn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter sd = new MySqlDataAdapter(com);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
           
            try
            {
                int artno = Convert.ToInt32(textBox1.Text);
                string name = textBox2.Text;
                string season = comboBox1.SelectedItem.ToString();
                string size = comboBox2.SelectedItem.ToString();
                string colour = textBox4.Text;
                double price = Convert.ToDouble(textBox6.Text);
                string img = textBox5.Text;
                
                string path = img.Replace(@"\",@"\\");
                string descript = richTextBox1.Text;
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "update products set artno = "+artno+",artname = '"+name+"',season = '"+season+"',artsize= '"+size+"',colour = '"+colour+"',price = "+price+",img = '"+path+"',description = '"+descript+"' where artno = "+artno+"";

                conn.Open();
                com.ExecuteNonQuery();


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "Select artno as 'ART NO.',artname as 'NAME',artsize as 'SIZE',season as 'SEASON',colour as'COLOUR',price as 'PRICE' from products";

                conn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter sd = new MySqlDataAdapter(com);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string colour  = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox4.Text = colour;
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                try
                {
                    string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    int artno = Convert.ToInt32(textBox1.Text);
                    com.CommandText = "Select img,description from products where artno = "+artno+"";

                    conn.Open();
                    MySqlDataReader r = com.ExecuteReader();
                    while(r.Read())
                    {
                        pictureBox1.ImageLocation = r[0].ToString();
                        richTextBox1.Text = r[1].ToString();
                    }



                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
    }
}
