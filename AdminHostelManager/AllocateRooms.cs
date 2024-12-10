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
    public partial class AllocateRooms : Form
    {
        public AllocateRooms()
        {
            InitializeComponent();
        }
        // Define connection string (change to match your database)
        private string connectionString = "Data Source=LAPTOP-5C6MNSV7\\SQLEXPRESS;Initial Catalog=HostelAdminManagementSystem;Integrated Security=True";

        // Fetch data from the database
        private DataTable ExecuteSelectQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters if any
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(resultTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error executing SELECT query: " + ex.Message);
                }

                return resultTable;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AllocateRooms_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadRooms();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error executing query: " + ex.Message);
                    return -1;
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query = "SELECT * FROM Students"; // Replace with your table name
            DataTable studentsTable = ExecuteSelectQuery(query);
            dataGridView1.DataSource = studentsTable;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Rooms (RoomNumber, Capacity) VALUES (@RoomNumber, @Capacity)";
            SqlParameter[] parameters = {
            new SqlParameter("@RoomNumber", 105), // Use an integer instead of a string
            new SqlParameter("@Capacity", 3)     // Capacity is also an integer
            };

            // Call ExecuteNonQuery to insert the data
            int rowsAffected = ExecuteNonQuery(query, parameters);

            // Check if the insertion was successful
            if (rowsAffected > 0)
            {
                MessageBox.Show("Room added successfully!");
            }
            else
            {
                MessageBox.Show("Failed to add room.");
            }
        }
        private void LoadStudents()
        {
            try
            {
                // SQL query to fetch all students
                string query = "SELECT StudentID, Name,Gender,Contact,Email FROM Students";

                // Fetch data
                DataTable studentsTable = ExecuteSelectQuery(query);

                // Bind to DataGridView
                dataGridView1.DataSource = studentsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                // SQL query to fetch all rooms
                string query = "SELECT RoomID, RoomNumber, Capacity FROM Rooms";

                // Fetch data
                DataTable roomsTable = ExecuteSelectQuery(query);

                // Bind to DataGridView
                dataGridView2.DataSource = roomsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get StudentID and RoomID from user input (assumes textBoxStudentID and textBoxRoomID exist)
                int studentID = int.Parse(textBox3.Text);
                int roomID = int.Parse(textBox4.Text);

                // SQL query to insert the allocation
                string query = "INSERT INTO Allocation (StudentID, RoomID) VALUES (@StudentID, @RoomID)";

                // Parameters for the query
                SqlParameter[] parameters = {
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@RoomID", roomID)
                };
                int rowsAffected = ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student allocated to room successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to allocate student to room.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for StudentID and RoomID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Allocation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}