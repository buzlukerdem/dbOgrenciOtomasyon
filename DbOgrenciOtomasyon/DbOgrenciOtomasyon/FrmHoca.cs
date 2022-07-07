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
    public partial class FrmHoca : Form
    {
        public FrmHoca()
        {
            InitializeComponent();
        }

        public string TC;
        public string sifre;
        public string adsoyad;

        sqlbaglanti bgl = new sqlbaglanti();
        private void FrmHoca_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;
            lblSifre.Text = sifre;

            //ad soyad
            SqlCommand komut = new SqlCommand("Select HocaAdSoyad from Tbl_Hocalar where HocaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " ";
            }

            SqlCommand komut2 = new SqlCommand("Select * from Tbl_Notlar", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            datagridsinav.DataSource = dt2;
        }

        private void datagridsinav_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = datagridsinav.SelectedCells[0].RowIndex;
            txtnotid.Text = datagridsinav.Rows[secilen].Cells[0].Value.ToString();
            txtogrıd.Text = datagridsinav.Rows[secilen].Cells[2].Value.ToString();
            txtdersıd.Text = datagridsinav.Rows[secilen].Cells[1].Value.ToString();
            txtogrno.Text = datagridsinav.Rows[secilen].Cells[3].Value.ToString();
            txtvize.Text = datagridsinav.Rows[secilen].Cells[4].Value.ToString();
            txtfinal.Text = datagridsinav.Rows[secilen].Cells[5].Value.ToString();
            txtort.Text = datagridsinav.Rows[secilen].Cells[6].Value.ToString();

        }


        private void txtort_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNotEkle_Click(object sender, EventArgs e)
        {
            SqlCommand notekle = new SqlCommand("insert into Tbl_Notlar (DersID,OgrenciID,OgrNo,Vize,Final) values (@p1,@p2,@p3,@p4,@p5)" ,bgl.baglanti());
            notekle.Parameters.AddWithValue("@p1",txtdersıd.Text.ToString());
            notekle.Parameters.AddWithValue("@p2",txtogrıd.Text.ToString());
            notekle.Parameters.AddWithValue("@p3", txtogrno.Text.ToString());
            notekle.Parameters.AddWithValue("@p4", txtvize.Text.ToString());
            notekle.Parameters.AddWithValue("@p5", txtfinal.Text.ToString());
            notekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Sınav Notu Ekleme Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand notbul = new SqlCommand("update Tbl_Notlar set Ortalama = (Vize*0.4 + Final*0.6)", bgl.baglanti());
            notbul.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ortalama Bulma İşlemi Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnnotsil_Click(object sender, EventArgs e)
        {
     
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update Tbl_Notlar set DersID=@p1, OgrenciID=@p2, OgrNo=@p3, Vize=@p4,Final=@p5, Ortalama=@p6 where NotID=@p7", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtdersıd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtogrıd.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txtogrno.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtvize.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtfinal.Text);
            komutguncelle.Parameters.AddWithValue("@p6", txtort.Text);
            komutguncelle.Parameters.AddWithValue("@p7", txtnotid.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Sinav Notu Güncelleme İşlemi Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmOnay fr = new FrmOnay();
            fr.Show();
        }
    }
}
