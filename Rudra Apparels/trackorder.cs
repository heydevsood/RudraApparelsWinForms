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
    public partial class trackorder : Form
    {
        public trackorder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orders o = new orders();
            o.Visible = true;
            this.Visible = false;
        }

        private void trackorder_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            List<string> status = new List<string>();
            status.Add("PENDING");
            status.Add("PROCESSING");
            status.Add("WASHING");
            status.Add("PRESSING");
            status.Add("PACKING");
            status.Add("DONE");
            comboBox1.DataSource = status;
            


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                groupBox3.Enabled = true;
                MessageBox.Show("SELECT THE ORDER TO ENTER PROGRESS OR REVIEW");
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
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
                textBox9.Text = "0";
                textBox10.Text = "0";
                textBox11.Text = "0";
                textBox12.Text = "0";
                textBox13.Text = "0";
            }
            else
            {
                groupBox3.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                groupBox2.Enabled = true;
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
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
                MessageBox.Show("SELECT THE ORDER TO SET STATUS");


            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string status = comboBox1.SelectedItem.ToString();
            int orderno = Convert.ToInt32(textBox1.Text);
            
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = "update orders set status = '"+status+"' where orderno = "+orderno+" ";

                conn.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("ORDER STATUS UPDATED");
               
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    int orderno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    textBox1.Text = orderno.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n PLEASE SELECT ANY ORDER");
                }
            }
            else if(radioButton2.Checked == true)
            {
                try
                {
                    int orderno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    textBox14.Text = orderno.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    textBox22.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();

                    textBox16.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    textBox15.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    textBox8.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n PLEASE SELECT ANY ORDER");
                }

            }
            else if(radioButton5.Checked == true)
            {
                try
                {
                    int orderno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    textBox23.Text = orderno.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n PLEASE SELECT ANY ORDER");
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox22.Text == "PENDING")
            {
                MessageBox.Show("ORDER STATUS IS PENDING ! KINDLY UPDATE STATUS FIRST !");
            }
            else
            {
                string dateformat;
                string yr = dateTimePicker1.Value.Year.ToString();
                string month = dateTimePicker1.Value.Month.ToString();
                string date = dateTimePicker1.Value.Day.ToString();
                dateformat = yr + "-" + month + "-" + date;
                int orderno = Convert.ToInt32(textBox14.Text);
                int artno = Convert.ToInt32(textBox2.Text);
                string cust = textBox3.Text;
                string colour = textBox16.Text;
                int _2024 = Convert.ToInt32(textBox9.Text);
                int _2630 = Convert.ToInt32(textBox10.Text);
                int _3236 = Convert.ToInt32(textBox11.Text);
                int L = Convert.ToInt32(textBox12.Text);
                int XL = Convert.ToInt32(textBox13.Text);

                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                try
                {
                    MySqlConnection conn = new MySqlConnection(connect);
                    MySqlCommand com = conn.CreateCommand();
                    com.CommandText = "insert into trackorders values(" + orderno + "," + artno + ",'" + cust + "','" + dateformat + "','" + colour + "', " + _2024 + ", " + _2630 + ", " + _3236 + ", " + L + "," + XL + ")";

                    conn.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("PROGRESS UPDATED !");

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked == true)
            {
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
                textBox11.ReadOnly = true;
                textBox12.ReadOnly = true;
                textBox13.ReadOnly = true;
                button3.Enabled = false;
                button4.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked == true)
            {
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
                textBox11.ReadOnly = false;
                textBox12.ReadOnly = false;
                textBox13.ReadOnly = false;
                button3.Enabled = true;
                button4.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int orderno = Convert.ToInt32(textBox14.Text);
            int ini2024 = Convert.ToInt32(textBox4.Text);
            int ini2630 = Convert.ToInt32(textBox5.Text);
            int ini3236 = Convert.ToInt32(textBox6.Text);
            int iniL = Convert.ToInt32(textBox7.Text);
            int iniXL = Convert.ToInt32(textBox8.Text);
            int t2024, t2630, t3236, tL, tXL;

            string query = "SELECT SUM(_2024),SUM(_2630),SUM(_3236),SUM(L),SUM(XL) from trackorders where orderno = "+orderno+"";
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            try
            {

               
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                com.CommandText = query;

                conn.Open();
                MySqlDataReader r = com.ExecuteReader();
                while(r.Read())
                {
                    t2024 = Convert.ToInt32(r[0].ToString());
                    t2630 = Convert.ToInt32(r[1].ToString());
                    t3236 = Convert.ToInt32(r[2].ToString());
                    tL = Convert.ToInt32(r[3].ToString());
                    tXL = Convert.ToInt32(r[4].ToString());
                    textBox9.Text = "" + t2024;
                    textBox10.Text = ""+t2630;
                    textBox11.Text = ""+t3236;
                    textBox12.Text = ""+tL;
                    textBox13.Text = ""+tXL;
                    int f2024, f2630, f3236, fL, fXL;
                    f2024 = ini2024 - t2024;
                    f2630 = ini2630 - t2630;
                    f3236 = ini3236 - t3236;
                    fL = iniL - tL;
                    fXL = iniXL - tXL;
                    textBox17.Text = "" +f2024;
                    textBox18.Text = "" + f2630;
                    textBox19.Text = "" + f3236;
                    textBox20.Text = "" + fL;
                    textBox21.Text = "" + fXL;
                }
          
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           


        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                groupBox4.Enabled = true;
                MessageBox.Show("SELECT THE ORDER TO VIEW PROGRESS SUMMARY");
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                string query = "SELECT orderno as 'ORDER NO.',artno as 'ART NO.',customer as 'CUSTOMER',date as 'DATE',colour as 'COLOUR', SUM(_2024) as '20/24',SUM(_2630) as '26/30',SUM(_3236) as '32/36',SUM(L) as 'L',SUM(XL) as 'XL' from trackorders group by orderno";
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
            else
            {
                groupBox4.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int orderno = Convert.ToInt32(textBox23.Text);
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            string query = "select orderno as 'ORDER NO.',artno as 'ART NO.',customer as 'CUSTOMER',date as 'DATE',colour as 'COLOUR',_2024 as '20/24',_2630 as '26/30',_3236 as '32/36',L,XL from trackorders where orderno = "+orderno+"";
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

        private void button7_Click(object sender, EventArgs e)
        {
            int orderno = Convert.ToInt32(textBox23.Text);
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            string query = "SELECT orderno as 'ORDER NO.',artno as 'ART NO.',customer as 'CUSTOMER',date as 'DATE',colour as 'COLOUR', SUM(_2024) as '20/24',SUM(_2630) as '26/30',SUM(_3236) as '32/36',SUM(L) as 'L',SUM(XL) as 'XL' from trackorders where orderno = " + orderno + " group by orderno ";
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

        private void button6_Click(object sender, EventArgs e)
        {
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            string query = "SELECT orderno as 'ORDER NO.',artno as 'ART NO.',customer as 'CUSTOMER',date as 'DATE',colour as 'COLOUR', SUM(_2024) as '20/24',SUM(_2630) as '26/30',SUM(_3236) as '32/36',SUM(L) as 'L',SUM(XL) as 'XL' from trackorders group by orderno";
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
