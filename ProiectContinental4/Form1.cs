using ProiectContinental4.MyClasses;
using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace ProiectContinental4
{
    public partial class Form1 : Form
    {
        string XmlPath;
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\SpireaM\Desktop\ProiectContinental4\ProiectContinental4\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlTransaction transaction;
        List<MCU_TYPES> mcs = new List<MCU_TYPES>();
        List<Mtype> mtypes = new List<Mtype>();
        public List<MtypeReturned> mRet = new List<MtypeReturned>();



        public Form1()
        {

            InitializeComponent();
            populateComboBox2();
            //populateMCUList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mcType = comboBox2.Text;
            mRet = getAllOptions(mcType);

            foreach (MtypeReturned temp in mRet)
            {
                if (temp.McuName.Equals(mcType))  //McuName but am schibmat ca asa arata in debug 
                {
                    comboBox1.Items.Add(temp.RamApl);
                    comboBox3.Items.Add(temp.RamParam);
                    textBox5.Text = temp.Xml_id.ToString();
                    textBox4.Text = temp.McuName;
                    comboBox2.Update();


                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string alfa = "AaaaaAb";
            MessageBox.Show(alfa.ToUpper());
            Utils utils = new Utils();
            utils.displayText();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
            XmlPath = ofd.FileName;
            textBox3.Text = XmlPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            populateComboBox2();
            populateMCUList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (XmlPath != null)
            {
                mtypes = Utils.ReadXML(XmlPath);

                foreach (Mtype temp in mtypes)
                {
                    Console.WriteLine(temp.CpuNume);
                    foreach (string temp2 in temp.getRam_adr())

                        Console.WriteLine(temp2);
                }


                insertMCUintoDB(mtypes);




            }

        }

        private void ReadStartElement(string p1, string p2)
        {
            throw new NotImplementedException();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void insertMCUintoDB(List<Mtype> mcu)
        {

            con.Open();
            cmd.Connection = con;



            foreach (Mtype temp in mcu)
            {
                Console.WriteLine(temp.CpuNume);
                foreach (string temp2 in temp.getRam_adr())
                {

                    Console.WriteLine(temp2);
                    transaction = con.BeginTransaction("SampleTransaction");
                    cmd.CommandText = "INSERT INTO [dbo].MCU_TYPES(MCU_TYPE,RAM_APL,XML_ID) VALUES('" +temp.CpuNume+ "','" + temp.CpuId + "','" + temp2 + "')";
                    cmd.Transaction = transaction;
                    transaction.Commit();

                    int nrOfRows = cmd.ExecuteNonQuery();
                }

            }

            con.Close();
        }




        public void populateMCUList()
        {
            con.Open();
            cmd.CommandText = "SELECT * FROM MCU_TYPES";
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    MCU_TYPES mcu = new MCU_TYPES((int)reader[0],   //id
                                      reader[1].ToString(), //
                                      reader[2].ToString(),
                                      reader[3].ToString());
                    mcs.Add(mcu);
                }
            }
            con.Close();
        }


        public void populateComboBox2()
        {
            comboBox2.Items.Clear();
            mcs.Clear();
            con.Open();
            cmd.CommandText = "SELECT DISTINCT MCU_TYPE FROM MCU_TYPES";
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            List<string> mcu_type = new List<string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    mcu_type.Add(reader[0].ToString());
                }

                foreach (string temp in mcu_type)
                {
                    comboBox2.Items.Add(temp);
                }

            }
            else
            {
                MessageBox.Show("no rows!");

            }
            con.Close();
        }

        public List<MtypeReturned> getAllOptions(string mcuName)
        {
            // comboBox2.Items.Clear();         ERA ON ------------------------------------>>>>>>>>>><<<<<<<<<<<<
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            con.Close();
            mcs.Clear();
            con.Open();
            cmd.CommandText = "SELECT * FROM MCU_TYPES WHERE MCU_TYPE = '" + mcuName + "'";
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int m2 = Convert.ToInt32(reader[2]);
                    string m3 = reader[3].ToString();
                    int m0 = (int)reader[0];
                    string m1 = reader[1].ToString();
                    string m4 = reader[4].ToString();
                    try
                    {
                        MtypeReturned mRetO = new MtypeReturned(m4,
                                                                    m3,
                                                                    1,
                                                                    m2,
                                                                    m1);

                        mRet.Add(mRetO);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught.", ex);
                    }

                }
            }


            return mRet;
        }




        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (XmlPath != null) mtypes = Utils.ReadXML(XmlPath);
            List<string> id = new List<string>();
            foreach (Mtype temp in mtypes)
            {

                id = cautaBaza(temp.CpuId);

               
                int counterDB = UsefulMethods.getListElements(id); //nr elemete ID db     
                int counterRam = UsefulMethods.getListElements(temp.getRam_param());

                string[] idArray;
                idArray = new string[counterDB];
                idArray = UsefulMethods.conversieArray(counterDB, id);
                string[] ramApl;
                ramApl = new string[counterRam];
                ramApl = UsefulMethods.conversieArray(counterRam, temp.getRam_param());
                //idArray, ramApl (array)
                Console.WriteLine("++++" + temp.CpuNume);

                if (counterDB >= counterRam)
                {

                    cmd.Connection = con;
                    con.Open();

                    for (int i = 0; i < counterRam; i++) { cmd.CommandText = "UPDATE MCU_TYPES SET RAM_PARAM ='" + ramApl[i] + "' WHERE Id ='" + id[i] + "'"; cmd.ExecuteNonQuery(); }
                    con.Close();

                }
                else
                {
                    cmd.Connection = con;
                    con.Open();
                    for (int i = 0; i < counterDB; i++) cmd.CommandText = "UPDATE MCU_TYPES SET RAM_PARAM ='"+ramApl[i]+"'WHERE Id ='" + id[i] + "'"; cmd.ExecuteNonQuery();
                                  
                   
                    con.Close();
                }

            }

        }

        public List<string> cautaBaza(string xmlID) {

        
                List<string> id = new List<string>();
                con.Open();
                cmd.CommandText = "SELECT * FROM MCU_TYPES WHERE RAM_APL ="+xmlID+" ";

                 reader = cmd.ExecuteReader();
                 if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            xmlID = UsefulMethods.getPerfectString(xmlID);
                            string xmlIdDb = reader[2].ToString();
                            xmlIdDb = UsefulMethods.getPerfectString(xmlIdDb);
                            if (xmlID == xmlIdDb)
                            {
                                string cpuId = reader[0].ToString();
                                id.Add(cpuId);
                            }
                        }
                    
                 }
            con.Close();
            return id;
        }


        private void button7_Click_1(object sender, EventArgs e)
        {

            string mcuName = (comboBox2.Text); //MCU NAME           
            string flashParam = (comboBox1.Text); //FLASH PARAM
            string flashApl = (comboBox3.Text); //FLASH APL

            mcuName = mcuName.Trim();
            flashParam = flashParam.Trim();
            flashApl = flashApl.Trim();
            UsefulMethods.generareTxt(mcuName, flashParam, flashApl);

        }


        private void button8_Click_1(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }
        }
        }
    

   



