using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProiectContinental4
{
    public partial class Form3 : Form
    {
       int combox2Int;
       int top_align = 0;
       bool comboxChange = false;
       List<ComboBox> comboxs = new List<ComboBox>();
       List<Button> buttons = new List<Button>();

        public Form3()
        {

            InitializeComponent();
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            comboBox2.Items.Add("6");
            comboBox2.Items.Add("7");
            comboBox2.Items.Add("8");

        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            top_align = 1;
            if (comboBox2.Text != null)
            {
                Int32.TryParse(comboBox2.Text, out combox2Int);

                for (int i = 0; i < combox2Int; i++)
                {
                    buttons = add_button(top_align);
                    add_combox(top_align);

                }

                foreach (Button temp in buttons)
                {

                    top_align += 1;
                    temp.Text = "Button" + this.top_align.ToString();
                    temp.Name = "Button" + this.top_align.ToString();
                    temp.Top = top_align * 50;
                    temp.Left = 200;


                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public TextBox add_txtbx(int top_align) {

            TextBox txt = new TextBox();
            this.Controls.Add(txt);
            txt.Top = top_align * 50;
            txt.Left = 100;
            txt.Text = "TextBox" + this.top_align.ToString();
            txt.Name = "TextBox" + this.top_align.ToString();
            return txt;
        
        
        }

        public List <Button> add_button(int top_align)
        {
            Button button = new Button();
            this.Controls.Add(button);
            buttons.Add(button);
            return buttons;      
        }

        public List <ComboBox> add_combox(int top_align)
        {
            ComboBox combox = new ComboBox();
            this.Controls.Add(combox);
            combox.Top = top_align * 50;
            combox.Left = 200;
            combox.Text = "Button" + this.top_align.ToString();
            combox.Name = "Button" + this.top_align.ToString();
            comboxs.Add(combox);
            return comboxs;
        }
        
        public void deleteItems() {


            foreach (Button temp in buttons)
            {
                temp.Hide();
                top_align = 0;
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteItems();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

    }
}