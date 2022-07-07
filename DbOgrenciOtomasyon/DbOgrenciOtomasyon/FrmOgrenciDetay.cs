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

namespace DbOgrenciOtomasyon
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara;

        public string no;
        public string sifre;
        public string bolum;

        sqlbaglanti bgl = new sqlbaglanti();
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblno.Text = no;
            lblsifre.Text = sifre;
            SqlCommand komut = new SqlCommand("Select DersAd,OgrenciID,OgrNo,Vize,Final,Ortalama from Tbl_Notlar inner join Tbl_Dersler on Tbl_Notlar.DersID = Tbl_Dersler.DersID where OgrNo=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",no);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();

            // ad soyad getirme
            SqlCommand komut2 = new SqlCommand("Select OgrenciAd, OgrenciSoyad,BolumAd from Tbl_Ogrenciler inner join Tbl_Bolumler on Tbl_Ogrenciler.BolumID = Tbl_Bolumler.BolumID where OgrenciNo=@p1",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",lblno.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " "+ dr[1];
                lblBolum.Text = dr[2] + " ";
            }
            bgl.baglanti().Close();

            //dersleri getirme
            SqlCommand komut4 = new SqlCommand("Select DersAd from Tbl_Dersler", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                cmbdersler.Items.Add(dr4[0]);
            }
            bgl.baglanti().Close();

           
            SqlCommand komut3 = new SqlCommand("Select * from Tbl_SecilenDers Where OgrenciNumara=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", no);
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView2.DataSource = dt3;
            bgl.baglanti().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbdersler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbdersler.Text == "MobilProgramlama")
            {
                label6.Text = "1";
            }
            else if (cmbdersler.Text == "VeriTabanıYönetimSistemi")
            {
                label6.Text = "2";
            }
            else if (cmbdersler.Text == "YazılımMühendisliği")
            {
                label6.Text = "3";
            }
            else if (cmbdersler.Text == "BilgisayarAğları")
            {
                label6.Text = "4";
            }
            else if (cmbdersler.Text == "Girişimcilik")
            {
                label6.Text = "5";
            }

            cmbhocalar.Items.Clear();
            SqlCommand komut = new SqlCommand("Select HocaAdSoyad from Tbl_Hocalar where HocaBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label6.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbhocalar.Items.Add(dr[0] + " ");
            }
            bgl.baglanti().Close();
        }

        private void cmbhocalar_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SqlCommand komutekle = new SqlCommand("update Tbl_SecilenDers set Secmeli1=@p1, Secmeli2=@p2, AnaDers1=@p3, AnaDers2=@p4 where OgrenciNumara=@p5",bgl.baglanti());
            komutekle.Parameters.AddWithValue("@p1",txtders1.Text);
            komutekle.Parameters.AddWithValue("@p2", txtders2.Text);
            komutekle.Parameters.AddWithValue("@p3", txtders3.Text);
            komutekle.Parameters.AddWithValue("@p4", txtders4.Text);
            komutekle.Parameters.AddWithValue("@p5",lblno.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ders Ekleme Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtders1.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            txtders2.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            txtders3.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            txtders4.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            lblogrencino.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Danışman a  Gönderme İşlemi Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            SqlCommand tabloyaekle = new SqlCommand("insert into Tbl_SecilenDers (OgrenciNumara) values (@g1)",bgl.baglanti());
            tabloyaekle.Parameters.AddWithValue("@g1",lblogrencino.Text.ToString());
            tabloyaekle.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
    }
}
