using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Rudra_Apparels
{
    public partial class generate_bill : Form
    {
        public void getinvoice()
        {
            try
            {
                string date = DateTime.Now.ToShortDateString();


                SqlConnection con = new SqlConnection(constring);
                string query = String.Format("insert into invoice(year) values('{0}')",date);
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();


                SqlConnection con1 = new SqlConnection(constring);
                string query1 = String.Format("select max(id),max(year) from invoice");
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                DateTime dt = new DateTime();
               
                int id = 0;

                con1.Open();

                SqlDataReader r = cmd1.ExecuteReader();
                while(r.Read())
                {
                    id = Convert.ToInt32(r[0]);
                    dt = Convert.ToDateTime(r[1]);
                }

                int yr = dt.Year - 2000;
                string invoice = String.Format("{0}/{1}-{2}", id, yr, yr - 1);
                label7.Text = invoice;

                con1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void reflect()
        {
            try
            {
               

                SqlConnection con = new SqlConnection(constring);
                string query = String.Format("select sr as 'Sr no.',artname as 'Description of Goods',hsn as 'HSN/SAC',quantity as 'Quantity',rate as 'Rate',amount as 'Amount' from bill");
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
                
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\DOT NET PROJECTS\Rudra Apparels\Rudra Apparels\rudra apparels.mdf;Integrated Security=True";
        public generate_bill()
        {
            InitializeComponent();

            try
            {
                
                string connect = "server = '127.0.0.1'; user id = 'root'; password = ''; database = 'rudra apparels'";
                MySqlConnection con = new MySqlConnection(connect);
                MySqlCommand com = con.CreateCommand();
                com.CommandText = "select artname from products";
                con.Open();
                List<string> art = new List<string>();
                MySqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    string name = r[0].ToString();
                    art.Add(name);


                }

                comboBox1.DataSource = art;

                DateTime dt = DateTime.Now;
                string date = dt.ToString("dd-MMM-yyyy");
                label15.Text = date;



                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }


        void PrintPanel(object o, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.groupBox1.Width, this.groupBox1.Height);
            this.groupBox1.DrawToBitmap(bmp, new Rectangle(0, 0, this.groupBox1.Width, this.groupBox1.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {


                SqlConnection con = new SqlConnection(constring);
                string query = String.Format("truncate table bill");
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                getinvoice();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPanel);
            pd.Print();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "<Name>" || textBox1.Text == "")
            {
                MessageBox.Show("Enter Customer Name on Bill");
            }
            else
            {
                try
                {


                    SqlConnection con = new SqlConnection(constring);
                    string query = String.Format("select sum(quantity),sum(amount) from bill");
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    int quant = 0;
                    double total = 0;
                    while (r.Read())
                    {
                        quant = Convert.ToInt32(r[0]);
                        total = Convert.ToDouble(r[1]);
                    }

                    double gst = total * (2.5 / 100);
                    total = total + (2 * gst);
                    con.Close();
                    label29.Text = gst.ToString();
                    label30.Text = gst.ToString();
                    label31.Text = quant.ToString();
                    label32.Text = total.ToString();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainpage mp = new mainpage();
            mp.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string artname = comboBox1.SelectedItem.ToString();
                int hsn = Convert.ToInt32(textBox6.Text);
                int quant = Convert.ToInt32(textBox7.Text);
                double rate = Convert.ToDouble(textBox8.Text);
                double amount = quant * rate;

                SqlConnection con = new SqlConnection(constring);
                string query = String.Format("insert into bill(artname,hsn,quantity,rate,amount) values('{0}',{1},{2},{3},{4})", artname, hsn, quant, rate, amount);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                reflect();
                
                textBox7.Text = "";
                textBox8.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
