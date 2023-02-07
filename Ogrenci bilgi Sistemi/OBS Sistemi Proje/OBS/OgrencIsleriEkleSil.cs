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
    public partial class OgrencIsleriEkleSil : Form
    {
        public OgrencIsleriEkleSil()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        SqlCommand com;

        ObsDbEntitiessDB db = new ObsDbEntitiessDB();

        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";


        }

        public void verilerigoster()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from OgrenciIsleri", baglanti);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            menüEkrani menu = new menüEkrani();
            menu.yöneticiToolStripMenuItem.Enabled = true;
            menu.OgrenciToolStripMenuItem.Visible = false;
            menu.personelToolStripMenuItem.Visible = false;
            menu.OgretimElemanıToolStripMenuItem.Visible = false;
            this.Hide();
            menu.ShowDialog();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            OgrenciIsleri personel = new OgrenciIsleri();
            personel.PersonelAd = textBox2.Text;
            personel.PersonelSoyad = textBox3.Text;
            personel.PersonelMail = textBox5.Text;
            personel.PersonelTel = textBox4.Text;
            personel.PersonelSifre = textBox6.Text;
            personel.PersonelYetkiID = textBox7.Text;


            db.OgrenciIsleris.Add(personel);
            db.SaveChanges();
            MessageBox.Show("Personel bilgileri sisteme başarılı bir Şekilde kaydedildi.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Sil = new SqlCommand("Delete OgreciIsleri where PersonelID=@p1", baglanti);
            Sil.Parameters.AddWithValue("@p1", textBox1.Text);
            Sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel başarıyla silindi");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "Update OgrenciIsleri set  PersonelAd=@ad, PersonelSoyad=@soyad, PersonelYetkiID= @yetki , PersonelTel = @telNo, PersonelMail=@mail, PersonelSifre= @sifre  where PersonelID=@personelID";
            com = new SqlCommand(sorgu, baglanti);
            com.Parameters.AddWithValue("@personelID", textBox1.Text);
            com.Parameters.AddWithValue("@ad", textBox2.Text);
            com.Parameters.AddWithValue("@soyad", textBox3.Text);
            com.Parameters.AddWithValue("@telNo", textBox4.Text);
            com.Parameters.AddWithValue("@mail", textBox5.Text);
            com.Parameters.AddWithValue("@sifre", textBox6.Text);
            com.Parameters.AddWithValue("@yetki", textBox7.Text);
            com.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel bilgileri başarıyla güncellendi.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.OgrenciIsleris
                           select new
                           {
                               x.PersonelID,
                               x.PersonelAd,
                               x.PersonelSoyad,
                               x.PersonelTel,
                               x.PersonelMail,
                               x.PersonelSifre,
                               x.PersonelYetkiID
                           };
            string i = textBox2.Text;
            dataGridView1.DataSource = degerler.Where(y => y.PersonelAd == i).ToList();
            verilerigoster();
            temizle();
        }

        private void OgrencIsleriEkleSil_Load(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    excel.Application app = new excel.Application();
            //    app.Visible = true;
            //    Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
            //    Worksheet sayfa = (Worksheet)kitap.Sheets[1];
            //    for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //    {
            //        Range alan = (Range)sayfa.Cells[1, 1];
            //        alan.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            //    }
            //    for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //    {
            //        for (int j = 0; j < dataGridView1.Rows.Count; j++)
            //        {
            //            Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
            //            alan2.Cells[2, 1] = dataGridView1[i, j].Value;
            //        }
            //    }
            //}
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void OgrencIsleriEkleSil_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void OgrencIsleriEkleSil_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void OgrencIsleriEkleSil_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
