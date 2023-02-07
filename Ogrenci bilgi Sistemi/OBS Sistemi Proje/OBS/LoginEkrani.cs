using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS
{
    public partial class LoginEkrani : Form
    {
        public LoginEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciGiris ogrenci = new OgrenciGiris();
            this.Hide();
            ogrenci.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AkademisyenGiris akademisyen = new AkademisyenGiris();
            this.Hide();
            akademisyen.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PersonelGiris personel = new PersonelGiris();
            this.Hide();
            personel.ShowDialog();
        }

        private void LoginEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yoneticigiris yonetici = new Yoneticigiris();
            this.Hide();
            yonetici.ShowDialog();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void LoginEkrani_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void LoginEkrani_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void LoginEkrani_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
