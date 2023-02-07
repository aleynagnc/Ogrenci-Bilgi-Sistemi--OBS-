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
    public partial class SifremiUnuttumOgrt : Form
    {
        public SifremiUnuttumOgrt()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlDataReader dr;
        SqlCommand com;

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AkademisyenGiris akademisyen = new AkademisyenGiris();
            this.Hide();
            akademisyen.ShowDialog();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            textBox2.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
            com = new SqlCommand();
            baglanti.Open();
            com.Connection = baglanti;
            com.CommandText = "select * from OgretimElemani where OgrtID='" + textBox1.Text + "'";
            SqlCommand komut = new SqlCommand("Update OgretimElemani set OgrtSifre=@AkademisyenSifre where OgrtID=@AkademisyenID", baglanti);
            komut.Parameters.AddWithValue("AkademisyenID", textBox1.Text);
            komut.Parameters.AddWithValue("AkademisyenSifre", textBox2.Text);
            komut.ExecuteNonQuery();
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                baglanti.Close();
                MessageBox.Show("Şifreniz başarıyla güncellendi");
                AkademisyenGiris akademisyen = new AkademisyenGiris();
                this.Hide();
                akademisyen.ShowDialog();
            }

            else
            {
                MessageBox.Show("Böyle bir ID adresi bulunmamaktadır.");

            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SifremiUnuttumOgrt_Load(object sender, EventArgs e)
        {

        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void SifremiUnuttumOgrt_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void SifremiUnuttumOgrt_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void SifremiUnuttumOgrt_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
