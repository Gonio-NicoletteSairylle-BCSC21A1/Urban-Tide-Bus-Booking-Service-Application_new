using System;
using System.Globalization;
using System.Windows.Forms;

namespace Urban_Tide_Bus_Booking_Service_Application
{
    public partial class FormEdit_bus_schedules : Form
    {
        public FormEdit_bus_schedules()
        {
            InitializeComponent();
        }

        private void FormEdit_bus_schedules_Load(object sender, EventArgs e)
        {
            // Add a column to the DataGridView programmatically
            dataGridView2.Columns.Add("Time", "Time"); // Adds a column named "Time"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the time input from textBox1
            string timeInput = textBox1.Text.Trim();

            // Define the expected time format
            string[] formats = { "h:mm tt", "hh:mm tt" }; // Handles "9:00 PM" and "09:00 PM"
            DateTime parsedTime;

            // Validate the input against the time format
            if (DateTime.TryParseExact(timeInput, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime))
            {
                // Add the valid time to the DataGridView
                dataGridView2.Rows.Add(parsedTime.ToString("h:mm tt")); // Standardized format

                // Optionally, clear the TextBox after adding
                textBox1.Clear();
            }
            else
            {
                // Display an error message if the time format is invalid
                MessageBox.Show("Please enter a valid time in the format 'h:mm AM/PM'.", "Invalid Time Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index;

                // Remove the selected row
                dataGridView2.Rows.RemoveAt(selectedRowIndex);

                // Optionally, show a confirmation message
                MessageBox.Show("Selected time has been deleted.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Show an error message if no row is selected
                MessageBox.Show("Please select a time to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if a row is selected for updating
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index;

                // Get the new time from the TextBox
                string newTime = textBox1.Text.Trim();

                // Validate the new time input
                string[] formats = { "h:mm tt", "hh:mm tt" }; // Handles "9:00 PM" and "09:00 PM"
                DateTime parsedTime;

                if (DateTime.TryParseExact(newTime, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime))
                {
                    // Update the time in the DataGridView
                    dataGridView2.Rows[selectedRowIndex].Cells["Time"].Value = parsedTime.ToString("h:mm tt");

                    // Optionally, clear the TextBox after updating
                    textBox1.Clear();

                    // Show a success message
                    MessageBox.Show("Time updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Show an error message if the time format is invalid
                    MessageBox.Show("Please enter a valid time in the format 'h:mm AM/PM'.", "Invalid Time Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show a message if no row is selected
                MessageBox.Show("Please select a time to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
