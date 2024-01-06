using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace form1
{
    public partial class Login1 : Form
    {
        private string connectionString;
        private MySqlConnection connection;
        public string password;
        public string role;

        public string name;

        public Login1()
        {
            InitializeComponent();
            string server = "sql12.freesqldatabase.com"; 
            string database = "sql12672198"; 
            string uid = "sql12672198"; 
            string pwd = "PpJwhQtSf3"; 

            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={pwd};";
            connection = new MySqlConnection(connectionString);
        }



        private bool CheckLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Login WHERE Username = @Username AND Password = @Password AND role= @role";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@role", role);


                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return count > 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //login lg = new login();
            // lg.Show();
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                string password = txtPassword.Text;
                string username = txtUsername.Text;
                if (comboBox1.SelectedIndex == 0)
                {
                    role = "s";
                }
                else
                {
                    role = "m";

                }

                
                if (CheckLogin(username, password))
                {



                    var selectedValue = comboBox1.SelectedItem;
                    if (selectedValue != null)
                    {
                        var selectedValueString = selectedValue.ToString();
                        if (selectedValueString == "Employee")
                        {
                            Form1 form1 = new Form1();
                            form1.Show();
                            this.Hide();
                        }
                        else
                        {
                            Manager form2 = new Manager();
                            form2.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxShow.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void chkBoxShow_CheckedChanged(object sender, EventArgs e)
        {

            if (chkBoxShow.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
