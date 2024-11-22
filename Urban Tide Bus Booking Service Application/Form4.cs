using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Urban_Tide_Bus_Booking_Service_Application
{
    public partial class Form4CreateAccount : Form
    {
        public Form4CreateAccount()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string createusername = textBoxusername.Text;
            string createpassword = txtConfirmPassword.Text; 
            string confirmPassword = txtConfirmPassword.Text; 
            DateTime selectedDate = dateTimePicker1.Value;

            // Check if username and password are provided
            if (string.IsNullOrWhiteSpace(createusername) || string.IsNullOrWhiteSpace(createpassword))
            {
                MessageBox.Show("Error: Username and Password cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the "Create Password" matches the "Confirm Password"
            if (createpassword != confirmPassword)
            {
                MessageBox.Show("Error: Password and Confirm Password do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Define the file path where user data will be saved
            string filePath = @"C:\Users\Bravo\Documents\Data Structures\newacc.json";

            // If the file exists, read the existing data
            List<User> users = new List<User>();
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<User>>(jsonContent) ?? new List<User>();
            }

            // Check if the username already exists in the list
            bool userExists = false;
            foreach (var user in users)
            {
                if (user.Username == createusername)
                {
                    // If username exists, update the password and birthdate
                    user.Password = createpassword;
                    user.Birthdate = selectedDate;
                    userExists = true;
                    break;
                }
            }

            if (!userExists)
            {
                // If the user doesn't exist, add a new user
                var newUser = new User
                {
                    Username = createusername,
                    Password = createpassword,
                    Birthdate = selectedDate
                };
                users.Add(newUser);
            }

            // Save the updated list back to the JSON file
            File.WriteAllText(filePath, JsonConvert.SerializeObject(users, Formatting.Indented));
            // Open the user main menu form
            Form2UserMainMenu mainMenuForm = new Form2UserMainMenu();
            mainMenuForm.Username = createusername; // Pass the username
            mainMenuForm.Show();
            this.Hide();
        }
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public DateTime Birthdate { get; set; }
        }

        private void Form4CreateAccount_Load(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
