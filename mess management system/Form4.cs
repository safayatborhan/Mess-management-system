using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace mess_management_system
{
    public partial class Form4 : Form
    {
        static string connectionString = @"Data Source=C:\mess management system\MessManagement.sdf";
        SqlCeConnection connection = new SqlCeConnection(connectionString);
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            connection.Open();
            // TODO: This line of code loads data into the 'messManagementDataSet3.Account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.messManagementDataSet3.Account);
            string qry = "select * from Account";
            SqlCeCommand cmd = new SqlCeCommand(qry, connection);
            cmd.ExecuteNonQuery();
        }
    }
}
