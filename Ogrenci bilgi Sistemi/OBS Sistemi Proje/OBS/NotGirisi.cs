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
using excel= Microsoft.Office.Interop.Excel;

namespace OBS
{
    public partial class NotGirisi : Form
    {
        public NotGirisi()
        {
            InitializeComponent();
        }

        ObsDbEntitiessDB db = new ObsDbEntitiessDB();
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var deger1 = db.Ogrencis.Where(x => x.OgrNo == textBox3.Text).Select(y => y.OgrAd).FirstOrDefault();
            var deger2 = db.Ogrencis.Where(x => x.OgrNo == textBox3.Text).Select(y => y.OgrSoyad).FirstOrDefault();

            textBox2.Text = deger1;
            textBox1.Text = deger2;
        }

        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textnotid.Text = "";
            textvize.Text = "";
            textfinal.Text = "";
            textharfnotu.Text = "";
            textortalama.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.secilmisdersler().ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ORTALAMA HESAPLAMA VE HARF NOTU HESAPLAMA
            Not_ t = new Not_();
            int v, f;
            float Ortalama;
            v = int.Parse(textvize.Text);
            f = int.Parse(textfinal.Text);
            Ortalama = ((v * 40) / 100) + ((f * 60) / 100);
            textortalama.Text = Ortalama.ToString();

            if (Ortalama >= 90 && Ortalama <= 100)
            {
                textharfnotu.Text = "AA";
            }
            else if (Ortalama >= 80 && Ortalama < 90)
            {
                textharfnotu.Text = "BA";
            }
            else if (Ortalama >= 70 && Ortalama < 80)
            {
                textharfnotu.Text = "BB";
            }
            else if (Ortalama >= 60 && Ortalama < 70)
            {
                textharfnotu.Text = "CB";
            }
            else if (Ortalama >= 50 && Ortalama < 60)
            {
                textharfnotu.Text = "CC";
            }
            else
                textharfnotu.Text = "FF";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // NOT GİRME EKLEME İŞLEMLERİ
            Not_ t = new Not_();
            t.vize = int.Parse(textvize.Text);
            t.final = int.Parse(textfinal.Text);
            t.DersKodu = textdersadi.Text.ToString();//bak
            t.OgrNo = textBox3.Text.ToString();
            t.ortalama = float.Parse(textortalama.Text);
            t.harfnotu = textharfnotu.Text;
            db.Not_.Add(t);
            db.SaveChanges();
            MessageBox.Show("not bilgileri eklendi");

            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //güncelleme
            int notıd = int.Parse(textnotid.Text);// not ıd
            var x = db.Not_.Find(notıd);

            x.vize = int.Parse(textvize.Text);
            x.final = int.Parse(textfinal.Text);
            x.ortalama = int.Parse(textortalama.Text);
            x.harfnotu = textharfnotu.Text.ToString();
            db.SaveChanges();
            MessageBox.Show("Öğrenci not bilgileri başarılı bir şekilde güncellendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             
            dataGridView2.DataSource = db.secilmisdersler().ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            //textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//derssecID
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();//Öğrenci ad 
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();//öğrenci soyad


            string f = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            var deger1 = db.Ders.Where(x => x.DersAdi.ToString() == f).Select(y => y.DersKodu).FirstOrDefault();
            textdersadi.Text = deger1;//ders kodunun elde edilmesi...


            string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var deger = db.DersSecmes.Where(x => x.DersSecID.ToString() == d).Select(y => y.OgrNo).FirstOrDefault();//öğrenci no girişi
            textBox3.Text = deger;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //notıd si girilmesi
            textnotid.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //silme dersnot 
            string d = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            var sil = db.Not_.Where(x => x.NotID.ToString() == d).FirstOrDefault();
            db.Not_.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("seçili not silinmiştir.");
        }

        private void NotGirisi_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            
            SqlCommand komut2 = new SqlCommand("Select * from Ders", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            System.Data.DataTable ds2 = new System.Data.DataTable();
            da2.Fill(ds2);
            comboBox1.ValueMember = "DersKodu";
            comboBox1.DisplayMember = "DersAdi";
            comboBox1.DataSource = ds2;


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.Ders
                           select new
                           {
                               x.DersKodu,
                               x.Yariyil,
                               x.DersAdi,
                               x.Dil,
                               x.Kredi,
                               x.Akts,
                               x.BolumID


                           };
            
            string i = comboBox1.SelectedValue.ToString();
            dataGridView1.DataSource = degerler.Where(y => y.DersKodu == i ).ToList();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var deger1 = db.Ogrencis.Where(x => x.OgrNo == textBox3.Text).Select(y => y.OgrAd).FirstOrDefault();
            var deger2 = db.Ogrencis.Where(x => x.OgrNo == textBox3.Text).Select(y => y.OgrSoyad).FirstOrDefault();

            textBox1.Text = deger2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count > 0)
            {
                excel.Application app = new excel.Application();
                app.Visible = true;
                Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sayfa = (Worksheet)kitap.Sheets[1];
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    Range alan = (Range)sayfa.Cells[1, 1];
                    alan.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
                }
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGridView2.Rows.Count; j++)
                    {
                        Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
                        alan2.Cells[2, 1] = dataGridView2[i, j].Value;
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            menüEkrani menu = new menüEkrani();
            
                menu.OgretimElemanıToolStripMenuItem.Enabled = true;
                menu.OgrenciToolStripMenuItem.Visible = false;
                menu.personelToolStripMenuItem.Visible = false;
                menu.yöneticiToolStripMenuItem.Visible = false;
            
            this.Hide();
            menu.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.tbNotlar().ToList();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void NotGirisi_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void NotGirisi_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void NotGirisi_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
