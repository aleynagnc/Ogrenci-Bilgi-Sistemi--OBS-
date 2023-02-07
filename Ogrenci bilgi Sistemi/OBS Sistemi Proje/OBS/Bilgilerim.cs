using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBS.Entity;
using System.Data.SqlClient;


namespace OBS
{
    public partial class Bilgilerim : Form
    {
        public Bilgilerim()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        ObsDbEntitiessDB db = new ObsDbEntitiessDB();
        SqlCommand com;
        public string numara;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            menüEkrani menu = new menüEkrani();
            menu.menuStrip1.Visible = true;
            menu.OgrenciToolStripMenuItem.Enabled = true;
            menu.personelToolStripMenuItem.Visible = false;
            menu.OgretimElemanıToolStripMenuItem.Visible = false;
            menu.yöneticiToolStripMenuItem.Visible = false;
            this.Hide();
            menu.numara = textBox1.Text;
            menu.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Bilgilerim_Load(object sender, EventArgs e)
        {

            textBox1.Text = numara;
            textBox2.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.OgrAd).FirstOrDefault();
            textBox3.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.OgrSoyad).FirstOrDefault();
            textBox9.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.Sinif).FirstOrDefault();
            textBox5.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.Cinsiyet).FirstOrDefault();
            textBox6.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.OgrMail).FirstOrDefault();
            textBox8.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.OgrSifre).FirstOrDefault();
            textBox10.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.OgretimElemani.OgrtAd).FirstOrDefault();
            textBox7.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.OgretimElemani.OgrtSoyad).FirstOrDefault();
            textBox11.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.Bolum.BolumAd).FirstOrDefault();
            textBox4.Text = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.OgrTelNo).FirstOrDefault();
            pictureBox3.ImageLocation = db.Ogrencis.Where(x => x.OgrNo == numara).Select(y => y.OgrResim).FirstOrDefault();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "Update Ogrenci set OgrMail = @mail, OgrSifre=@sifre, OgrResim=@OgrResim, OgrTelNo=@telNo where OgrNo=@ogrenciNo";
            com = new SqlCommand(sorgu,baglanti);
            com.Parameters.AddWithValue("@ogrenciNo", textBox1.Text);
            com.Parameters.AddWithValue("@mail", textBox6.Text);
            com.Parameters.AddWithValue("@sifre", textBox8.Text);
            com.Parameters.AddWithValue("@telNo", textBox4.Text);
            com.Parameters.AddWithValue("@OgrResim", pictureBox3.ImageLocation);
            com.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgileriniz başarıyla güncellendi.");
            OgrenciGiris ogrenci = new OgrenciGiris();
            this.Hide();
            ogrenci.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        bool move;
        int mouse_x;
        int mouse_y;

        private void Bilgilerim_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Bilgilerim_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;

        }

        private void Bilgilerim_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
