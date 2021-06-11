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
    public partial class empdisplay : Form
    {
        public string rec;

        public empdisplay()
        {
            InitializeComponent();
        }

        public empdisplay(string s)
        {
            InitializeComponent();
            rec = s;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = true;
            comboBox1.Visible = false;
            label2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            comboBox1.Visible = true;
            label2.Visible = true;
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            MySqlConnection conn = new MySqlConnection(connect);
            MySqlCommand com = conn.CreateCommand();
            com.CommandText = "select empname from employee";
            List<string> names = new List<string>();
            conn.Open();
            MySqlDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                names.Add(r[0].ToString());
            }
            comboBox1.DataSource = names;
            conn.Close();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            comboBox1.Visible = true;
            label2.Visible = true;
            string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
            MySqlConnection conn = new MySqlConnection(connect);
            MySqlCommand com = conn.CreateCommand();
            com.CommandText = "select distinct designation from employee";
            List<string> desigs = new List<string>();
            conn.Open();
            MySqlDataReader r1 = com.ExecuteReader();
            while (r1.Read())
            {
                desigs.Add(r1[0].ToString());
            }
            comboBox1.DataSource = desigs;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void empdisplay_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
           
            if(rec == "search")
            {
                groupBox1.Enabled = true;
                groupBox1.Text = "SEARCH";
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                comboBox1.Visible = false;
                button3.Visible = false;
            }
            else if(rec == "add")
            {
                groupBox2.Enabled = true;
                groupBox2.Text = "ADD NEW";
                textBox2.ReadOnly = true;
                button2.Visible = true;
                button5.Visible = false;

            }
            else if (rec == "update")
            {
                groupBox2.Enabled = true;
                groupBox2.Text = "UPDATE";
                textBox2.ReadOnly = false;
                button2.Visible = false;
                button5.Visible = true;

                string connect1 = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn1 = new MySqlConnection(connect1);
                MySqlCommand com1 = conn1.CreateCommand();
                com1.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee";
                conn1.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter sd = new MySqlDataAdapter(com1);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn1.Close();
            }
            else if (rec == "delete")
            {
                
                string connect1 = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn1 = new MySqlConnection(connect1);
                MySqlCommand com1 = conn1.CreateCommand();
                com1.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee";
                conn1.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter sd = new MySqlDataAdapter(com1);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn1.Close();

                groupBox1.Enabled = true;
                groupBox1.Text = "DELETE";

                


            }
            else if(rec == "view")
            {
                string connect1 = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn1 = new MySqlConnection(connect1);
                MySqlCommand com1 = conn1.CreateCommand();
                com1.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee";
                conn1.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter sd = new MySqlDataAdapter(com1);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn1.Close();           }

           
            List<string> desigs = new List<string>();
            desigs.Add("CEO");
            desigs.Add("Manager");
            desigs.Add("Supervisor");
            desigs.Add("Machine operator");
            desigs.Add("Press man");
            desigs.Add("Packer");
            desigs.Add("Washer man");



            comboBox4.DataSource = desigs;
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Visible = true;
            this.Close();
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();

                if(radioButton1.Checked == true)
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("PLEASE ENTER VALID UNIQUE ID !!!");
                    }
                    else
                    {
                        int id = Convert.ToInt32(textBox1.Text);
                        com.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee where id = " + id + "";
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter sd = new MySqlDataAdapter(com);
                        sd.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    
                }

                 if(radioButton2.Checked == true)
                {
                    
                    string name = comboBox1.SelectedValue.ToString();

                    com.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee where empname ='"+name+"'";
                        conn.Open();
                        DataTable dt = new DataTable();
                        MySqlDataAdapter sd = new MySqlDataAdapter(com);
                        sd.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    
                }

                  if(radioButton3.Checked == true)
                {

                   
                    string desig = comboBox1.SelectedItem.ToString();

                    com.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee where designation ='" + desig + "'";
                    conn.Open();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter sd = new MySqlDataAdapter(com);
                    sd.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();

                }
               
               
               
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                string d = comboBox4.SelectedItem.ToString();
                string n = textBox3.Text;
                int sal = Convert.ToInt32(textBox5.Text);
                conn.Open();
                com.CommandText = "insert into employee(empname,designation,salary) values('"+n+"','"+d+"',"+sal+")";
                com.ExecuteNonQuery();
                MessageBox.Show("RECORD STORED!");
                conn.Close();

                string connect1 = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn1 = new MySqlConnection(connect1);
                MySqlCommand com1 = conn1.CreateCommand();
                com1.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee";
                conn1.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter sd = new MySqlDataAdapter(com1);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn1.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                string d = comboBox4.SelectedItem.ToString();
                string n = textBox3.Text;
                int sal = Convert.ToInt32(textBox5.Text);
                int id = Convert.ToInt32(textBox2.Text);
                conn.Open();
                com.CommandText = "update employee set id = " + id + ",empname='" + n + "', designation = '" + d + "', salary = '" + sal + "' where id = " + id + "";
                com.ExecuteNonQuery();
                MessageBox.Show("RECORD UPDATED!");
                conn.Close();

                string connect1 = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn1 = new MySqlConnection(connect1);
                MySqlCommand com1 = conn1.CreateCommand();
                com1.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee";
                conn1.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter sd = new MySqlDataAdapter(com1);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
          try
            {
                
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection conn = new MySqlConnection(connect);
                MySqlCommand com = conn.CreateCommand();
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                if (id == "")
                {
                    MessageBox.Show("PLEASE SELECT A RECORD");
                }
                else
                {
                    DialogResult res = MessageBox.Show("DO YOU WANT TO DELETE " + name + "?", "DELETE CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        conn.Open();
                        com.CommandText = "delete from employee where id = " + id + "";
                        com.ExecuteNonQuery();
                        MessageBox.Show("RECORD DELETED!");
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("PLEASE SELECT THE RECORD YOU WISH TO DELETE");
                    }
                }
               
                com.CommandText = "select id as 'UNIQUE ID', empname as 'NAME', designation as 'DESIGNATION', salary as 'SALARY' from employee";
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
            if(rec == "update")
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
        }
    }
}
