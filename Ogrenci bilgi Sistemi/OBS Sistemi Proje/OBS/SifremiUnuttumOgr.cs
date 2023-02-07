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
    public partial class SifremiUnuttumOgr : Form
    {
        public SifremiUnuttumOgr()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand com;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            textBox2.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OgrenciGiris ogrenci = new OgrenciGiris();
            this.Hide();
            ogrenci.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
            com = new SqlCommand();
            baglanti.Open();
            com.Connection = baglanti;
            com.CommandText = "select * from Ogrenci where OgrMail='" + textBox1.Text + "'";
            SqlCommand komut = new SqlCommand("Update Ogrenci set OgrSifre=@OgrenciSifre where OgrMail=@OgrenciMail", baglanti);
            komut.Parameters.AddWithValue("OgrenciMail", textBox1.Text);
            komut.Parameters.AddWithValue("OgrenciSifre", textBox2.Text);
            komut.ExecuteNonQuery();
            dr = com.ExecuteReader();
            

            if (dr.Read())
            {
                baglanti.Close();
                MessageBox.Show("Şifreniz başarıyla güncellendi");
                OgrenciGiris ogrenci = new OgrenciGiris();
                this.Hide();
                ogrenci.ShowDialog();
            }
            
            else
            {
                MessageBox.Show("Böyle bir mail adresi bulunmamaktadır.");

            }
            

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
        }

        private void SifremiUnuttumOgr_Load(object sender, EventArgs e)
        {

        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void SifremiUnuttumOgr_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void SifremiUnuttumOgr_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void SifremiUnuttumOgr_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
