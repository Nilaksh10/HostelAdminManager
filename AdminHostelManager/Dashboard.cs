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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-5C6MNSV7\\SQLEXPRESS;Initial Catalog=HostelAdminManagementSystem;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM Students";
            string query1 = "SELECT COUNT(*) FROM Rooms";
            string query2 = "SELECT COUNT(*) FROM Complaints";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    int studentCount = (int)command.ExecuteScalar();
                    label7.Text = "Total Students: " + studentCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                   
                    SqlCommand command = new SqlCommand(query2, connection);
                    int studentCount = (int)command.ExecuteScalar();
                    label8.Text = "Complaints: " + studentCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    int RoomCount = (int)command1.ExecuteScalar();
                    label9.Text = "No of Rooms : " + RoomCount.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    DateTime currentDateTime = DateTime.Now; // Get current date and time
                    label15.Text = "Current Date & Time: " + currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            StudenList studentList = new StudenList();
            studentList.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllocateRooms allocateRooms = new AllocateRooms();
            allocateRooms.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            RoomAllocationList Allocation = new RoomAllocationList();
            Allocation.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Complaints complaints = new Complaints();
            complaints.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ComplaintList complaintList = new ComplaintList();
            complaintList.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.Show();
            this.Hide();
        }
    }
}
