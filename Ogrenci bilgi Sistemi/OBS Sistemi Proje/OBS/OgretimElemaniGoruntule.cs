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
    public partial class OgretimElemaniGoruntule : Form
    {
        public OgretimElemaniGoruntule()
        {
            InitializeComponent();
        }

        ObsDbEntitiessDB db = new ObsDbEntitiessDB();
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //akademisyen ID'ye göre
            var degerler = from x in db.OgretimElemanis
                           select new
                           {
                               x.OgrtID,
                               Akademisyen_AD_SOYAD = x.OgrtAd + " " + x.OgrtSoyad,
                               x.Unvan,
                               x.OgrtMail,

                           };
            string i = textBox1.Text;

            var deger1 = db.OgretimElemanis.Where(x => x.OgrtID == i).Select(y => y.OgrtID.ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => y.OgrtID.ToString() == deger1).ToList();

            textBox1.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //akademisyen adına göre sıralama...

            var degerler = from x in db.OgretimElemanis
                           select new
                           {
                               x.OgrtID,
                               Akademisyen_AD_SOYAD = x.OgrtAd + " " + x.OgrtSoyad,
                               x.Unvan,
                               x.OgrtMail,
                               x.OgrtAd,
                               x.OgrtSoyad

                           };
            string i = textBox2.Text;

            var deger1 = db.OgretimElemanis.Where(x => x.OgrtAd == i).Select(y => y.OgrtAd.ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => y.OgrtAd.ToString() == deger1).ToList();
            dataGridView1.Columns["OgrtAd"].Visible = false;
            dataGridView1.Columns["OgrtSoyad"].Visible = false;

            textBox2.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //akademisyen soyadına göre sıralama...
            var degerler = from x in db.OgretimElemanis
                           select new
                           {
                               x.OgrtID,
                               Akademisyen_AD_SOYAD = x.OgrtAd + " " + x.OgrtSoyad,
                               x.Unvan,
                               x.OgrtMail,
                               x.OgrtAd,
                               x.OgrtSoyad

                           };
            string i = textBox3.Text;

            var deger1 = db.OgretimElemanis.Where(x => x.OgrtSoyad == i).Select(y => y.OgrtSoyad.ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => y.OgrtSoyad == deger1).ToList();
            dataGridView1.Columns["OgrtAd"].Visible = false;
            dataGridView1.Columns["OgrtSoyad"].Visible = false;

            textBox3.Text = "";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Öğrenci Ad Soyada göre listeleme...
            var degerler = from x in db.OgretimElemanis
                           select new
                           {
                               x.OgrtID,
                               Akademisyen_AD_SOYAD = x.OgrtAd + " " + x.OgrtSoyad,
                               x.Unvan,
                               x.OgrtMail,
                               x.OgrtAd,
                               x.OgrtSoyad

                           };
            string i = textBox5.Text;

            var deger = db.OgretimElemanis.Where(x => x.OgrtAd + " " + x.OgrtSoyad == i).Select(y => (y.OgrtAd + " " + y.OgrtSoyad).ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => (y.OgrtAd + " " + y.OgrtSoyad).ToString() == deger).ToList();
            dataGridView1.Columns["OgrtAd"].Visible = false;
            dataGridView1.Columns["OgrtSoyad"].Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //listeleme...
            dataGridView1.DataSource = db.akademisyenbilgi().ToList();//store prosedür
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            menüEkrani menu = new menüEkrani();
          
            if (yetkilendirmeSinif.PersonelYetkiID == "3")
            {
                menu.personelToolStripMenuItem.Enabled = true;
                menu.OgrenciToolStripMenuItem.Visible = false;
                menu.OgretimElemanıToolStripMenuItem.Visible = false;
                menu.yöneticiToolStripMenuItem.Visible = false;
                this.Hide();
                menu.ShowDialog();
            }
            else
            {
                menu.OgretimElemanıToolStripMenuItem.Enabled = true;
                menu.OgrenciToolStripMenuItem.Visible = false;
                menu.personelToolStripMenuItem.Visible = false;
                menu.yöneticiToolStripMenuItem.Visible = false;
                this.Hide();
                menu.ShowDialog();
            }
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void OgretimElemaniGoruntule_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void OgretimElemaniGoruntule_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void OgretimElemaniGoruntule_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
