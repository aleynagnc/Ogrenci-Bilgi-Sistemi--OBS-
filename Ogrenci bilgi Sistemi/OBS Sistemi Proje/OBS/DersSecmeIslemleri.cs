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
using OBS.Entity;
using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;

namespace OBS
{
    public partial class DersSecmeIslemleri : Form
    {
        public DersSecmeIslemleri()
        {
            InitializeComponent();
        }
        ObsDbEntitiessDB db = new ObsDbEntitiessDB();
        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");

        void temizle()
        {
            textBolum.Text = " ";
            textdersadi.Text = "";
            textyariyil.Text = "";
            textdersakts.Text = "";
            textdersdil.Text = "";
            textderskredi.Text = "";
            textdersakts.Text = "";
            textBolum.Text = "";

        }

        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler,baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

      


        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridviewdeki verileri textboxlara iletme
            textderskodu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textyariyil.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textdersadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textdersdil.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textderskredi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textdersakts.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBolum.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void DersSecmeIslemleri_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Bolum", baglanti);
            ////SqlDataReader dr = komut.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            System.Data.DataTable ds = new System.Data.DataTable();
            da.Fill(ds);
            comboBox2.ValueMember = "BolumID";
            comboBox2.DisplayMember = "BolumAd";
            comboBox2.DataSource = ds;
            SqlCommand komut2 = new SqlCommand("Select * from Ders", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            System.Data.DataTable ds2 = new System.Data.DataTable();
            da2.Fill(ds2);
            comboBox1.ValueMember = "DersKodu";
            comboBox1.DisplayMember = "DersAdi";
            comboBox1.DataSource = ds2;

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ders ekleme;
            DersSecme sec = new DersSecme();
            sec.OgrNo = textBox3.Text.ToString();
            sec.DersKodu = textderskodu.Text.ToString();
            sec.BolumID = int.Parse(textBolum.Text);
            db.DersSecmes.Add(sec);
            db.SaveChanges();
            MessageBox.Show("Ders eklendi");
            temizle();
        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                               x.BolumID,
                           };
            int i = byte.Parse(comboBox2.SelectedValue.ToString());
            dataGridView1.DataSource = degerler.Where(y => y.BolumID == i).ToList();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            int d = byte.Parse(comboBox2.SelectedValue.ToString());
            string i = comboBox1.SelectedValue.ToString();
            dataGridView1.DataSource = degerler.Where(y => y.DersKodu == i && y.BolumID==d).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ders silme

            string d = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            var sil = db.DersSecmes.Where(x => x.DersSecID.ToString() == d).FirstOrDefault();
            db.DersSecmes.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("seçili ders silinmiştir.");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //var degerler = from x in db.Ders
            //               select new
            //               {
            //                   x.DersKodu,
            //                   x.Yariyil,
            //                   x.DersAdi,
            //                   x.Dil,
            //                   x.Kredi,
            //                   x.Akts,
            //                   x.BolumID
            //               };
            //int i = int.Parse(textBolum.Text);
            //dataGridView1.DataSource = degerler.Where(y => y.BolumID == i).ToList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textderskredi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var deger1 = db.Ogrencis.Where(x => x.OgrNo == textBox3.Text).Select(y => y.OgrAd).FirstOrDefault();
            var deger2 = db.Ogrencis.Where(x => x.OgrNo == textBox3.Text).Select(y => y.OgrSoyad).FirstOrDefault();
           
            textBox2.Text = deger1;
            textBox1.Text = deger2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            menüEkrani menu = new menüEkrani();
            if (yetkilendirmeSinif.OgrYetkiID == "4")
            {
                menu.OgrenciToolStripMenuItem.Enabled = true;
                menu.personelToolStripMenuItem.Visible = false;
                menu.OgretimElemanıToolStripMenuItem.Visible = false;
                menu.yöneticiToolStripMenuItem.Visible = false;
            }
            this.Hide();
            menu.numara = textBox3.Text;
            menu.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           

            //ders listeleme
            dataGridView2.DataSource = db.secilmisdersler();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //ders listesi
            dataGridView1.DataSource = db.Ders.ToList();
            //dataGridView1.DataSource = db.Not_.ToList();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (dataGridView2.Rows.Count > 0)
            //{
            //    excel.Application app = new excel.Application();
            //    app.Visible = true;
            //    Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
            //    Worksheet sayfa = (Worksheet)kitap.Sheets[1];
            //    for (int i = 0; i < dataGridView2.Columns.Count; i++)
            //    {
            //        Range alan = (Range)sayfa.Cells[1, 1];
            //        alan.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
            //    }
            //    for (int i = 0; i < dataGridView2.Columns.Count; i++)
            //    {
            //        for (int j = 0; j < dataGridView2.Rows.Count; j++)
            //        {
            //            Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
            //            alan2.Cells[2, 1] = dataGridView2[i, j].Value;
            //        }
            //    }
            }

        bool move;
        int mouse_x;
        int mouse_y;
        private void DersSecmeIslemleri_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;

        }

        private void DersSecmeIslemleri_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void DersSecmeIslemleri_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
    }

