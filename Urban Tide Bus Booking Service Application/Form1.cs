using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Urban_Tide_Bus_Booking_Service_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        // Path for the JSON file with user data
        string filePath = @"C:\Users\Bravo\Documents\Data Structures\users.json";

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1Username.Text;  
            string password = textBox2Password.Text;  

            try
            {
                if (File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);  // Read JSON content

                    // Deserialize JSON into List of User objects
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

                    bool userFound = false;

                    // Check if the input username and password match an entry in the users list
                    foreach (var user in users)
                    {
                        if (user.Username == username && user.Password == password) // Validate credentials
                        {
                            userFound = true;
                            break;
                        }
                    }

                    // Admin login check
                    if (username == "admin" && password == "admin123")
                    {
                        MessageBox.Show("Admin login successful!");

                        // Show Form3 (Administrator Page) for admin
                        Form3AdministratorPage form3 = new Form3AdministratorPage();
                        form3.Show();
                        this.Hide();  
                    }
                    
                    else if (userFound)
                    {

                        // Show Form2 (User Main Menu) for regular users
                        Form2UserMainMenu form2 = new Form2UserMainMenu();
                        form2.Show();
                        this.Hide();  
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!");
                    }
                }
                else
                {
                    MessageBox.Show("User data file not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void button2guest_Click(object sender, EventArgs e)
        {
            Form4CreateAccount form4 = new Form4CreateAccount();
            form4.Show();
            this.Hide();
        }
        private void linkLabel1Forgotuserorpass_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormforgetPass form4 = new FormforgetPass();
            form4.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
