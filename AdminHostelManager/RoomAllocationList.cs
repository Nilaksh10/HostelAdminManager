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
    public partial class RoomAllocationList : Form
    {
        public RoomAllocationList()
        {
            InitializeComponent();
            LoadRoomAllocations();
        }
        

        private void RoomAllocationList_Load(object sender, EventArgs e)
        {
            LoadRoomAllocations();
        }
        private void LoadRoomAllocations()
        {
            string connectionString = "Data Source=LAPTOP-5C6MNSV7\\SQLEXPRESS;Initial Catalog=HostelAdminManagementSystem;Integrated Security=True";
            string query = @" SELECT 
            s.studentID ,
            s.Name ,
            r.RoomID ,
            r.RoomNumber,
            a.AllocationDate
           FROM 
            Allocation a
           JOIN 
               Students s 
            ON a.studentID = s.studentID
           JOIN 
            Rooms r 
            ON a.RoomID = r.RoomID
           ORDER BY 
            s.Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    RoomAlloDataGrid.DataSource = dataTable;

                    // Customize column headers
                    RoomAlloDataGrid.Columns["studentID"].HeaderText = "ID";
                    RoomAlloDataGrid.Columns["Name"].HeaderText = "Name";
                    RoomAlloDataGrid.Columns["RoomID"].HeaderText = "RoomID";
                    RoomAlloDataGrid.Columns["RoomNumber"].HeaderText = "RoomNumber";
                    RoomAlloDataGrid.Columns["AllocationDate"].HeaderText = "AllocationDate";

                    // Format date column
                    RoomAlloDataGrid.Columns["AllocationDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RoomAlloDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadRoomAllocations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
