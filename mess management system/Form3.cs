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
    public partial class Form3 : Form
    {
        static string connectionString = @"Data Source=C:\mess management system\MessManagement.sdf";
        SqlCeConnection connection = new SqlCeConnection(connectionString);
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string strr = "select Money from Account where Name = '" + comboBox1.SelectedItem.ToString() + "'";
                SqlCeCommand cmd1 = new SqlCeCommand(strr, connection);
                label11.Text = cmd1.ExecuteScalar().ToString();
                if (cmd1.ExecuteScalar().ToString() == "")
                {
                    string str = "update Account set Money = " + textBox2.Text + " where (Name = '" + comboBox1.SelectedItem.ToString() + "')";
                    SqlCeCommand cmd = new SqlCeCommand(str, connection);
                    cmd.ExecuteNonQuery();
                }
                else if (cmd1.ExecuteScalar().ToString() != null)
                {
                    float amount = float.Parse(textBox2.Text) + float.Parse(cmd1.ExecuteScalar().ToString());
                    string str = "update Account set Money = " + amount + " where (Name = '" + comboBox1.SelectedItem.ToString() + "')";
                    SqlCeCommand cmd = new SqlCeCommand(str, connection);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Money deposited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //connection.Open();
            //string delqry = "delete from MillCountForADay";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //connection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if (textBox1.Text != "" && textBox3.Text != "")
                {
                    Guid newGuid = Guid.NewGuid();
                    string sqy = "insert into FuelAndOthers values ('" + textBox1.Text + "','" + textBox3.Text + "','" + newGuid.ToString() + "')";
                    SqlCeCommand cmd = new SqlCeCommand(sqy, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Please insert values");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
