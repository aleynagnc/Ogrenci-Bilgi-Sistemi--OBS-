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
    public partial class menüEkrani : Form
    {
        public menüEkrani()
        {
            InitializeComponent();
        }

        ObsDbEntitiessDB db = new ObsDbEntitiessDB();
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        public string numara;
        private void menüEkrani_Load(object sender, EventArgs e)
        {
            textBox1.Text = numara;
        }

        private void öğrenciİşleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ders ders = new Ders();
            this.Hide();
            ders.ShowDialog();
            
        }

        private void bilgilerimToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dersSeçmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DersSecmeIslemleri ders = new DersSecmeIslemleri();
            this.Hide();
            ders.ShowDialog();
        }

        private void bilgilerimToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bilgilerim bilgi = new Bilgilerim();
            this.Hide();
            bilgi.numara = textBox1.Text;
            bilgi.ShowDialog();
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciEklemeSilme ogrenci = new OgrenciEklemeSilme();
            this.Hide();
            ogrenci.ShowDialog();
        }

        private void yöneticiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginEkrani login = new LoginEkrani();
            this.Hide();
            login.ShowDialog();
        }

        private void öğrenciGörüntüleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void öğretimElemanıGörüntüleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
     
        }

        private void öğretimElemanıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OgretimElemaniEkleSil ogretimelemani = new OgretimElemaniEkleSil();
            this.Hide();
            ogretimelemani.ShowDialog();
        }

        private void öğretimElemanıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretimElemaniGoruntule akademisyen = new OgretimElemaniGoruntule();
            this.Hide();
            akademisyen.ShowDialog();
        }

        private void öğrenciGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciGoruntule ogrenci = new OgrenciGoruntule();
            this.Hide();
            ogrenci.ShowDialog();
        }

        private void öğrencilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciGoruntule ogrenci = new OgrenciGoruntule();
            this.Hide();
            ogrenci.ShowDialog();
        }

        private void öğrenciİşleriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void öğrenciİşleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OgrencIsleriEkleSil personel = new OgrencIsleriEkleSil();
            this.Hide();
            personel.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
            
        }

        private void fakülteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bolumGoruntuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dersToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void personelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notGörüntülemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notgoster notgoruntule = new Notgoster();
            this.Hide();
            notgoruntule.ShowDialog();
        }

        private void notGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotGirisi giris = new NotGirisi();
            this.Hide();
            giris.ShowDialog();
        }

        private void ımportExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

      
        private void yedekleYedektenDönToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            YedekleYedektenDön yedekleYedektenDön = new YedekleYedektenDön();
            this.Hide();
            yedekleYedektenDön.ShowDialog();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void menüEkrani_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void menüEkrani_MouseUp(object sender, MouseEventArgs e)
        {

            move = false;
        }

        private void menüEkrani_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void panel5_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void importExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importexport ie = new importexport();
            this.Hide();
            ie.ShowDialog();
        }
    }
}
