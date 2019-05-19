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


namespace suleyman
{
    public partial class User_Page_frm : Form
    {
        public User_Page_frm()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////
        public static bool kapatflag = false;
        

        //change information buttonu ..
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = true;            
            label12.Text = "";
        }
        //değişiklikleri kaydet buttonu..
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label12.Text = "Dont Leave the Name Area Empty !";
            }
            else if (textBox2.Text == "")
            {
                label12.Text = "Dont Leave the Surname Area Empty !";
            }
            else if (comboBox1.SelectedItem==null)
            {
                label12.Text = "Dont Leave the Country Area Empty !";
            }
            else if (maskedTextBox1.MaskFull==false)
            {
                label12.Text = "Dont Leave the Phone Number Area Empty or Incomplete !";
            }
            else
            {
                database1Entities ctx = new database1Entities();
                string guncelle = Main.UserName;
                var update_user = ctx.User1.Where(y => y.UserName == guncelle).FirstOrDefault();
                var update_country = ctx.Countries.Where(y => y.CountryName == comboBox1.SelectedItem.ToString()).FirstOrDefault();

                update_user.Name = textBox1.Text;
                update_user.Surname = textBox2.Text;
                update_user.PhoneNumber = maskedTextBox1.Text;
                if (radioButton1.Checked == true)
                { update_user.Gender = "Male"; }
                else if (radioButton2.Checked == true)
                { update_user.Gender = "Female"; }
                update_user.Country_Id = update_country.Id;
                update_user.DateOfBirth = dateTimePicker1.Value;
                ctx.SaveChanges();
                groupBox1.Text = "User : " + update_user.Name + " " + update_user.Surname + "";
                MessageBox.Show("Your Changes Accepted !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Enabled = false;
                button3.Visible = true;
                button4.Visible = true;
                button6.Visible = false;
               
                label12.Text = "";
            }
        }
        //change password bölümünü aç..
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            label11.Text = "";
        }
        //change password komutu
        private void button1_Click(object sender, EventArgs e)
        {
            database1Entities ctx = new database1Entities();
            string guncelle = Main.UserName;
            
            var update_user = ctx.User1.Where(y => y.UserName == guncelle).FirstOrDefault();
            
            string eski_sifre = baglanti.Hash222(textBox5.Text.ToString());
            if(textBox5.Text =="" || textBox6.Text==""|| textBox7.Text=="")
            {
                label11.Text = "Dont leave empty area. Try again ! ";
                
            }
            else if (eski_sifre != update_user.Password)
            {
                label11.Text = "Your old password is wrong. Try again ! ";
            }
            else if (textBox7.Text != textBox6.Text)
            {
                label11.Text = "Your new passwords are not the same. Try again ! ";
            }
            else if (textBox7.Text.Length<6 ||textBox6.Text.Length<6)
            {
                label11.Text = "Your password should be 6-11 characters. Try again ! ";
            }
            else if (textBox7.Text==textBox6.Text && eski_sifre == update_user.Password)
            {
                update_user.Password = baglanti.Hash222(textBox7.Text.ToString());
                ctx.SaveChanges();
                MessageBox.Show("Your Password Changed !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox2.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
            }




        }
        //change password bölümünü kapat //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
        }
        //load olunca bağlı olunan kullanıcının bilgilerini getirir..
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            baglanti stx = new baglanti();
            SqlDataReader dr;
            dr = stx.FillComboBox("Country");
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CountryName"]);
            }

            kapatflag = false;
            database1Entities ctx = new database1Entities();
            var x = ctx.User1.Where(y => y.UserName == Main.UserName).FirstOrDefault();
            var z = ctx.Countries.Where(y => y.Id == x.Country_Id).FirstOrDefault();
            groupBox1.Text = "User : " + x.Name+" "+x.Surname+"";
            textBox1.Text = x.Name.ToString();
            textBox2.Text = x.Surname.ToString();
            maskedTextBox1.Text = x.PhoneNumber;
            comboBox1.SelectedItem =z.CountryName;
            dateTimePicker1.Value = x.DateOfBirth;
            int a=comboBox1.Items.Count;
            if(x.Gender=="Male")
            {
                radioButton1.Checked=true;
            }
            else if (x.Gender == "Female")
            {
                radioButton2.Checked=true;
            }
            var t = ctx.Departments.Where(y => y.Id == x.Department_Id).FirstOrDefault();
            textBox4.Text = t.Department1;
           
        }
        //view site kısmı
        private void label17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com;");
        }
        //log-out kısmı
        private void label13_Click(object sender, EventArgs e)
        {
            kapatflag = true;
            this.Close();
        }
        //kapatma karar kısmı(log-out OR exit)
        private void User_Page_frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kapatflag == false)
            {
                Application.Exit();
            }
        }
        

        //Facebook
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com;");
        }
        //google
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com;");
        }
        //Instagram
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com;");
        }
        //Twitter
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com;");
        }
        //Linked-in
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com;");
        }

        /////////////////////////////////////////////////////////////////////////
    }
}
