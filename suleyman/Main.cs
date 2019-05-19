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
    public partial class Main : Form
    {
        



        public Main()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////

        public static int yetki=2;
        public static string UserName;


        database1Entities ctx = new database1Entities();   
        
            
        //Kullanıcı var mı boşluk varmı kontrolleri sağla ve ona göre admin veya user sayfasına yönlendir..
        private void button1_Click(object sender, EventArgs e)
        {   
            
            
            UserName = textBox1.Text;


            try
            {
                string sifre = baglanti.Hash222(textBox2.Text.ToString());
                var x = ctx.User1.Where(y => y.UserName == textBox1.Text.ToString() && y.Password == sifre).First();
                if (x != null)
                {
                    if (x.Authority_Id == 0)
                    {
                        yetki = x.Authority_Id;
                        Admin_Page_frm frm1 = new Admin_Page_frm();
                        frm1.ShowDialog();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        label2.Text = "";
                        textBox1.Focus();
                    }
                    else if (x.Authority_Id == 1)
                    {
                        yetki = x.Authority_Id;
                        User_Page_frm frm2 = new User_Page_frm();
                        frm2.ShowDialog();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        label2.Text = "";
                        textBox1.Focus();
                    }
                    else if (x.Authority_Id == 99)
                    {
                        yetki = x.Authority_Id;
                        Admin_Page_frm frm1 = new Admin_Page_frm();
                        frm1.ShowDialog();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        label2.Text = "";
                        textBox1.Focus();
                    }
                    else
                    {
                        
                    }
                }
            }
            catch
            {
                label2.Text = "Please enter a valid username and password !";
                
            }
        }
        //focuslanma kısmı
        private void Main_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        //çıkış
        private void label4_Click(object sender, EventArgs e)
        {
            
        }
        //clear kısmı
        private void label3_Click(object sender, EventArgs e)
        {
            Add_User_frm add_user = new Add_User_frm();
            add_user.ShowDialog();
            textBox1.Text = "";
            textBox2.Text = "";
            label2.Text = "";
        }


        ////////////////////////////////////////////////////////////////////////
    }
}
