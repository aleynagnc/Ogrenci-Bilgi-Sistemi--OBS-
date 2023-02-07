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
using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;

namespace OBS
{
    public partial class OgrenciGoruntule : Form
    {
        public OgrenciGoruntule()
        {
            InitializeComponent();
        }

        ObsDbEntitiessDB db = new ObsDbEntitiessDB();
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
       

        private void Öğrencilerim_Load(object sender, EventArgs e)
        {
            comboBox3.DisplayMember = "Cinsiyet";
            comboBox3.ValueMember = "OgrNo";
            comboBox3.DataSource = db.Ogrencis.ToList();

            comboBox2.DisplayMember = "Sinif";
            comboBox2.ValueMember = "OgrNo";
            comboBox2.DataSource = db.Ogrencis.ToList();

           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Ogrenci numarasına göre sıralama...

            var degerler = from x in db.Ogrencis
                           select new
                           {
                               x.OgrNo,
                               Öğrenci_AD_SOYAD = x.OgrAd + " " + x.OgrSoyad,
                               x.Cinsiyet,
                               x.DogumTar,
                               x.OgrTelNo,
                               x.Sinif,
                               x.OgrResim,
                               x.OgrMail,
                               Danısman_ad_soyad = x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad,
                               x.Bolum.BolumAd,

                           };
            string i = textBox1.Text;

            var deger1 = db.Ogrencis.Where(x => x.OgrNo == i).Select(y => y.OgrNo.ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => y.OgrNo.ToString() == deger1).ToList();

            textBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Öğrenci adına göre sıralama...

            var degerler = from x in db.Ogrencis
                           select new
                           {
                               x.OgrNo,
                               Öğrenci_AD_SOYAD = x.OgrAd + " " + x.OgrSoyad,
                               x.Cinsiyet,
                               x.DogumTar,
                               x.Sinif,
                               x.OgrMail,
                               x.OgrTelNo,
                               x.Bolum.BolumAd,
                               Danısman_ad_soyad = x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad,
                               x.OgrResim,
                               x.OgrAd,
                               x.OgrSoyad



                           };
            string i = textBox2.Text;

            var deger1 = db.Ogrencis.Where(x => x.OgrAd == i).Select(y => y.OgrAd.ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => y.OgrAd.ToString() == deger1).ToList();
            dataGridView1.Columns["OgrAd"].Visible = false;
            dataGridView1.Columns["OgrSoyad"].Visible = false;

            textBox2.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //öğrenci soyadına göre sıralama...
            var degerler = from x in db.Ogrencis
                           select new
                           {
                               x.OgrNo,
                               Öğrenci_AD_SOYAD = x.OgrAd + " " + x.OgrSoyad,
                               x.Cinsiyet,
                               x.DogumTar,
                               x.Sinif,
                               x.OgrMail,
                               x.OgrTelNo,
                               x.Bolum.BolumAd,
                               Danısman_ad_soyad = x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad,
                               x.OgrResim,
                               x.OgrAd,
                               x.OgrSoyad

                           };
            string i = textBox3.Text;

            var deger1 = db.Ogrencis.Where(x => x.OgrSoyad == i).Select(y => y.OgrSoyad.ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => y.OgrSoyad == deger1).ToList();
            dataGridView1.Columns["OgrAd"].Visible = false;
            dataGridView1.Columns["OgrSoyad"].Visible = false;

            textBox3.Text = "";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Öğrenci Ad Soyada göre listeleme...
            var degerler = from x in db.Ogrencis
                           select new
                           {
                               x.OgrNo,
                               Öğrenci_AD_SOYAD = x.OgrAd + " " + x.OgrSoyad,
                               x.Cinsiyet,
                               x.DogumTar,
                               x.Sinif,
                               x.OgrMail,
                               x.OgrTelNo,
                               x.Bolum.BolumAd,
                               Danısman_ad_soyad = x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad,
                               x.OgrResim,
                               x.OgrAd,
                               x.OgrSoyad

                           };
            string i = textBox5.Text;

            var deger = db.Ogrencis.Where(x => x.OgrAd + " " + x.OgrSoyad == i).Select(y => (y.OgrAd + " " + y.OgrSoyad).ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => (y.OgrAd + " " + y.OgrSoyad).ToString() == deger).ToList();
            dataGridView1.Columns["OgrAd"].Visible = false;
            dataGridView1.Columns["OgrSoyad"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listeleme...
            dataGridView1.DataSource = db.Ogrencibil().ToList();//store prosedür
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //cinsiyete göre sırala
            var degerler = from x in db.Ogrencis
                           select new
                           {
                               x.OgrNo,
                               Öğrenci_AD_SOYAD = x.OgrAd + " " + x.OgrSoyad,
                               x.Cinsiyet,
                               x.DogumTar,
                               x.Sinif,
                               x.OgrMail,
                               x.OgrTelNo,
                               x.Bolum.BolumAd,
                               Danısman_ad_soyad = x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad,
                               x.OgrResim,
                               x.OgrAd,
                               x.OgrSoyad

                           };
            //dataGridView1.DataSource = degerler.Where(y => Convert.ToString(y.DersAdi) == comboBox2.SelectedItem.ToString()).ToList();
            string d = comboBox3.SelectedItem.ToString();
            dataGridView1.DataSource = degerler.Where(y => y.Cinsiyet.ToString() == d).ToList();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //sınıfa göre sırala
            var degerler = from x in db.Ogrencis
                           select new
                           {
                               x.OgrNo,
                               Öğrenci_AD_SOYAD = x.OgrAd + " " + x.OgrSoyad,
                               x.Cinsiyet,
                               x.DogumTar,
                               x.Sinif,
                               x.OgrMail,
                               x.OgrTelNo,
                               x.Bolum.BolumAd,
                               Danısman_ad_soyad = x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad,
                               x.OgrResim,
                               x.OgrAd,
                               x.OgrSoyad

                           };
            //dataGridView1.DataSource = degerler.Where(y => Convert.ToString(y.DersAdi) == comboBox2.SelectedItem.ToString()).ToList();
            string d = comboBox2.SelectedItem.ToString();
            dataGridView1.DataSource = degerler.Where(y => y.Sinif.ToString() == d).ToList();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //danısmana ad soyada göre sıralma..
            var degerler = from x in db.Ogrencis
                           select new
                           {
                               x.OgrNo,
                               Öğrenci_AD_SOYAD = x.OgrAd + " " + x.OgrSoyad,
                               x.Cinsiyet,
                               x.DogumTar,
                               x.Sinif,
                               x.OgrMail,
                               x.OgrTelNo,
                               x.Bolum.BolumAd,
                               Danısman_ad_soyad = x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad,
                               x.OgrResim,
                               x.OgrAd,
                               x.OgrSoyad


                           };
            string i = textBox6.Text;

            var deger1 = db.Ogrencis.Where(x => x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad == i).Select(y => (y.OgretimElemani.OgrtAd + " " + y.OgretimElemani.OgrtSoyad).ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => y.OgrNo.ToString() == deger1).ToList();
            dataGridView1.Columns["OgrtAd"].Visible = false;
            dataGridView1.Columns["OgrtSoyad"].Visible = false;

            textBox5.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //var degerler = from x in db.Ogrencis
            //               select new
            //               {
            //                   x.OgrNo,
            //                   Öğrenci_AD_SOYAD = x.OgrAd + " " + x.OgrSoyad,
            //                   x.Cinsiyet,
            //                   x.DogumTar,
            //                   x.Sinif,
            //                   x.OgrMail,
            //                   x.OgrTelNo,
            //                   x.Bolum.BolumAd,
            //                   Danısman_ad_soyad = x.OgretimElemani.OgrtAd + " " + x.OgretimElemani.OgrtSoyad,
            //                   x.OgrResim,
            //                   x.OgrAd,
            //                   x.OgrSoyad


            //               };
            ////dataGridView1.DataSource = degerler.Where(y => Convert.ToString(y.DersAdi) == comboBox2.SelectedItem.ToString()).ToList();
            //string d = comboBox1.SelectedItem.ToString();
            //dataGridView1.DataSource = degerler.Where(y => y.BolumAd.ToString() == d).ToList();
        }

        private void OgrenciGoruntule_Load(object sender, EventArgs e)
        {
          

            comboBox3.Items.Add("K");
            comboBox3.Items.Add("E");

            comboBox2.Items.Add("Hazırlık");
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //yetkilendirmeSinif.PersonelYetkiID = (String)dr["PersonelYetkiID"];
            menüEkrani menu = new menüEkrani();
            //menu.menuStrip1.Visible = true;
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

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                excel.Application app = new excel.Application();
                app.Visible = true;
                Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sayfa = (Worksheet)kitap.Sheets[1];
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    Range alan = (Range)sayfa.Cells[1, 1];
                    alan.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
                        alan2.Cells[2, 1] = dataGridView1[i, j].Value;
                    }
                }
            }
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void OgrenciGoruntule_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;

        }

        private void OgrenciGoruntule_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void OgrenciGoruntule_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
