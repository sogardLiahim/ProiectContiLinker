using ProiectContinental4.MyClasses;
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

namespace ProiectContinental4
{
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Continental\Desktop\ProiectContinental4\ProiectContinental4\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlTransaction transaction;
        List<MCU_TYPES> mcs = new List<MCU_TYPES>();
        int currentRecordId;

        public Form2()
        {
            InitializeComponent();

            displayDataGridContent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null &&
                textBox2.Text != null &&
                textBox3.Text != null)
            {
                string a = textBox1.Text;
                string b = textBox2.Text;
                string c = textBox3.Text;
                con.Open();
                cmd.Connection = con;
                transaction = con.BeginTransaction("SampleTransaction");
                cmd.CommandText = "INSERT INTO [dbo].MCU_TYPES(MCU_TYPE,RAM_APL,RAM_PARAM) VALUES('" + a + "','" + b + "','" + c + "')";
                cmd.Transaction = transaction;
                transaction.Commit();
                int nrOfRows = cmd.ExecuteNonQuery();
                MessageBox.Show(nrOfRows + " rows inserted!");
                con.Close();

                displayDataGridContent();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Create comboBox
            //https://stackoverflow.com/questions/18677772/combobox-column-within-databound-datagridview
            //Assign it to your dataGridView
        //    dataGridView1.Rows[1].Cells[5] = c;

            //cod nou
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            MessageBox.Show("" + e.RowIndex);
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            currentRecordId = (int)selectedRow.Cells[0].Value;
           
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            textBox2.Text = selectedRow.Cells[2].Value.ToString();
            textBox3.Text = selectedRow.Cells[3].Value.ToString();



        }

        private void datagridview1_selectionChanged(object sender, EventArgs e)
        {
        }

        public void displayDataGridContent()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id, MCU_TYPE, RAM_ORG, RAM_LENGTH FROM MCU_TABLE"; //id ignorat
            //SELECT MCU_TYPE, RAM_ORG, RAM_LENGTH FROM MCU_TABLE;
            cmd.ExecuteNonQuery();
            DataTable Dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(Dt);
            dataGridView1.DataSource = Dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            MessageBox.Show("id from Detele():"+currentRecordId);
            cmd.CommandText = "DELETE from MCU_TABLE WHERE ID="+currentRecordId+"";
            cmd.ExecuteNonQuery();
            DataTable Dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Dt);
            dataGridView1.DataSource = Dt;
            con.Close();

            displayDataGridContent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            MessageBox.Show("id from Update():" + currentRecordId);
            cmd.CommandText = "UPDATE MCU_TABLE set MCU_TYPE='"+textBox1.Text+ "',RAM_ORG='" + textBox2.Text + "',RAM_LENGTH='" + textBox3.Text + "' WHERE ID=" + currentRecordId + "";
            cmd.ExecuteNonQuery();
            DataTable Dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Dt);
            dataGridView1.DataSource = Dt;
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            displayDataGridContent();
        }
        //a fost goala acuma adaugat noul cod
        private void Form2_Load(object sender, EventArgs e)
        {
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

