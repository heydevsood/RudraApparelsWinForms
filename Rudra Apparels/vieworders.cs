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
    public partial class vieworders : Form
    {
        public vieworders()
        {
            InitializeComponent();
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void vieworders_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            radioButton1.Checked = true;
            groupBox3.Enabled = false;
            button4.Enabled = false;
            radioButton4.Checked = true;
            comboBox1.Visible = true;
            
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            textBox16.Visible = false;
            List<string> colours = new List<string>();
            colours.Add("BLACK");
            colours.Add("WHITE");
            colours.Add("GREY");
            colours.Add("CAMEL");
            colours.Add("RED");
            colours.Add("PINK");
            colours.Add("RANI");
            colours.Add("GOLD");
            colours.Add("NAVY");
            colours.Add("MEHROON");
            colours.Add("PEACH");
            colours.Add("RAINBOW");
            colours.Add("CREAM");

            comboBox5.DataSource = colours;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            orders o = new orders();
            o.Visible = true;
            this.Visible =false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                button4.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                button4.Enabled = true;
                MessageBox.Show("SEARCH AND SELECT THE ORDER TO DELETE");
                groupBox3.Enabled = false;

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                button4.Enabled = false;
                MessageBox.Show("SEARCH AND SELECT THE ORDER TO UPDATE");
                groupBox3.Enabled = true;

            }
        }

      
        private void button2_Click(object sender, EventArgs e)
        {

            string query ="select orderno as 'ORDER NO.',artno as 'ART NO.',customer as 'CUSTOMER',date as 'DATE',colour as 'COLOUR',_2024 as '20/24',_2630 as '26/30',_3236 as '32/36',L,XL,pieces as 'QUANTITY', total as 'TOTAL', status as 'STATUS' from orders where";
            if(radioButton4.Checked == true)
            {
                string val = comboBox1.SelectedItem.ToString();
                query += " artno = " + val;
                
               
            }
          else if(radioButton5.Checked == true)
            {
                string val = comboBox2.SelectedItem.ToString();
                query += " customer = '" + val + "'";
               
            }
        else if (radioButton6.Checked == true)
            {
                string val = comboBox3.SelectedItem.ToString();
                query += " colour = '" + val + "'";
             
            }
         else if (radioButton7.Checked == true)
            {
                string val = comboBox4.SelectedItem.ToString();
                query += "  status = '" + val + "'";
              
            }


           string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = query;
              

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

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                comboBox1.Visible = true;
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                try
                {
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "select distinct artno from orders";
                    List<string> art = new List<string>();

                    conn.Open();
                    MySqlDataReader r = com.ExecuteReader();
                    while (r.Read())
                    {
                        art.Add(r[0].ToString());
                    }
                    comboBox1.DataSource = art;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                comboBox1.Visible = false;
            }
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                comboBox2.Visible = true;
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                try
                {
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "select distinct customer from orders";
                    List<string> cust = new List<string>();

                    conn.Open();
                    MySqlDataReader r = com.ExecuteReader();
                    while (r.Read())
                    {
                        cust.Add(r[0].ToString());
                    }
                    comboBox2.DataSource = cust;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                comboBox2.Visible = false;
            }

        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                comboBox3.Visible = true;
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                try
                {
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "select distinct colour from orders";
                    List<string> col = new List<string>();

                    conn.Open();
                    MySqlDataReader r = com.ExecuteReader();
                    while (r.Read())
                    {
                        col.Add(r[0].ToString());
                    }
                    comboBox3.DataSource = col;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                comboBox3.Visible = false;
            }
        }

        private void radioButton7_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                comboBox4.Visible = true;
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                try
                {
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "select distinct status from orders";
                    List<string> st = new List<string>();

                    conn.Open();
                    MySqlDataReader r = com.ExecuteReader();
                    while (r.Read())
                    {
                        st.Add(r[0].ToString());
                    }
                    comboBox4.DataSource = st;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                comboBox4.Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox5.Checked==true)
            {
                textBox16.Visible = true;
            }
            else
            {
                textBox16.Visible = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int orderno = Convert.ToInt32(textBox1.Text);
            int artno = Convert.ToInt32(textBox2.Text);
            string cust = textBox3.Text;
            string colour;
            if (checkBox5.Checked == true)
            {
                colour = textBox16.Text;
            }
            else
            {
                colour = comboBox5.SelectedItem.ToString();
            }

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
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "update orders set artno = "+artno+",customer = '"+cust+"',colour = '"+colour+"',_2024 = "+_2024+",_2630 = "+_2630+",_3236 = "+_3236+",pieces = "+tp+",total = "+total+" where orderno = "+orderno+"";
               

                conn.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("NEW TOTAL QUANTITY IS "+tp+"\nNEW TOTAL AMOUNT IS "+total);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query = "select orderno as 'ORDER NO.',artno as 'ART NO.',customer as 'CUSTOMER',date as 'DATE',colour as 'COLOUR',_2024 as '20/24',_2630 as '26/30',_3236 as '32/36',L,XL,pieces as 'QUANTITY', total as 'TOTAL', status as 'STATUS' from orders";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = query;


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

        private void button4_Click(object sender, EventArgs e)
        {
            int orderno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "delete from orders where orderno = " + orderno + "";


                conn.Open();
                DialogResult res =  MessageBox.Show("ARE YOU SURE YOU WISH TO DELETE ORDER NO: " + orderno,"DELETE NOTIFICATION",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("ORDER HAS BEEN DELETED");
                }
                else
                {
                    MessageBox.Show("SELECT APPROPRIATE ORDER TO DELETE");
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string query = "select orderno as 'ORDER NO.',artno as 'ART NO.',customer as 'CUSTOMER',date as 'DATE',colour as 'COLOUR',_2024 as '20/24',_2630 as '26/30',_3236 as '32/36',L,XL,pieces as 'QUANTITY', total as 'TOTAL', status as 'STATUS' from orders";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = query;


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
}
