using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdminHostelManager
{
    public partial class Complaints : Form
    {
        string connectionString = "Data Source=LAPTOP-5C6MNSV7\\SQLEXPRESS;Initial Catalog=HostelAdminManagementSystem;Integrated Security=True";

        public Complaints()
        {
            InitializeComponent();
            comboBox3.Items.AddRange(new string[] { "Maintenance", "Food", "Security", "Cleanliness", "Others" });
            comboBox4.Items.AddRange(new string[] { "Pending", "Resolved" });

            // Load students and rooms into comboBox1 and comboBox2.
            LoadStudents();
            LoadRooms();
        }

        private void ComplaintRegistrationForm_Load(object sender, EventArgs e)
        {
            // This function populates category and status options.
            comboBox3.Items.AddRange(new string[] { "Maintenance", "Food", "Security", "Cleanliness", "Others" });
            comboBox4.Items.AddRange(new string[] { "Pending", "Resolved" });

            // Load students and rooms into comboBox1 and comboBox2.
            LoadStudents();
            LoadRooms();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            // Add your desired functionality here or leave it empty if it's unused.
        }


        private void LoadStudents()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT studentID, Name FROM Students";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Add only student names to maintain frontend behavior
                                comboBox1.Items.Add($"{reader["Name"]} (ID: {reader["studentID"]})");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT RoomID, RoomNumber FROM Rooms";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Add only room numbers to maintain frontend behavior
                                comboBox2.Items.Add($"Room {reader["RoomNumber"]} (ID: {reader["RoomID"]})");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading rooms: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure valid selections are made
                if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all fields before submitting.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Extract data from comboBoxes and other controls
                string studentID = ExtractIDFromComboBoxItem(comboBox1.SelectedItem.ToString());
                string roomID = ExtractIDFromComboBoxItem(comboBox2.SelectedItem.ToString());
                DateTime dateFiled = dateTimePicker1.Value;
                string category = comboBox3.SelectedItem.ToString();
                string description = textBox1.Text;
                string status = comboBox4.SelectedItem.ToString();

                // Call the InsertComplaint function
                InsertComplaint(studentID, roomID, dateFiled, category, description, status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExtractIDFromComboBoxItem(string comboBoxItemText)
        {
            // Extract the ID from the ComboBox item text (e.g., "John Doe (ID: 123)")
            int startIndex = comboBoxItemText.IndexOf("(ID: ") + 5; // Find the start of the ID
            int endIndex = comboBoxItemText.IndexOf(")", startIndex); // Find the end of the ID
            return comboBoxItemText.Substring(startIndex, endIndex - startIndex);
        }

        private void InsertComplaint(string studentID, string roomID, DateTime dateFiled, string category, string description, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Complaints (studentID, RoomID, DateFiled, Category, description, status) 
                                     VALUES (@studentID, @RoomID, @DateFiled, @Category, @description, @status)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@studentID", studentID);
                        command.Parameters.AddWithValue("@RoomID", roomID);
                        command.Parameters.AddWithValue("@DateFiled", dateFiled);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@status", status);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Complaint registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to register the complaint. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting the complaint: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
