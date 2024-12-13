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
    public partial class ComplaintList : Form
    {
        public ComplaintList()
        {
            InitializeComponent();
            PopulateStudentList();
        }

        private void dataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void PopulateStudentList()
        {
            string connectionString = "Data Source=LAPTOP-5C6MNSV7\\SQLEXPRESS;Initial Catalog=HostelAdminManagementSystem;Integrated Security=True";
            string query = "SELECT * FROM Complaints";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGrid1.DataSource = dataTable;

                    // Customize column headers
                    dataGrid1.Columns["ComplaintID"].HeaderText = "ComplaintID";
                    dataGrid1.Columns["StudentID"].HeaderText = "StudentID";
                    dataGrid1.Columns["RoomID"].HeaderText = "RoomID";
                    dataGrid1.Columns["Category"].HeaderText = "Contact";
                    dataGrid1.Columns["description"].HeaderText = "Description";
                    dataGrid1.Columns["status"].HeaderText = "status";
                    dataGrid1.Columns["DateFiled"].HeaderText = "Date of Filling";

                    // Format date column
                    dataGrid1.Columns["DateFiled"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
