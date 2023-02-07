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
    public partial class OgrenciEklemeSilme : Form
    {
        public OgrenciEklemeSilme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        SqlCommand com;
        ObsDbEntitiessDB db = new ObsDbEntitiessDB();
        public void verilerigoster()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", baglanti);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }
       
        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
         

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
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

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.OgrNo = textBox1.Text;
            ogrenci.OgrAd = textBox2.Text;
            ogrenci.OgrSoyad = textBox3.Text;
            ogrenci.Cinsiyet = textBox4.Text;
            ogrenci.DogumTar = dateTimePicker1.Value;
            ogrenci.OgrMail = textBox6.Text;
            ogrenci.OgrSifre = textBox8.Text;
            ogrenci.OgrTelNo = textBox5.Text;
            ogrenci.Sinif = textBox7.Text;
            ogrenci.DanismanID = textBox9.Text;
            ogrenci.PersonelID = int.Parse(textBox10.Text);
            ogrenci.BolumID = byte.Parse(comboBox2.SelectedValue.ToString());
            ogrenci.OgrYetkiID = textBox11.Text;
            ogrenci.OgrResim = textBox12.Text;


            db.Ogrencis.Add(ogrenci);
            db.SaveChanges();
            MessageBox.Show("Öğrenci bilgileri sisteme başarılı bir Şekilde kaydedildi.");
            baglanti.Close();

        }

        private void OgrenciEklemeSilme_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'obsDbDataSet.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.obsDbDataSet.Ogrenci);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Bolum",baglanti);
            ////SqlDataReader dr = komut.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            System.Data.DataTable ds = new System.Data.DataTable();
            da.Fill(ds);
            comboBox2.ValueMember = "BolumID";
            comboBox2.DisplayMember = "BolumAd";
            comboBox2.DataSource = ds;
            baglanti.Close();

            //SqlCommand komut2 = new SqlCommand("Select * from OgretimElemani", baglanti);
            //SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            //DataTable ds2 = new DataTable();
            //da2.Fill(ds2);
            //comboBox3.ValueMember = "OgrtID";
            //comboBox3.DisplayMember = "OgrtAd";
            //comboBox1.ValueMember = "OgrtID";
            //comboBox1.DisplayMember = "OgrtSoyad";
            //comboBox3.DataSource = ds2;
            //comboBox1.DataSource = ds2;


            //SqlCommand komut3 = new SqlCommand("Select * from Ogrenci_İsleri", baglanti);
            //SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            //DataTable ds3 = new DataTable();
            //da3.Fill(ds3);
            //comboBox4.ValueMember = "PersonelID";
            //comboBox4.DisplayMember = "PersonelAd";
            //comboBox5.ValueMember = "PersonelID";
            //comboBox5.DisplayMember = "PersonelSoyad";
            //comboBox4.DataSource = ds3;
            //comboBox5.DataSource = ds3;
            //baglanti.Close();

            //SqlCommand komut4 = new SqlCommand("Select * from Ogrenci", baglanti);
            //SqlDataAdapter da4 = new SqlDataAdapter(komut4);
            //DataTable ds4 = new DataTable();
            //da4.Fill(ds4);
            ////comboBox1.ValueMember = "Sinif";
            ////comboBox1.DataSource = ds3;
            ///




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Sil = new SqlCommand("Delete Ogrenci where OgrNo=@p1", baglanti);
            Sil.Parameters.AddWithValue("@p1", textBox1.Text);
            Sil.ExecuteNonQuery();
            MessageBox.Show("Öğrenci başarıyla silindi");
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox12.Text = openFileDialog1.FileName;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            string sorgu = "Update Ogrenci set  OgrAd=@ogrnciad, OgrSoyad=@ogrsoyad, OgrYetkiID= @yetki, DogumTar = @dogumtar, Cinsiyet = @cinsiyet where OgrNo=@ogrenciNo";
            com = new SqlCommand(sorgu, baglanti);
            com.Parameters.AddWithValue("@ogrenciNo", textBox1.Text);
            com.Parameters.AddWithValue("@ogrnciad", textBox2.Text);
            com.Parameters.AddWithValue("@ogrsoyad", textBox3.Text);
            com.Parameters.AddWithValue("@cinsiyet", textBox4.Text);
            com.Parameters.AddWithValue("@dogumtar", dateTimePicker1.Value);
            com.Parameters.AddWithValue("@mail", textBox6.Text);
            com.Parameters.AddWithValue("@sifre", textBox8.Text);
            com.Parameters.AddWithValue("@telNo", textBox5.Text);
            com.Parameters.AddWithValue("@sinif", textBox7.Text);
            com.Parameters.AddWithValue("@danisman", textBox9.Text);
            com.Parameters.AddWithValue("@perID", textBox10.Text);
            com.Parameters.AddWithValue("@bolum", comboBox2.SelectedValue.ToString());
            com.Parameters.AddWithValue("@yetki", textBox11.Text);
            com.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci bilgileri başarıyla güncellendi.");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.Ogrencis
                           select new
                           {
                               x.OgrNo,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.Cinsiyet,
                               x.DogumTar,
                               x.Sinif,
                               x.OgrMail,
                               x.OgrSifre,
                               x.Bolum.BolumID,
                               x.OgrResim,
                               x.OgrTelNo,
                               x.DanismanID,
                               x.OgrenciIsleri.PersonelID,
                               x.OgrYetkiID,
                               
                               
                           };
            int i = byte.Parse(comboBox2.SelectedValue.ToString());
            string d = textBox9.Text.ToString();
            //int a = int.Parse(textBox10.Text.ToString());
            dataGridView1.DataSource = degerler.Where(y => y.BolumID == i && y.DanismanID == d /*&& y.PersonelID==a*/ ).ToList();
            verilerigoster();
            temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
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
        private void OgrenciEklemeSilme_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void OgrenciEklemeSilme_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void OgrenciEklemeSilme_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
