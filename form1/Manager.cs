using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;

namespace form1
{
    public partial class Manager : Form
    {
        public string connectionString;
        private MySqlConnection connection;
        public string password;
        public string role;

        public string name;

        public Manager()
        {
            InitializeComponent();
            string server = "sql12.freesqldatabase.com"; // Update with your server details
            string database = "sql12672198"; // Update with your database name
            string uid = "sql12672198"; // Update with your username
            string pwd = "PpJwhQtSf3"; // Update with your password

            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={pwd};";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string staffname = textBox1.Text;
                string name = textBox5.Text;
                int eid = int.Parse(textBox6.Text);
                int gtid = int.Parse(textBox3.Text);
                string gtiltle = textBox2.Text;
                string managerid = textBox8.Text;
                string doc = richTextBox1.Text;
                DateTime sdate = DateTime.Now;
                DateTime edate = dateTimePicker1.Value;

                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    string insertQuery = "INSERT INTO GeneralTask (staffname, Name, staffID, GeneralTaskID, Document, StartDate, EndDate, managerid) " +
                                         "VALUES (@staffname, @Name, @EmployeeID, @GeneralTaskID,  @Document, @StartDate, @EndDate, @managerid)";

                    using (MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@staffname", staffname);
                        mySqlCommand.Parameters.AddWithValue("@Name", name);
                        mySqlCommand.Parameters.AddWithValue("@EmployeeID", eid);
                        mySqlCommand.Parameters.AddWithValue("@GeneralTaskID", gtid);
                        mySqlCommand.Parameters.AddWithValue("@Document", doc);
                        mySqlCommand.Parameters.AddWithValue("@StartDate", sdate);
                        mySqlCommand.Parameters.AddWithValue("@EndDate", edate);
                        mySqlCommand.Parameters.AddWithValue("@managerid", managerid);

                        mySqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.ShowDialog();
            try
            {
                richTextBox1.Text = File.ReadAllText(openfile.FileName, Encoding.ASCII);
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
        }

        // Other methods and event handlers...

        private void tabPage2_Click(object sender, EventArgs e)
        {
            // Your code for tabPage2 click event
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           Login1 login1 = new Login1();
            login1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddStaff addStaff = new AddStaff();
            addStaff.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
