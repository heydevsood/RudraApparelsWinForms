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
    public partial class catalouge : Form
    {
        public catalouge()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainpage mp = new mainpage();
            mp.Visible = true;
            this.Visible = false;
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible =false;
            productedit pe = new productedit();
            pe.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "Select artno as 'ART NO.',artname as 'NAME',artsize as 'SIZE',season as 'SEASON',colour as'COLOUR',price as 'PRICE' from products where season = 'summer'";

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

      

        private void button6_Click(object sender, EventArgs e)
        {
          

        }


        private void catalouge_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            button7.Enabled = false;
            if(checkBox1.Checked == true)
            {
                button7.Enabled = true;
                MessageBox.Show("SELECT THE ITEM IN TABLE TO DELETE !");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "Select artno as 'ART NO.',artname as 'NAME',artsize as 'SIZE',season as 'SEASON',colour as'COLOUR',price as 'PRICE' from products where season = 'winter'";

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "Select artno from products";

                conn.Open();
                MySqlDataReader r = com.ExecuteReader();
                List<string> artno = new List<string>();
                while(r.Read())
                {
                    artno.Add(r[0].ToString());
                }
                comboBox1.DataSource = artno;



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "Select artname from products";

                conn.Open();
                MySqlDataReader r = com.ExecuteReader();
                List<string> names = new List<string>();
                while (r.Read())
                {
                    names.Add(r[0].ToString());
                }
                comboBox1.DataSource = names;



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                int artno = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                try
                {
                    string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "Select artno as 'ART NO.',artname as 'NAME',artsize as 'SIZE',season as 'SEASON',colour as'COLOUR',price as 'PRICE' from products where artno = '"+artno+"'";

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
            else if(radioButton2.Checked == true)
            {
                string artname = comboBox1.SelectedItem.ToString();
                try
                {
                    string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "Select artno as 'ART NO.',artname as 'NAME',artsize as 'SIZE',season as 'SEASON',colour as'COLOUR',price as 'PRICE' from products where artname = '" + artname + "'";

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
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            int artno = 0;
            try
            {
                 artno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("PLEASE SELECT THE ITEM TO DELETE","DELETE !!!",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }

            DialogResult res = MessageBox.Show("DO YOU WISH TO DELETE ART NO. " +  artno + " ?","DELETE CONFIRMATION",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {

                try
                {
                    string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "delete from products where artno = '" + artno + "'";

                    conn.Open();
                    DialogResult fin = MessageBox.Show("CLICKING OK WOULD DELETE THE SELECTED ITEM ! DO YOU WISH TO DELETE ?","FINAL CONFIRMATION",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
                    if (fin == DialogResult.OK)
                    {

                        com.ExecuteNonQuery();
                    }
                    else
                    {
                        
                    }

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
            else
            {
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button7.Enabled = true;
                MessageBox.Show("SELECT THE ITEM IN TABLE TO DELETE !");
            }
            else if(checkBox1.Checked == false)
            {
                button7.Enabled = false;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int artno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "select img, description from products where artno = '" + artno + "'";

                conn.Open();
                MySqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    richTextBox1.Text = r["description"].ToString();
                    textBox1.Text = r["img"].ToString();
                    string img = textBox1.Text;

                    pictureBox1.ImageLocation = img;
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
