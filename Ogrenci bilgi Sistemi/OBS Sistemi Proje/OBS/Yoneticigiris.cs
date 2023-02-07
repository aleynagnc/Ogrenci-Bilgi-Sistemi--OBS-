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

namespace OBS
{
    public partial class Yoneticigiris : Form
    {
        public Yoneticigiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand com;

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            com = new SqlCommand();
            baglanti.Open();
            com.Connection = baglanti;
            com.CommandText = "select * from Yonetici where YoneticiID='" + textBox1.Text + "'AND YoneticiSifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                yetkilendirmeSinif.YoneticiYetkiID = (String)dr["YoneticiYetkiID"];
                menüEkrani menu = new menüEkrani();
                menu.menuStrip1.Visible = true;
                if (yetkilendirmeSinif.YoneticiYetkiID == "1")
                {
                    menu.yöneticiToolStripMenuItem.Enabled = true;
                    menu.OgrenciToolStripMenuItem.Visible = false;
                    menu.personelToolStripMenuItem.Visible = false;
                    menu.OgretimElemanıToolStripMenuItem.Visible = false;
                    
                }
                this.Hide();
                menu.ShowDialog();
                baglanti.Close();

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış, tekrar deneyiniz.");
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            textBox2.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginEkrani login = new LoginEkrani();
            this.Hide();
            login.ShowDialog();
        }

        private void Yoneticigiris_Load(object sender, EventArgs e)
        {

        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Yoneticigiris_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Yoneticigiris_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Yoneticigiris_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
