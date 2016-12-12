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
    public partial class Form2 : Form
    {
        static string connectionString = @"Data Source=C:\mess management system\MessManagement.sdf";
        SqlCeConnection connection = new SqlCeConnection(connectionString);
        float totalMill = 0;
        float bazarAmount = 0;
        float fuelCost = 0;
        float millRate;
        float particularMill=0;
        float particularMillHisab = 0;
        float pabeNaDibe = 0;
        SqlCeDataAdapter adp;
        SqlCeDataAdapter adp2;
        SqlCeDataAdapter adp3;
        DataTable tb;
        DataTable tb2;
        DataTable tb3;
        SqlCeCommandBuilder scb;
        SqlCeCommandBuilder scb2;
        SqlCeCommandBuilder scb3;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'messManagementDataSet13.FuelAndOthers' table. You can move, or remove it, as needed.
            this.fuelAndOthersTableAdapter.Fill(this.messManagementDataSet13.FuelAndOthers);
            // TODO: This line of code loads data into the 'messManagementDataSet12.MillCountForADay' table. You can move, or remove it, as needed.
            this.millCountForADayTableAdapter6.Fill(this.messManagementDataSet12.MillCountForADay);
            // TODO: This line of code loads data into the 'messManagementDataSet11.MillCountForADay' table. You can move, or remove it, as needed.
            this.millCountForADayTableAdapter5.Fill(this.messManagementDataSet11.MillCountForADay);
            // TODO: This line of code loads data into the 'messManagementDataSet10.MillCountForADay' table. You can move, or remove it, as needed.
            this.millCountForADayTableAdapter4.Fill(this.messManagementDataSet10.MillCountForADay);
            // TODO: This line of code loads data into the 'messManagementDataSet9.MillCountForADay' table. You can move, or remove it, as needed.
            this.millCountForADayTableAdapter3.Fill(this.messManagementDataSet9.MillCountForADay);
            // TODO: This line of code loads data into the 'messManagementDataSet8.MillCountForADay' table. You can move, or remove it, as needed.
            this.millCountForADayTableAdapter2.Fill(this.messManagementDataSet8.MillCountForADay);
            //button2.Enabled = false;
            // TODO: This line of code loads data into the 'messManagementDataSet7.MillAndBazar' table. You can move, or remove it, as needed.
            this.millAndBazarTableAdapter3.Fill(this.messManagementDataSet7.MillAndBazar);
            // TODO: This line of code loads data into the 'messManagementDataSet6.MillAndBazar' table. You can move, or remove it, as needed.
            this.millAndBazarTableAdapter2.Fill(this.messManagementDataSet6.MillAndBazar);
            // TODO: This line of code loads data into the 'messManagementDataSet5.MillAndBazar' table. You can move, or remove it, as needed.
            this.millAndBazarTableAdapter1.Fill(this.messManagementDataSet5.MillAndBazar);

            // TODO: This line of code loads data into the 'messManagementDataSet4.MillCountForADay' table. You can move, or remove it, as needed.
            //this.millCountForADayTableAdapter1.Fill(this.messManagementDataSet4.MillCountForADay);
            //connection.Open();
            //button1.Enabled = false;
            // TODO: This line of code loads data into the 'messManagementDataSet2.MillAndBazar' table. You can move, or remove it, as needed.
            this.millAndBazarTableAdapter.Fill(this.messManagementDataSet2.MillAndBazar);

            // TODO: This line of code loads data into the 'messManagementDataSet1.MillCountForADay' table. You can move, or remove it, as needed.
            this.millCountForADayTableAdapter.Fill(this.messManagementDataSet1.MillCountForADay);

            //for datagriedview2
            //connection.Open();
            string partialSelectionQry2 = @"select * from MillAndBazar";
            adp2 = new SqlCeDataAdapter(partialSelectionQry2, connection);
            tb2 = new DataTable();
            adp2.Fill(tb2);
            dataGridView2.DataSource = tb2;

            //for datagriedview1
            string pp = @"select Name,Launch,Dinner,Breakfast,Date,counter from MillCountForADay";
            adp = new SqlCeDataAdapter(pp, connection);
            tb = new DataTable();
            adp.Fill(tb);
            dataGridView1.DataSource = tb;

            //for datagriedview3
            string ppp = @"select Date,Money,Counter from FuelAndOthers";
            adp3 = new SqlCeDataAdapter(ppp, connection);
            tb3 = new DataTable();
            adp3.Fill(tb3);
            dataGridView3.DataSource = tb3;

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                totalMill = totalMill + float.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                bazarAmount = bazarAmount + float.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString());
            }
            for (int j = 0; j < dataGridView3.Rows.Count - 1; j++)
            {
                fuelCost = fuelCost + float.Parse(dataGridView3.Rows[j].Cells[1].Value.ToString());
            }
            label19.Text = fuelCost.ToString();
            label1.Text = totalMill.ToString();

            label2.Text = bazarAmount.ToString();

            millRate = (bazarAmount + fuelCost) / totalMill;
            label3.Text = millRate.ToString();
            millRate = 0;
            totalMill = 0;
            bazarAmount = 0;


            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                connection.Open();
                string partialSelectionQry = @"select Name, Launch, Dinner, Breakfast, Date ,counter from MillCountForADay where (Date = '" + comboBox1.SelectedItem.ToString() + "')";
                adp = new SqlCeDataAdapter(partialSelectionQry, connection);
                tb = new DataTable();
                adp.Fill(tb);
                dataGridView1.DataSource = tb;

            }
            catch
            { }
            finally
            {
                connection.Close();
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //button1.Enabled = false;
                connection.Open();
                string personalMillQry = "select Name,Date,Launch,Dinner,Breakfast,counter from MillCountForADay where Name = '" + comboBox2.SelectedItem.ToString() + "'";
                adp = new SqlCeDataAdapter(personalMillQry, connection);
                DataTable tb = new DataTable();
                adp.Fill(tb);
                dataGridView1.DataSource = tb;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    particularMill = particularMill + float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    particularMill = particularMill + float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    particularMill = particularMill + float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                label4.Text = particularMill.ToString();
                particularMill = 0;
                string jomaQry = "select Money from Account where Name = '" + comboBox2.SelectedItem.ToString() + "'";
                SqlCeCommand cmd5 = new SqlCeCommand(jomaQry, connection);
                label6.Text = cmd5.ExecuteScalar().ToString();
                particularMillHisab = float.Parse(label3.Text) * float.Parse(label4.Text);
                if(label6.Text!="")
                    pabeNaDibe = float.Parse(label6.Text) - particularMillHisab;
                if (label6.Text == "")
                    pabeNaDibe = 0;
                if (pabeNaDibe > 0)
                {
                    label9.Text = "pabe";
                    label8.Text = String.Format("{0:0.00}",pabeNaDibe);
                }
                if (pabeNaDibe < 0)
                {
                    label9.Text = "dibe";
                    label8.Text = String.Format("{0:0.00}", (-pabeNaDibe));
                }
                if(pabeNaDibe==0)
                {
                    label9.Text = "null";
                    label8.Text = "null";
                }
                
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //button1.Enabled = false;
                //connection.Open();
                scb = new SqlCeCommandBuilder(adp);
                adp.Update(tb);
                MessageBox.Show("Data updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
                //connection.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button2.Enabled = false;
            scb2 = new SqlCeCommandBuilder(adp2);
            adp2.Update(tb2);
            MessageBox.Show("Data updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            scb3 = new SqlCeCommandBuilder(adp3);
            adp3.Update(tb3);
            MessageBox.Show("Data updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
