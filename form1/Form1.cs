using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace form1
{
    public partial class Form1 : Form
    {
        private string connectionString;
        public Form1()
        {
            InitializeComponent();
            string server = "sql12.freesqldatabase.com";
            string database = "sql12672198";
            string uid = "sql12672198";
            string pwd = "PpJwhQtSf3";

            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={pwd};";
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int staffId = int.Parse(textBox1.Text);
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT GeneralTaskID, Name, StaffID, StaffName, Document, StartDate, EndDate, ManagerID " +
                                   "FROM GeneralTask " +
                                   "WHERE StaffId = @StaffId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@StaffId", staffId);

                        
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                      

                        
                        
                    }
                }
            }
            catch (MySqlException ex)
            {
              
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login1 login1 = new Login1();   
            login1.Show();
            this.Hide();
        }
    }
}
