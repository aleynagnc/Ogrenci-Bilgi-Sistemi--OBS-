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
    public partial class Ders : Form
    {
        public Ders()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        SqlCommand com;
        ObsDbEntitiessDB db = new ObsDbEntitiessDB();

        public void temizle()
        {
            textderskodu.Text = "";
            textdersadi.Text = "";
            textdersakts.Text = "";
            textdersdil.Text = "";
            textderskredi.Text = "";
            textyariyil.Text = "";
       


        }
        public void verilerigoster()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ders", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Der ders = new Der();
            ders.BolumID = byte.Parse(comboBox1.SelectedValue.ToString());
            ders.DersKodu = textderskodu.Text;
            ders.Yariyil = textyariyil.Text;
            ders.DersAdi = textdersadi.Text;
            ders.Dil = textdersdil.Text;
            ders.Kredi = float.Parse(textderskredi.Text);
            ders.Akts = float.Parse(textdersakts.Text);

            db.Ders.Add(ders);
            db.SaveChanges();
            MessageBox.Show("Ders bilgileri sisteme başarılı bir Şekilde kaydedildi.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Sil = new SqlCommand("Delete Ders where DersKodu=@p1", baglanti);
            Sil.Parameters.AddWithValue("@p1", textderskodu.Text);
            Sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ders başarıyla silindi.");
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

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "Update Ders set  BolumID=@bolumID, Yariyil= @yariyil, DersAdi=@dersad,  Dil=@dil, Kredi= @kredi, Akts= @akts where DersKodu=@dersKodu";
            com = new SqlCommand(sorgu, baglanti);
            com.Parameters.AddWithValue("@dersKodu", textderskodu.Text);
            com.Parameters.AddWithValue("@BolumID", comboBox1.SelectedValue.ToString());
            com.Parameters.AddWithValue("@yariyil", textyariyil.Text );
            com.Parameters.AddWithValue("@dersad", textdersadi.Text);
            com.Parameters.AddWithValue("@dil", textdersdil.Text);
            com.Parameters.AddWithValue("@kredi", textderskredi.Text);
            com.Parameters.AddWithValue("@akts", textdersakts.Text);
            com.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ders bilgileri başarıyla güncellendi.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedItem= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textderskodu.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textyariyil.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textdersadi.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textdersdil.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textderskredi.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textdersakts.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
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
                               x.Bolum.BolumID

                           };
            string i = textderskodu.Text;
            dataGridView1.DataSource = degerler.Where(y => y.DersKodu == i).ToList();
            verilerigoster();
            temizle();
        }

        private void Ders_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Bolum", baglanti);
            ////SqlDataReader dr = komut.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = ds;
            baglanti.Close();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Ders_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Ders_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Ders_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
