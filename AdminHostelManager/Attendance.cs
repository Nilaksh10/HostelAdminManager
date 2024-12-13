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

namespace AdminHostelManager
{
    public partial class Attendance : Form
    {
        string connectionString = "Data Source=LAPTOP-5C6MNSV7\\SQLEXPRESS;Initial Catalog=HostelAdminManagementSystem;Integrated Security=True";
        public Attendance()
        {
            InitializeComponent();
            dateTimePicker3.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure valid input
                if (string.IsNullOrEmpty(textBox2.Text) || dateTimePicker1.Value == null || dateTimePicker2.Value == null)
                {
                    MessageBox.Show("Please fill in all fields before submitting.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Extract data from controls
                string studentID = textBox2.Text;
                DateTime timeIn = dateTimePicker1.Value;
                DateTime timeOut = dateTimePicker2.Value;
                DateTime date = dateTimePicker3.Value;

                // Call function to insert attendance
                InsertAttendance(studentID, timeIn, timeOut, date);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertAttendance(string StudentID, DateTime TimeIn, DateTime TimeOut, DateTime Date)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Attendance (StudentID, TimeIn, TimeOut, Date) 
                                     VALUES (@StudentID, @TimeIn, @TimeOut, @Date)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        command.Parameters.AddWithValue("@TimeIn", TimeIn);
                        command.Parameters.AddWithValue("@TimeOut", TimeOut);
                        command.Parameters.AddWithValue("@Date", Date);

                        // Open connection and execute the query
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Attendance recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to record attendance. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting attendance: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard1 = new Dashboard();
            dashboard1.Show();
            this.Hide();
        }
    }
}
