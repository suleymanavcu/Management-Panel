using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace suleyman
{
    public partial class Add_User_frm : Form
    {
        public Add_User_frm()
        {
            InitializeComponent();
        }


        ////////////////////////////////////////////////
        baglanti bag = new baglanti();
        
        
        // Add User
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti ctx = new baglanti();
            if(textBox1.Text == "")
            {
                label10.Text = "Don't leave empty Name area";
            }
            else if (textBox2.Text == "")
            {
                label10.Text = "Don't leave empty SurName area";
            }
            else if (maskedTextBox2.MaskFull == false)
            {
                label10.Text = "Don't leave empty Phone Number area";
            }
            else if(comboBox1.SelectedItem == null)
            {
                label10.Text = "Don't leave empty Department area";
            }
            else if(comboBox2.SelectedItem == null)
            {
                label10.Text = "Don't leave empty Country area";
            }
            else if(textBox5.Text=="")
            {
                label10.Text = "Don't leave empty Username area";
            }
            else if(textBox3.Text.Length < 6)
            {
                label10.Text = "Your password should be 6-11 characters";
            }
           else
            {
                database1Entities sehir = new database1Entities();
                var x = sehir.Countries.Where(y => y.CountryName == comboBox2.SelectedItem.ToString()).FirstOrDefault();
                var z = sehir.Departments.Where(y => y.Department1 == comboBox1.SelectedItem.ToString()).FirstOrDefault();
                string sifre = baglanti.Hash222(textBox3.Text.ToString());
               
                try
                {
                    
                    if (radioButton1.Checked == true)
                    {
                        ctx.AddUser(textBox1.Text.ToString(), textBox2.Text.ToString(), true, dateTimePicker1.Value, maskedTextBox2.Text.ToString(), x.Id, z.Id, 1, textBox5.Text.ToString(), sifre);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        ctx.AddUser(textBox1.Text.ToString(), textBox2.Text.ToString(), false, dateTimePicker1.Value, maskedTextBox2.Text.ToString(), x.Id, z.Id, 1, textBox5.Text.ToString(),sifre);
                    }
                    MessageBox.Show("Registration process successful", "Registration status ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                catch
                {
                    MessageBox.Show("User can be exist, Try another Username.", "User exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
        }
        //Combobox ı doldur.. Textboxları temizle..
        private void Form4_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Clear();
            baglanti ctx = new baglanti();
            SqlDataReader dr;
            dr = ctx.FillComboBox("Department");
            while (dr.Read())
            {
                if (dr["Status"].ToString() == "Open")
                {
                    comboBox1.Items.Add(dr["Department"]);
                }
            }

            comboBox2.Items.Clear();
            SqlDataReader dx;
            dx = ctx.FillComboBox("Country");

            while (dx.Read())
            {
                comboBox2.Items.Add(dx["CountryName"]);
            }



            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.ResetText();
            textBox5.Clear();
            maskedTextBox2.Clear();
            radioButton1.Checked = true;


            

        }
        // Kapat.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Form açılınca textbox'a focuslan.
        private void Add_User_frm_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }


        ////////////////////////////////////////////////
    }
}
