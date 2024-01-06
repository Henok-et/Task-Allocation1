using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Text;

namespace form1
{
    public partial class AddStaff : Form
    {
        private string connectionString;
        private MySqlConnection staffConnection, loginConnection;

        public AddStaff()
        {
            InitializeComponent();
            string server = "sql12.freesqldatabase.com";
            string database = "sql12672198";
            string uid = "sql12672198";
            string pwd = "PpJwhQtSf3";

            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={pwd};";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int staffid = int.Parse(txtid.Text);
                string staffname = txtname.Text;
                string gender = radioButton1.Checked ? "M" : (radioButton2.Checked ? "F" : "");
                string email = txtemail.Text;

                using (staffConnection = new MySqlConnection(connectionString))
                {
                    staffConnection.Open();

                    string insertStaffQuery = "INSERT INTO Staff (StaffID, Name, Gender, Email) " +
                                              "VALUES (@StaffID, @Name, @Gender, @Email)";

                    using (MySqlCommand staffCommand = new MySqlCommand(insertStaffQuery, staffConnection))
                    {
                        staffCommand.Parameters.AddWithValue("@StaffID", staffid);
                        staffCommand.Parameters.AddWithValue("@Name", staffname);
                        staffCommand.Parameters.AddWithValue("@Gender", gender);
                        staffCommand.Parameters.AddWithValue("@Email", email);

                        staffCommand.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully into Staff!");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login1  login1 = new Login1();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string role = "s";

                using ( loginConnection = new MySqlConnection(connectionString))
                {
                    loginConnection.Open();

                    string insertLoginQuery = "INSERT INTO Login (Username, Password, role) " +
                                              "VALUES (@Username, @Password, @role)";

                    using (MySqlCommand loginCommand = new MySqlCommand(insertLoginQuery, loginConnection))
                    {
                        loginCommand.Parameters.AddWithValue("@Username", username);
                        loginCommand.Parameters.AddWithValue("@Password", password);
                        loginCommand.Parameters.AddWithValue("@role", role);

                        loginCommand.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully into login!");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


