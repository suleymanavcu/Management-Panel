using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace suleyman
{
    public partial class Update_Department_frm : Form
    {
        public Update_Department_frm()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////
        database1Entities ctx = new database1Entities();

        // seçilen departmentı getir.
        private void Update_Department_frm_Load(object sender, EventArgs e)
        {
            var x = ctx.Departments.Where(y => y.Department1 == Admin_Page_frm.Admin_Department).FirstOrDefault();
            textBox1.Text = x.Department1.ToString();
        }
        //update.
        private void button1_Click(object sender, EventArgs e)
        {
            var x = ctx.Departments.Where(y => y.Department1 == Admin_Page_frm.Admin_Department).FirstOrDefault();
            
            if (textBox1.Text == "")
            {
                label2.Text = "Don't leave department area empty !";
            }
            else
            {
                try
                {
                    var z = ctx.Departments.Where(y => y.Department1 == textBox1.Text).First();
                    label2.Text = "This Department already exist ! ";
                }
                catch
                {
                        x.Department1 = textBox1.Text.ToString();
                        ctx.SaveChanges();
                        MessageBox.Show("Update process is successful !");
                        this.Close();
                }
            }
        }
        //kapat.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ////////////////////////////////////////////////////////////////////////
    }
}
