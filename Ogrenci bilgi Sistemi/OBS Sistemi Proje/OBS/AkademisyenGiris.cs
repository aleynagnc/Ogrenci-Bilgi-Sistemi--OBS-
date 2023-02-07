using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OBS
{
    public partial class AkademisyenGiris : Form
    {
        public AkademisyenGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlDataReader dr;
        SqlCommand com;


        private void label1_Click(object sender, EventArgs e)
        {

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

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
            com = new SqlCommand();
            baglanti.Open();
            com.Connection = baglanti;
            com.CommandText = "select * from OgretimElemani where OgrtID='"+textBox1.Text+"'AND OgrtSifre='"+textBox2.Text+"'";
            dr = com.ExecuteReader();
            
            if (dr.Read())
            {
                yetkilendirmeSinif.OgrtYetkiID = (String)dr["OgrtYetkiID"];
                menüEkrani menu2 = new menüEkrani();
                menu2.menuStrip1.Visible = true;
                    if (yetkilendirmeSinif.OgrtYetkiID == "2")
                    {
                    menu2.OgretimElemanıToolStripMenuItem.Enabled = true;
                    menu2.OgrenciToolStripMenuItem.Visible = false;
                    menu2.personelToolStripMenuItem.Visible = false;
                    menu2.yöneticiToolStripMenuItem.Visible = false;
                    }
                    this.Hide();
                    menu2.ShowDialog();
                    
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış, tekrar deneyiniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SifremiUnuttumOgrt akademisyen = new SifremiUnuttumOgrt();
            this.Hide();
            akademisyen.ShowDialog();
        }

        private void AkademisyenGiris_Load(object sender, EventArgs e)
        {

        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void AkademisyenGiris_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;

        }

        private void AkademisyenGiris_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void AkademisyenGiris_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
    }

