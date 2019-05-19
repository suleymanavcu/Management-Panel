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
    public partial class Add_FingerPrint_frm : Form
    {
        public Add_FingerPrint_frm()
        {
            InitializeComponent();
        }
        ////////////////////////////////////////////////

        //Form load olunca combobox'ı doldur ve seçili kullanıcı comboboxda seç.
        private void Add_FingerPrint_frm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Enabled = true;
            baglanti ctx = new baglanti();
            SqlDataReader dr;
            dr = ctx.FillComboBox("User1");

            if (Main.yetki == 99)
            {
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Authority_Id"]) != 99)
                        comboBox1.Items.Add(dr["UserName"]);
                }
            }
            else if (Main.yetki == 0)
            {
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Authority_Id"]) !=99 && Convert.ToInt32(dr["Authority_Id"]) != 0)
                        comboBox1.Items.Add(dr["UserName"]);
                }
            }
            textBox1.Clear();
            
            if(Update_User_frm.flag==1)
            {
                comboBox1.SelectedItem = Update_User_frm.nameflag;
                comboBox1.Enabled = false;
            }
          
        }
        //Girilen FingerPrinti kaydet.
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti ctx = new baglanti();
            if (comboBox1.SelectedItem != null && textBox1.Text != "")
            {
                try
                {
                    ctx.Add_FingerPrint(comboBox1.SelectedItem.ToString(), textBox1.Text.ToString());

                    MessageBox.Show("Registration process successful", "Registration status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    label3.Text = "Don't leave empty area.";
                }
            }
            else
            {
                label3.Text = "Don't leave empty area.";
            }
        }
        //Kapat.
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            textBox1.Clear();
            this.Close();
        }

        ////////////////////////////////////////////////
    }
}
