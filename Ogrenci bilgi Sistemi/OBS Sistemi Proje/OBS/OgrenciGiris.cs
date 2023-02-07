using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OBS
{
    public partial class OgrenciGiris : Form
    {
        public OgrenciGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlDataReader dr;
        SqlCommand com;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
            com = new SqlCommand();
            baglanti.Open();
            com.Connection = baglanti;
            com.CommandText = "select * from Ogrenci where OgrNo='" + textBox1.Text + "'AND OgrSifre='" + textBox2.Text + "'";
            //"' AND OgrMail='" + textBox1.Text + "
            dr = com.ExecuteReader();
            
            if (dr.Read())
            {
                yetkilendirmeSinif.OgrYetkiID =(String) dr["OgrYetkiID"];
                menüEkrani menu = new menüEkrani();
                menu.menuStrip1.Visible = true;
                if (yetkilendirmeSinif.OgrYetkiID == "4")
                {
                    menu.OgrenciToolStripMenuItem.Enabled = true;
                    menu.personelToolStripMenuItem.Visible = false;
                    menu.OgretimElemanıToolStripMenuItem.Visible = false;
                    menu.yöneticiToolStripMenuItem.Visible = false;
                }
                this.Hide();
                menu.numara = textBox1.Text;
                menu.ShowDialog();    
                
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış, tekrar deneyiniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginEkrani login = new LoginEkrani();
            this.Hide();
            login.ShowDialog();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            textBox2.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SifremiUnuttumOgr sifre = new SifremiUnuttumOgr();
            this.Hide();
            sifre.ShowDialog();
        }

        private void OgrenciGiris_Load(object sender, EventArgs e)
        {

        }

        private void OgrenciGiris_Load_1(object sender, EventArgs e)
        {

        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void OgrenciGiris_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void OgrenciGiris_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void OgrenciGiris_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
