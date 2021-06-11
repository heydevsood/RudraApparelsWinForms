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
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainpage mp = new mainpage();
            mp.Visible = true;
            this.Visible = false;
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            textBox18.Enabled = false;
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
            comboBox3.DataSource = colours;
            List<string> status = new List<string>();
            status.Add("UNUSED");
            status.Add("USING");
            status.Add("FINISHED");
            comboBox2.DataSource = status;



            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "select srno as 'SR NO.',colour as 'Colour',lotno as 'LOT NO.',idate as 'Date',wt as 'Kgs',status as 'Status' from inventory";


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

        private void button3_Click(object sender, EventArgs e)
        {
            int actual_wt = Convert.ToInt32(textBox14.Text);
            int q_2024, q_2630, q_3236, q_l, q_xl;
            int wt_2024, wt_2630, wt_3236, wt_l, wt_xl;
            q_2024 = Convert.ToInt32(textBox3.Text);
            q_2630 = Convert.ToInt32(textBox5.Text);
            q_3236 = Convert.ToInt32(textBox7.Text);
            q_l = Convert.ToInt32(textBox9.Text);
            q_xl = Convert.ToInt32(textBox12.Text);

            wt_2024 = Convert.ToInt32(textBox4.Text);
            wt_2630 = Convert.ToInt32(textBox6.Text);
            wt_3236 = Convert.ToInt32(textBox8.Text);
            wt_l = Convert.ToInt32(textBox10.Text);
            wt_xl = Convert.ToInt32(textBox11.Text);

            int used = ((q_2024*wt_2024) + (q_2630*wt_2630) + (q_3236*wt_3236) + (q_l*wt_l) + (q_xl*wt_xl))/1000;
            int left = actual_wt - used;
            textBox17.Text = used.ToString();
            textBox16.Text = left.ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked == true)
            {
                groupBox4.Enabled = true;
                button4.Visible = false;
            }
            else
            {
                groupBox4.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                groupBox2.Enabled = true;
                button6.Visible = false;
                button2.Visible = true;
                comboBox2.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                groupBox2.Enabled = true;
                button2.Visible = false;
                button6.Visible = true;
                comboBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox3.Enabled = true;


                
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                try
                {
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "select srno as 'SR NO.',colour as 'Colour',lotno as 'LOT NO.',idate as 'Date',wt as 'Kgs',status as 'Status' from inventory";


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
                groupBox3.Enabled = false;
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                groupBox4.Enabled = true;
                button4.Visible = true;
                MessageBox.Show("SELECT THE LOT TO DELETE");
            }
            else
            {
                groupBox4.Enabled = false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox18.Enabled = true;
                
            }
            else
            {
                textBox18.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string col = comboBox3.SelectedItem.ToString();
            string query = "select srno as 'SR NO.',colour as 'Colour',lotno as 'LOT NO.',idate as 'Date',wt as 'Kgs',status as 'Status' from inventory where colour = '" + col + "'";
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

        private void button4_Click(object sender, EventArgs e)
        {
            string lotno = textBox19.Text;
            string query = "delete from inventory where lotno = '" + lotno + "'";
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = query;


                conn.Open();
                DialogResult res = MessageBox.Show("ARE YOU SURE YOU WISH TO DELETE LOT NO. : " +lotno+" ?", "DELETE CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.Yes)
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("LOT DELETED !");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(radioButton3.Checked == true)
            {
                textBox19.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }

            if(radioButton2.Checked == true)
            {
                try
                {
                    int srno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
               
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "select srno as 'SR NO.',colour as 'Colour',lotno as 'LOT NO.',idate as 'Date',wt as 'Kgs',status as 'Status' from inventory where srno = " + srno + "";


                    conn.Open();
                    MySqlDataReader r = com.ExecuteReader();
                    while (r.Read())
                    {
                        textBox13.Text = r[2].ToString();
                        textBox14.Text = r[4].ToString();
                        textBox15.Text = r[1].ToString();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            if(radioButton5.Checked == true)
            {
                try
                {
                    int srno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
               
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "select srno as 'SR NO.',colour as 'Colour',lotno as 'LOT NO.',idate as 'Date',wt as 'Kgs',status as 'Status' from inventory where srno = " + srno + "";


                    conn.Open();
                    MySqlDataReader r = com.ExecuteReader();
                    while (r.Read())
                    {
                        comboBox1.Text = r[1].ToString();
                        textBox2.Text = r[2].ToString();
                        textBox1.Text = r[4].ToString();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string col;
            if(checkBox1.Checked == true)
            {
                col = textBox18.Text;
            }
            else
            {
                col = comboBox1.SelectedItem.ToString();
            }
            string lotno = textBox2.Text;
         // string status = comboBox2.SelectedItem.ToString();
            double wt = Convert.ToDouble(textBox1.Text);
            string dateformat;
            string yr = dateTimePicker1.Value.Year.ToString();
            string month = dateTimePicker1.Value.Month.ToString();
            string date = dateTimePicker1.Value.Day.ToString();
            dateformat = yr + "-" + month + "-" + date;


            string query = "insert into inventory(colour,lotno,idate,wt) values('"+col+"','"+lotno+"','"+dateformat+"',"+wt+")";
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = query;


                conn.Open();
               
                    com.ExecuteNonQuery();
                MessageBox.Show("LOT ADDED TO STOCK");
              
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int srno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string lotno = textBox2.Text;
            string status = comboBox2.SelectedItem.ToString();
            double wt = Convert.ToDouble(textBox1.Text);
            string dateformat;
            string yr = dateTimePicker1.Value.Year.ToString();
            string month = dateTimePicker1.Value.Month.ToString();
            string date = dateTimePicker1.Value.Day.ToString();
            dateformat = yr + "-" + month + "-" + date;


            string query = "update inventory set lotno = '"+lotno +"', status = '"+status+"', wt = "+wt+", idate = '"+dateformat+"' where srno = "+srno+"";
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = query;


                conn.Open();

                com.ExecuteNonQuery();
                MessageBox.Show("LOT UPDATED TO STOCK");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
