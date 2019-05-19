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
    public partial class Add_Department_frm : Form
    {
        public Add_Department_frm()
        {
            InitializeComponent();
        }
        ////////////////////////////////////////////////////////



        ///Add Department kod satırı...
        private void button1_Click(object sender, EventArgs e)
        {
            database1Entities atx = new database1Entities();           
            try
            {
                var x = atx.Departments.Where(y => y.Department1 == textBox1.Text.ToString()).First();
                label2.Text = "This Department already exist. Try another Department..";
                textBox1.Clear();
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    label2.Text = "Don't leave empty area..";
                    
                }
                else
                {
                    Department b = new Department();
                    b.Department1 = textBox1.Text;
                    atx.Departments.Add(b);
                    atx.SaveChanges();
                    MessageBox.Show("Registration process successful", "Registration status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        // Form açılınca text'e focuslan
        private void Add_department_frm_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        //kapat
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
        ////////////////////////////////////////////////////////
    }
}
