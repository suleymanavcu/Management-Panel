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
    public partial class Admin_Page_frm : Form
    {
        public Admin_Page_frm()
        {
            InitializeComponent();
        }


        
        /// ///////////////////////////////////////////////////////////////////////
        //Diğer Formlardan kullanılacak olan değişkenler
        baglanti list = new baglanti();
        DataTable a = new DataTable();
        public static string Admn_username;
        public static string Admin_Department;
        public static bool admn_kapatflag;
        public static int persn_authority;


        //Form açılınca listelemeleri yapar..
        private void Form1_Load(object sender, EventArgs e)
        {
         
            
            database1Entities bag = new database1Entities();
            var deg = bag.User1.Where(y => y.UserName == Main.UserName).FirstOrDefault();

            label2.Text = "WELCOME ADMIN\n\n" + deg.Name + " "+deg.Surname+"";
            admn_kapatflag = false;
            
            a = list.ListUsers();
            dataGridView1.DataSource = a;
            
            dataGridView1.Columns[2].Width = Convert.ToInt32(Convert.ToDouble(dataGridView1.Width)*(0.07));
            dataGridView1.Columns[6].Width = Convert.ToInt32(Convert.ToDouble(dataGridView1.Width) * (0.07));
            if(Main.yetki==99)
            {
                label2.Text = "WELCOME SUPER ADMIN\n\n" + deg.Name + " " + deg.Surname + "";
                button6.Visible = true;
                button7.Visible = true;
                dataGridView1.Columns[7].Width = Convert.ToInt32(Convert.ToDouble(dataGridView1.Width) * (0.15));
            }
            
            if(Main.yetki==0)
            dataGridView1.Columns[6].Width = Convert.ToInt32(Convert.ToDouble(dataGridView1.Width) * (0.15));
            a = list.ListFingers();
            dataGridView2.DataSource = a;

            a = list.ListDepartment();
            dataGridView3.DataSource = a;
            dataGridView3.Columns[1].Width = Convert.ToInt32(Convert.ToDouble(dataGridView3.Width) * (0.3));

            a = list.ListAdmins();
            dataGridView4.DataSource = a;


        }


       
        // Add komutları.. 
                //Department
        private void Add_Department_btn_Click(object sender, EventArgs e)
        {
            Add_Department_frm frm3 = new Add_Department_frm();
            frm3.ShowDialog();
            a = list.ListDepartment();
            dataGridView3.DataSource = a;
        }
                //User
        private void button1_Click(object sender, EventArgs e)
        {
            Add_User_frm frm4 = new Add_User_frm();
            frm4.ShowDialog();

            a = list.ListUsers();
            dataGridView1.DataSource = a;
            a = list.ListFingers();
            dataGridView2.DataSource = a;
            a = list.ListDepartment();
            dataGridView3.DataSource = a;
            a = list.ListAdmins();
            dataGridView4.DataSource = a;
        }
                //FingerPrint
        private void button4_Click(object sender, EventArgs e)
        {
            persn_authority = 1;
            Add_FingerPrint_frm frm = new Add_FingerPrint_frm();
            frm.ShowDialog();
            a = list.ListFingers();
            dataGridView2.DataSource = a;
            
        }

        


        //Delete komutları..
                //User
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            if (MessageBox.Show("Do you want to delete " + row.Cells["Name"].Value + "'s Informations ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                list.Delete_FingerPrint(row.Cells["Username"].Value.ToString());
                list.Delete_User(row.Cells["Username"].Value.ToString());
                MessageBox.Show("Your deletion has been successful.", "Delete Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                a = list.ListUsers();
                dataGridView1.DataSource = a;
                a = list.ListFingers();
                dataGridView2.DataSource = a;
                a = list.ListAdmins();
                dataGridView4.DataSource = a;
                a = list.ListDepartment();
                dataGridView3.DataSource = a;
            }
        }
                //FingerPrint
        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.SelectedRows[0];
            if (MessageBox.Show("Do you want to delete " + row.Cells["Name"].Value + "'s Finger Print ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                list.Delete_FingerPrint(row.Cells["DATA"].Value.ToString());
                MessageBox.Show("Your deletion has been successful.", "Delete Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                a = list.ListFingers();
                dataGridView2.DataSource = a;
            }
        }
                //Department
        private void button7_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView3.SelectedRows[0];
            if (MessageBox.Show("Do you want to delete " + row.Cells["Department"].Value + "'s Informations ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                list.Delete_Department(row.Cells["Department"].Value.ToString());

                MessageBox.Show("Your deletion has been successful.", "Delete Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                a = list.ListUsers();
                dataGridView1.DataSource = a;
                a = list.ListFingers();
                dataGridView2.DataSource = a;
                a = list.ListAdmins();
                dataGridView4.DataSource = a;
                a = list.ListDepartment();
                dataGridView3.DataSource = a;
            }

        }



        //Search komutları..
                //User
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                a = list.ListUsers();
                dataGridView1.DataSource = a;
            }
            else
            {
                a = list.SearchUser(textBox1.Text);
                dataGridView1.DataSource = a;

            }
        }
                //Finger
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                a = list.ListFingers();
                dataGridView2.DataSource = a;
            }
            else
            {
                a = list.SearchFinger(textBox2.Text.ToString());
                dataGridView2.DataSource = a;

            }
        }
                //Department
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                a = list.ListDepartment();
                dataGridView3.DataSource = a;
            }
            else
            {
                a = list.SearchDepartment(textBox3.Text);
                dataGridView3.DataSource = a;

            }
        }
                //admin
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                a = list.ListAdmins();
                dataGridView4.DataSource = a;
            }
            else
            {
                a = list.SearchAdmin(textBox4.Text);
                dataGridView4.DataSource = a;

            }
        }





        //Update komutları..
                //User
        private void button2_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            Admn_username= row.Cells["UserName"].Value.ToString();
            
            Update_User_frm updateuser = new Update_User_frm();
            updateuser.ShowDialog();
            a = list.ListUsers();
            dataGridView1.DataSource = a;
            a = list.ListFingers();
            dataGridView2.DataSource = a;
            a = list.ListAdmins();
            dataGridView4.DataSource = a;
            a = list.ListDepartment();
            dataGridView3.DataSource = a;


        }
                //Department
        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView3.SelectedRows[0];
            Admin_Department = row.Cells["Department"].Value.ToString();
            Update_Department_frm frm = new Update_Department_frm();
            frm.ShowDialog();
            a = list.ListDepartment();
            dataGridView3.DataSource = a;
            a = list.ListUsers();
            dataGridView1.DataSource = a;
        }



      
        //change your settings
        private void label6_Click(object sender, EventArgs e)
        {
            Admn_username = Main.UserName;

            Update_User_frm updateuser = new Update_User_frm();
            updateuser.ShowDialog();

            a = list.ListUsers();
            dataGridView1.DataSource = a;
            a = list.ListFingers();
            dataGridView2.DataSource = a;
            a = list.ListAdmins();
            dataGridView4.DataSource = a;
            a = list.ListDepartment();
            dataGridView3.DataSource = a;

            //change password yazcaz
        }


      
        //log out -- kapat
        private void label7_Click(object sender, EventArgs e)
        {
            admn_kapatflag = true;
            this.Close();


        }
        //minimize
        private void label12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //exit
        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //kapanırken
        private void Admin_Page_frm_FormClosing(object sender, FormClosingEventArgs e)
        {   
           if (admn_kapatflag==false) 
            {
                Application.Exit();
            }
           
        }
        
        
        
        //google 
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com;");
        }
        //facebook
        private void pictureBox6_Click(object sender, EventArgs e)
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




        ///////////////////////////////////////////////////////////////
    }
}
