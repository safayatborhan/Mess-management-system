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
using System.Data.SqlClient;

namespace mess_management_system
{
    public partial class Form1 : Form
    {
        int j = 0;
        static string connectionString = @"Data Source=C:\mess management system\MessManagement.sdf";
        SqlCeConnection connection = new SqlCeConnection(connectionString);
        string name, launch, dinner, breakfast;
        double totalIndividualMill, totalMill=0;
        float a, b, c, count = 0, dupurerMill = 0, raterMill = 0, sokaleMill = 0;
        float counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'messManagementDataSet.MillCountForADay' table. You can move, or remove it, as needed.
            this.millCountForADayTableAdapter.Fill(this.messManagementDataSet.MillCountForADay);
            dateLabel.Text = System.DateTime.Now.ToShortDateString().ToString();
            j = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                connection.Open();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    j++;
                    if (j == 1)
                        name = label7.Text;
                    if (j == 2)
                        name = label8.Text;
                    if (j == 3)
                        name = label9.Text;
                    if (j == 4)
                        name = label10.Text;
                    if (j == 5)
                        name = label11.Text;
                    if (j == 6)
                        name = label12.Text;
                    if (j == 7)
                        name = label13.Text;
                    if (j == 8)
                        name = label14.Text;
                    if (j == 9)
                        name = label15.Text;
                    if (j == 10)
                        name = label16.Text;
                    if (j == 11)
                        name = label17.Text;
                    if (j == 12)
                        name = label18.Text;
                    //name=dataGridView1.Rows[i].Cells[0].Value.ToString();
                    launch = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    a = float.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    dupurerMill = dupurerMill + a;
                    dinner = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    b = float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    raterMill = raterMill + b;
                    breakfast = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    c = float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    sokaleMill = sokaleMill + c;
                    count = count + a + b + c;
                    totalIndividualMill = Double.Parse(launch) + Double.Parse(dinner) + Double.Parse(breakfast);
                    totalMill = totalMill + totalIndividualMill;
                    Guid newGuid = Guid.NewGuid();
                    
                    string qry = "insert into MillCountForADay values('" + name.ToUpper().ToString() + "','" + launch + "','" + dinner + "','" + breakfast + "','" + comboBox1.SelectedItem.ToString() + "','" + newGuid.ToString() + "')";
                    SqlCeCommand cmd = new SqlCeCommand(qry, connection);
                    cmd.ExecuteNonQuery();
                }
                Guid anewGuid = Guid.NewGuid();
                string qry1 = "insert into MillAndBazar (date, totalMill, bazarAmount,counter) values ('" + comboBox1.SelectedItem.ToString() + "'," + count + "," + 0 + ",'" + anewGuid.ToString() + "')";
                SqlCeCommand cmd1 = new SqlCeCommand(qry1, connection);
                cmd1.ExecuteNonQuery();
                label2.Text = count.ToString();
                label3.Text = dupurerMill.ToString();
                label4.Text = raterMill.ToString();
                label5.Text = sokaleMill.ToString();
                dataGridView1.Refresh();
                MessageBox.Show("Data Inserted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 fm3 = new Form3();
                fm3.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string qry2 = "update MillAndBazar set bazarAmount = " + float.Parse(textBox1.Text) + " where (date = '" + comboBox2.SelectedItem.ToString() + "')";
                SqlCeCommand cmd2 = new SqlCeCommand(qry2, connection);
                cmd2.ExecuteNonQuery();
                string qry3 = "update MillAndBazar set name = '" + comboBox3.SelectedItem.ToString() + "' where (date = '" + comboBox2.SelectedItem.ToString() + "')";
                SqlCeCommand cmd3 = new SqlCeCommand(qry3, connection);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Bazar amount stored", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                DialogResult dr = MessageBox.Show("Are you sure to erase all data?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    string delQry1 = "delete from MillCountForADay";
                    SqlCeCommand cmd1 = new SqlCeCommand(delQry1, connection);
                    cmd1.ExecuteNonQuery();
                    string delQry2 = "delete from MillAndBazar";
                    SqlCeCommand cmd2 = new SqlCeCommand(delQry2, connection);
                    cmd2.ExecuteNonQuery();
                    string delQry3 = "delete from Account";
                    SqlCeCommand cmd3 = new SqlCeCommand(delQry3, connection);
                    cmd3.ExecuteNonQuery();

                    string delQry4 = "delete from FuelAndOthers";
                    SqlCeCommand cmdd = new SqlCeCommand(delQry4, connection);
                    cmdd.ExecuteNonQuery();
                    string inserQry = "insert into Account (Name) values ('SHAKIL')";
                    SqlCeCommand cmd4 = new SqlCeCommand(inserQry, connection);
                    cmd4.ExecuteNonQuery();

                    string inserQry2 = "insert into Account (Name) values ('SAIFUL')";
                    SqlCeCommand cmd42 = new SqlCeCommand(inserQry2, connection);
                    cmd42.ExecuteNonQuery();

                    string inserQry3 = "insert into Account (Name) values ('SOIKOT')";
                    SqlCeCommand cmd43 = new SqlCeCommand(inserQry3, connection);
                    cmd43.ExecuteNonQuery();

                    string inserQry4 = "insert into Account (Name) values ('TAHMID')";
                    SqlCeCommand cmd44 = new SqlCeCommand(inserQry4, connection);
                    cmd44.ExecuteNonQuery();

                    string inserQry5 = "insert into Account (Name) values ('PARTHO')";
                    SqlCeCommand cmd45 = new SqlCeCommand(inserQry5, connection);
                    cmd45.ExecuteNonQuery();

                    string inserQry6 = "insert into Account (Name) values ('BIPUL')";
                    SqlCeCommand cmd46 = new SqlCeCommand(inserQry6, connection);
                    cmd46.ExecuteNonQuery();

                    string inserQry7 = "insert into Account (Name) values ('ZISAN')";
                    SqlCeCommand cmd47 = new SqlCeCommand(inserQry7, connection);
                    cmd47.ExecuteNonQuery();

                    string inserQry8 = "insert into Account (Name) values ('SHISHIR')";
                    SqlCeCommand cmd48 = new SqlCeCommand(inserQry8, connection);
                    cmd48.ExecuteNonQuery();

                    string inserQry9 = "insert into Account (Name) values ('SHAHRIAR')";
                    SqlCeCommand cmd49 = new SqlCeCommand(inserQry9, connection);
                    cmd49.ExecuteNonQuery();

                    string inserQry10 = "insert into Account (Name) values ('RAFSUN')";
                    SqlCeCommand cmd410 = new SqlCeCommand(inserQry10, connection);
                    cmd410.ExecuteNonQuery();

                    string inserQry11 = "insert into Account (Name) values ('SHAMS')";
                    SqlCeCommand cmd411 = new SqlCeCommand(inserQry11, connection);
                    cmd411.ExecuteNonQuery();

                    string inserQry12 = "insert into Account (Name) values ('DIPU')";
                    SqlCeCommand cmd412 = new SqlCeCommand(inserQry12, connection);
                    cmd412.ExecuteNonQuery();
                    MessageBox.Show("All data has been deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(),"Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 fm2 = new Form2();
                fm2.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 fm4 = new Form4();
                fm4.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
