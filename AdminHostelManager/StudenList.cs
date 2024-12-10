using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdminHostelManager
{
    public partial class StudenList : Form
    {
        public StudenList()
        {
            InitializeComponent();
        }

        private void StudenList_Load(object sender, EventArgs e)
        {
            PopulateStudentList();
        }

        private void PopulateStudentList()
        {
            string connectionString = "Data Source=LAPTOP-5C6MNSV7\\SQLEXPRESS;Initial Catalog=HostelAdminManagementSystem;Integrated Security=True";
            string query = "SELECT StudentID, Name, Gender, Contact, Email, DateOfBirth FROM Students";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    // Customize column headers
                    dataGridView1.Columns["StudentID"].HeaderText = "ID";
                    dataGridView1.Columns["Name"].HeaderText = "Name";
                    dataGridView1.Columns["Gender"].HeaderText = "Gender";
                    dataGridView1.Columns["Contact"].HeaderText = "Contact";
                    dataGridView1.Columns["Email"].HeaderText = "Email";
                    dataGridView1.Columns["DateOfBirth"].HeaderText = "Date of Birth";

                    // Format date column
                    dataGridView1.Columns["DateOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No additional action needed here for initial loading
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
