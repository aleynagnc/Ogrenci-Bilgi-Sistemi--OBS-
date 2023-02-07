using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace OBS
{
    public partial class importexport : Form
    {
        public importexport()
        {
            InitializeComponent();
            //con = new SqlConnection(db.GetConnection());
            //loadrecords();
        }
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataReader dr;
        //ConnectionDB db = new ConnectionDB();

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "Excel Dosyaları";
            save.DefaultExt = "xlsx";
            save.Filter = "xlsx Dosyaları (.xlslx)|.xlsx|Tüm Dosyalar(.)|.";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sayfa1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Excel Dışa Aktarım";
                for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;

                }
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();

                    }
                }


                workbook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, excel.XlSaveAsAccessMode.xlExclusive, Type.Missing);
                app.Quit();


            }
        }

        private void importexport_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select OgrNo, OgrAd, OgrSoyad,Cinsiyet,DogumTar,OgrTelNo,Sinif,OgrMail,OgrSifre,DanismanID, BolumID from Ogrenci");
            cmd.Connection = baglanti;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable datatable = new System.Data.DataTable();
            da.Fill(datatable);
            dataGridView2.DataSource = datatable;

            //listele();

        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void importexport_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void importexport_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void importexport_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
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



        //void listele()
        //{
        //    SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=ObsDb;Integrated Security=True");
        //    SqlCommand cmd = new SqlCommand("select OgrNo, OgrAd, OgrSoyad ,Cinsiyet,DogumTar,OgrTelNo,Sinif,OgrMail,OgrSifre,DanismanID, BolumID from Ogrenci");
        //    cmd.Connection = baglanti;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    System.Data.DataTable datatable = new System.Data.DataTable();
        //    da.Fill(datatable);
        //    dataGridView1.DataSource = datatable;
        //}

        private void button3_Click(object sender, EventArgs e)
        {

            //Microsoft.Office.Interop.Excel.Application app;
            //Microsoft.Office.Interop.Excel.Workbook workbook;
            //Microsoft.Office.Interop.Excel.Worksheet worksheet;
            //Microsoft.Office.Interop.Excel.Range range;

            //int xlRow;
            //string strFileName;
            //OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "Excel Office| *.xls; *.xlsx";
            //open.ShowDialog();
            //strFileName = open.FileName;


            //app = new Microsoft.Office.Interop.Excel.Application();
            //workbook = app.Workbooks.Open(strFileName);
            //worksheet = workbook.Worksheets["Sayfa1"];
            //range = worksheet.UsedRange;

            //int i = 0;

            //for (xlRow = 2; xlRow <= range.Rows.Count; xlRow++)
            //{
            //    if (range.Cells[xlRow, 1].Text != "")
            //    {

            //        dataGridView1.Rows.Add(range.Cells[xlRow, 1].Text, range.Cells[xlRow, 2].Text, range.Cells[xlRow, 3].Text, range[xlRow, 4].Text,
            //        range[xlRow, 5].Text, range[xlRow, 6].Text, range[xlRow, 7].Text, range[xlRow, 8].Text, range[xlRow, 9].Text, range[xlRow, 10].Text,
            //        range[xlRow, 11].Text, range[xlRow, 12].Text, range[xlRow, 13].Text);
            //        i++;
            //    }
            //}
            //workbook.Close();
            //app.Quit();


        }
        //public void loadrecords()
        ////{
        ////    //dataGridView1.Rows.Clear();
        ////    int i = 0;
        ////    con.Open();
        ////    cmd = new SqlCommand("select * from Ogrenci", con);
        ////    dr = cmd.ExecuteReader();
        ////    while (dr.Read())
        ////    {

        ////        dataGridView1.Rows.Add(dr["OgrNo"].ToString(), dr["OgrAd"].ToString(), dr["OgrSoyad"].ToString(),
        ////            dr["Cinsiyet"].ToString(), dr["DogumTar"].ToString(), dr["OgrTelNo"].ToString(),
        ////            dr["Sinif"].ToString(), dr["OgrResim"].ToString(), dr["OgrMail"].ToString(), dr["OgrSifre"].ToString(),
        ////            dr["DanismanID"].ToString(), dr["BolumID"].ToString(), dr["PersonelID"].ToString());
        ////        i++;
        ////    }
        ////    dr.Close();
        ////    con.Close();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            //// veri tabanına kaydetme
            //for (int i = 0; i < dataGridView1.Rows.Count + 1; i++)
            //{
            //    con.Open();
            //    cmd = new SqlCommand("insert into Ogrenci (OgrNo,OgrAd,OgrSoyad,Cinsiyet, DogumTar, OgrTelNo, Sinif, OgrResim, OgrMail, OgrSifre, DanismanID, BolumID,PersonelID) values (@OgrNo,@OgrAd,@OgrSoyad,@Cinsiyet,@DogumTar,@OgrTelNo,@Sinif,@OgrResim,@OgrMail,@OgrSifre,@DanismanID,@BolumID,@PersonelID)");
            //    cmd.Connection = con;
            //    cmd.Parameters.AddWithValue("@OgrNo", dataGridView1.Rows[i].Cells[1].Value.ToString());
            //    cmd.Parameters.AddWithValue("@OgrAd", dataGridView1.Rows[i].Cells[2].Value.ToString());
            //    cmd.Parameters.AddWithValue("@OgrSoyad", dataGridView1.Rows[i].Cells[3].Value.ToString());
            //    cmd.Parameters.AddWithValue("@Cinsiyet", dataGridView1.Rows[i].Cells[4].Value.ToString());
            //    cmd.Parameters.AddWithValue("@DogumTar", dataGridView1.Rows[i].Cells[5].Value.ToString());
            //    cmd.Parameters.AddWithValue("@OgrTelNo", dataGridView1.Rows[i].Cells[6].Value.ToString());
            //    cmd.Parameters.AddWithValue("@Sinif", dataGridView1.Rows[i].Cells[7].Value.ToString());
            //    cmd.Parameters.AddWithValue("@OgrResim", dataGridView1.Rows[i].Cells[8].Value.ToString());
            //    cmd.Parameters.AddWithValue("@OgrMail", dataGridView1.Rows[i].Cells[9].Value.ToString());
            //    cmd.Parameters.AddWithValue("@OgrSifre", dataGridView1.Rows[i].Cells[10].Value.ToString());
            //    cmd.Parameters.AddWithValue("@DanismanID", dataGridView1.Rows[i].Cells[11].Value.ToString());
            //    cmd.Parameters.AddWithValue("@BolumID", dataGridView1.Rows[i].Cells[12].Value.ToString());
            //    cmd.Parameters.AddWithValue("@PersonelID", dataGridView1.Rows[i].Cells[12].Value.ToString());
            //    // cmd.Parameters.AddWithValue("@OgrYetkiID", dataGridView1.Rows[i].Cells[13].Value.ToString());
            //    //cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            //MessageBox.Show("başarılı bir şeklilde veriler alındı...", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //loadrecords();


        }
    }


}
