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
    public partial class SifremiUnuttumPersonel : Form
    {
        public SifremiUnuttumPersonel()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlDataReader dr;
        SqlCommand com;

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PersonelGiris personel = new PersonelGiris();
            this.Hide();
            personel.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
            com = new SqlCommand();
            baglanti.Open();
            com.Connection = baglanti;
            com.CommandText = "select * from OgrenciIsleri where PersonelMail='" + textBox1.Text + "'";
            SqlCommand komut = new SqlCommand("Update OgrenciIsleri set PersonelSifre=@personelSifre where PersonelMail=@personelMail", baglanti);
            komut.Parameters.AddWithValue("PersonelMail", textBox1.Text);
            komut.Parameters.AddWithValue("PersonelSifre", textBox2.Text);
            komut.ExecuteNonQuery();
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                baglanti.Close();
                MessageBox.Show("Şifreniz başarıyla güncellendi");
                PersonelGiris personel = new PersonelGiris();
                this.Hide();
                personel.ShowDialog();
            }

            else
            {
                MessageBox.Show("Böyle bir mail adresi bulunmamaktadır.");

            }

        }

        private void SifremiUnuttumPersonel_Load(object sender, EventArgs e)
        {

        }
        bool move;
        int mouse_x;
        int mouse_y;

        private void SifremiUnuttumPersonel_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void SifremiUnuttumPersonel_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void SifremiUnuttumPersonel_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
