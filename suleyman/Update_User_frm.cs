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
    
    public partial class Update_User_frm : Form
    {
        public Update_User_frm()
        {
            InitializeComponent();

        }

        /////////////////////////////////////////////////////////////////////////

        public static int flag;
        public static string nameflag;
        string yazi;
        database1Entities ctx = new database1Entities();


        //update page load
        private void Update_User_frm_Load(object sender, EventArgs e)
        { var x = ctx.User1.Where(y => y.UserName == Admin_Page_frm.Admn_username).FirstOrDefault();
            if(Main.yetki==99)
            {
                comboBox2.Enabled = true;
            }
            else if(Main.yetki==0)
            {
                comboBox2.Enabled = false;
            }

           
            flag = 0;
            label12.Text = "";
            
           
            textBox1.Text = x.Name.ToString();
            textBox2.Text = x.Surname.ToString();
            maskedTextBox1.Text = x.PhoneNumber.ToString();
            if(x.Gender=="Female")
            {
                radioButton2.Checked = true;
            }
            else if (x.Gender == "Male")
            {
                radioButton1.Checked = true;
            }
            
            dateTimePicker1.Value = x.DateOfBirth;
            textBox4.Text = x.UserName.ToString();
            textBox5.Text = x.Password;
            yazi = x.Password;

            comboBox1.Items.Clear();
            baglanti ptx = new baglanti();
            SqlDataReader dr;
            dr = ptx.FillComboBox("Department");

            while (dr.Read())
            {
                if (dr["Status"].ToString() == "Open")
                {
                    comboBox1.Items.Add(dr["Department"]);
                }
            }
            var t = ctx.Departments.Where(y => y.Id == x.Department_Id).FirstOrDefault();
            comboBox1.SelectedItem = t.Department1;



            comboBox2.Items.Clear();            
            dr = ptx.FillComboBox("Authority");

            while (dr.Read())
            {
                if (Convert.ToInt32(dr["Id"]) != 99)
                {
                  comboBox2.Items.Add(dr["Authority"]);  
                }
                
            }
            if (x.Authority_Id == 99)
            {
                comboBox2.Items.Add("Super Admin");
                comboBox2.Enabled = false;
            }
            var k = ctx.Authorities.Where(y => y.Id == x.Authority_Id).FirstOrDefault();
            comboBox2.SelectedItem = k.Authority1;



            comboBox3.Items.Clear();
            dr = ptx.FillComboBox("Country");

            while (dr.Read())
            {
                comboBox3.Items.Add(dr["CountryName"]);
            }
            var l = ctx.Countries.Where(y => y.Id == x.Country_Id).FirstOrDefault();
            comboBox3.SelectedItem = l.CountryName;
        }
        //check finger print page
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            
            var x = ctx.User1.Where(y => y.UserName == Admin_Page_frm.Admn_username).FirstOrDefault();
            var t = ctx.FingerPrints.Where(y => y.User1_UserName == x.UserName).FirstOrDefault();
            if(t!=null)
            {
                pictureBox2.ImageLocation = "png/fingercontrol/exist.png";
               
               
            }
            else
            {

                pictureBox2.ImageLocation = "png/fingercontrol/non exist.png";
               
            }


        }
        //close change password section
        private void button5_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }
        //save changes
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.TextLength >= 6)
            {
                if(textBox1.Text == "")
                {
                    label12.Text = "Error : Please enter valid Name values..";
                }
                else if (textBox2.Text == "")
                {
                    label12.Text = "Error : Please enter valid Surname values..";
                }
                else if (comboBox3.SelectedItem == null)
                {
                    label12.Text = "Error : Please enter valid Country values..";
                }
                else if (comboBox1.SelectedItem == null)
                {
                    label12.Text = "Error : Please enter valid Department values..";
                }
                else if(maskedTextBox1.MaskFull == false)
                {
                    label12.Text = "Error : Please enter valid Phone Number values..";
                }
                else
                {
                    database1Entities ctx = new database1Entities();
                    string guncelle = Admin_Page_frm.Admn_username;

                    var update_user = ctx.User1.Where(y => y.UserName == guncelle).FirstOrDefault();
                        update_user.Name = textBox1.Text;
                        update_user.Surname = textBox2.Text;
                        update_user.PhoneNumber = maskedTextBox1.Text;
                        if (radioButton1.Checked == true)
                        { update_user.Gender = "Male"; }
                        else if (radioButton2.Checked == true)
                        { update_user.Gender = "Female"; }
                        update_user.DateOfBirth = dateTimePicker1.Value;


                    
                    if (update_user.Password != textBox5.Text)
                    {
                        update_user.Password = baglanti.Hash222(textBox5.Text);
                    }



                    var update_country = ctx.Countries.Where(y => y.CountryName == comboBox3.SelectedItem.ToString()).FirstOrDefault();
                    update_user.Country_Id = update_country.Id;
                    
                    var update_authority = ctx.Authorities.Where(y => y.Authority1 == comboBox2.SelectedItem.ToString()).FirstOrDefault();
                    update_user.Authority_Id = update_authority.Id;
                    
                    var update_department = ctx.Departments.Where(y => y.Department1 == comboBox1.SelectedItem.ToString()).FirstOrDefault();
                    update_user.Department_Id = update_department.Id;

                    
                    ctx.SaveChanges();
                    MessageBox.Show("Your Changes Accepted !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                label12.Text = "Your password should be 6-11 characters. Try again ! ";
               
            }
        }
        //close
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //add finger print page
        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Page_frm.persn_authority = 0;
            flag = 1;
            nameflag = textBox4.Text.ToString();
            Add_FingerPrint_frm addfinger = new Add_FingerPrint_frm();

            addfinger.ShowDialog();
            var x = ctx.User1.Where(y => y.UserName == Admin_Page_frm.Admn_username).FirstOrDefault();
            var t = ctx.FingerPrints.Where(y => y.User1_UserName == x.UserName).FirstOrDefault();
            if (t != null)
            {
                pictureBox2.ImageLocation = "png/fingercontrol/exist.png";
                
            }
            else
            {
                pictureBox2.ImageLocation = "png/fingercontrol/non exist.png";
            }
            flag = 0;
            
            
        }
        //Form açılınca focuslan.
        private void Update_User_frm_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        //Tıklayınca silinme komutu
        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Clear();
        }
        //Boş ise passwordu göster
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if(textBox5.Text=="")
            {
                textBox5.Text = yazi;
            }
        }


        /////////////////////////////////////////////////////////////////////////
    }
}
