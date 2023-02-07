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
    public partial class OgretimElemaniEkleSil : Form
    {
        public OgretimElemaniEkleSil()
        {
            InitializeComponent();
        }

        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
         


        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        SqlCommand com;
        ObsDbEntitiessDB db = new ObsDbEntitiessDB();

        public void verilerigoster()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from OgretimElemani", baglanti);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            OgretimElemani ogretimelemanı = new OgretimElemani();
            ogretimelemanı.OgrtID = textBox1.Text;
            ogretimelemanı.OgrtAd = textBox2.Text;
            ogretimelemanı.OgrtSoyad = textBox3.Text;
            ogretimelemanı.OgrtMail = textBox6.Text;
            ogretimelemanı.OgrtSifre = textBox8.Text;
            ogretimelemanı.Unvan = textBox4.Text;
            ogretimelemanı.OgrtYetkiID = textBox5.Text;

            db.OgretimElemanis.Add(ogretimelemanı);
            db.SaveChanges();
            MessageBox.Show("Akademisyen bilgileri sisteme başarılı bir Şekilde kaydedildi.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Sil = new SqlCommand("Delete OgretimElemani where OgrtID=@p1", baglanti);
            Sil.Parameters.AddWithValue("@p1", textBox1.Text);
            Sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Akademisyen başarıyla silindi.");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menüEkrani menu = new menüEkrani();
            menu.yöneticiToolStripMenuItem.Enabled = true;
            menu.OgrenciToolStripMenuItem.Visible = false;
            menu.personelToolStripMenuItem.Visible = false;
            menu.OgretimElemanıToolStripMenuItem.Visible = false;
            this.Hide();
            menu.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "Update OgretimElemani set  OgrtAd=@ad, OgrtSoyad=@soyad, OgrtYetkiID= @yetki, Unvan = @unvan, OgrtMail=@mail, OgrtSifre= @sifre where OgrtID=@akademisyenID";
            com = new SqlCommand(sorgu, baglanti);
            com.Parameters.AddWithValue("@akademisyenID", textBox1.Text);
            com.Parameters.AddWithValue("@ad", textBox2.Text);
            com.Parameters.AddWithValue("@soyad", textBox3.Text);
            com.Parameters.AddWithValue("@unvan", textBox4.Text);
            com.Parameters.AddWithValue("@mail", textBox6.Text);
            com.Parameters.AddWithValue("@sifre", textBox8.Text);
            com.Parameters.AddWithValue("@yetki", textBox5.Text);
            com.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğretim Elemanı bilgileri başarıyla güncellendi.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.OgretimElemanis
                           select new
                           {
                               x.OgrtID,
                               x.OgrtAd,
                               x.OgrtSoyad,
                               x.OgrtMail,
                               x.OgrtSifre,
                               x.Unvan,
                               x.OgrtYetkiID

                           };
            string i = textBox1.Text;
            dataGridView1.DataSource = degerler.Where(y => y.OgrtID == i ).ToList();
            verilerigoster();
            temizle();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OgretimElemaniEkleSil_Load(object sender, EventArgs e)
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
            }

        bool move;
        int mouse_x;
        int mouse_y;
        private void OgretimElemaniEkleSil_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;

        }

        private void OgretimElemaniEkleSil_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void OgretimElemaniEkleSil_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
    }

