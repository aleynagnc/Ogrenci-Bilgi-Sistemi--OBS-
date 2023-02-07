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
    public partial class Notgoster : Form
    {
        public Notgoster()
        {
            InitializeComponent();
        }

        ObsDbEntitiessDB db = new ObsDbEntitiessDB();
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        public string numara;
        public void verilerigoster()
        {
            //baglanti.Open();
            //SqlDataAdapter da = new SqlDataAdapter("Select * from Not_", baglanti);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //baglanti.Close();


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            //    var deger1 = db.Ogrencis.Where(x => x.OgrNo == textBox3.Text).Select(y => y.OgrAd).FirstOrDefault();
            //    var deger2 = db.Ogrencis.Where(x => x.OgrNo == textBox3.Text).Select(y => y.OgrSoyad).FirstOrDefault();


            //    textBox2.Text = deger1;
            //    textBox1.Text = deger2;

            var degerler = from x in db.Not_
                           select new
                           {
                               x.NotID,
                               x.vize,
                               x.final,
                               x.ortalama,
                               x.harfnotu,
                               x.OgrtID,
                               x.Der.DersKodu,
                               x.Ogrenci.OgrNo

                           };

            string i = textBox3.Text;

            var deger1 = db.Ogrencis.Where(x => x.OgrNo == i).Select(y => y.OgrNo.ToString()).FirstOrDefault();
            dataGridView1.DataSource = degerler.Where(y => y.OgrNo.ToString() == deger1).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NotGoruntuleme_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.tbNotlar();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //string i = textBox3.Text.ToString();
            //var degerler = db.Not_.Where(x => x.OgrNo == i).Select(y=>y.)

           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            menüEkrani menu = new menüEkrani();
            
                menu.OgrenciToolStripMenuItem.Enabled = true;
                menu.personelToolStripMenuItem.Visible = false;
                menu.OgretimElemanıToolStripMenuItem.Visible = false;
                menu.yöneticiToolStripMenuItem.Visible = false;
            
            this.Hide();
            menu.numara = textBox3.Text;
            menu.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Notgoster_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Notgoster_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Notgoster_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
