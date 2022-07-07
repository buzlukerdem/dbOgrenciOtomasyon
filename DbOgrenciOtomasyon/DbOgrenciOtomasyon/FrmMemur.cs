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
    public partial class FrmMemur : Form
    {
        public FrmMemur()
        {
            InitializeComponent();
        }
        public string TC;
        public string adsoyad;
        public string sifre;

        sqlbaglanti bgl = new sqlbaglanti();
        private void FrmMemur_Load(object sender, EventArgs e)
        {
            lbltcno.Text = TC;
            lblsifre.Text = sifre;

            // dersleri getirme datagrid e
            SqlCommand komut = new SqlCommand("Select * from Tbl_Dersler", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //hocaları getirme datagrid e
            SqlCommand komut3 = new SqlCommand("Select HocaID,HocaAdSoyad, HocaBrans, HocaTC,HocaSifre from Tbl_Hocalar", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(komut3);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;


            // ad soyad getirme
            SqlCommand komut2 = new SqlCommand("Select MemurAdSoyad from Tbl_Memurlar where MemurTC=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", lbltcno.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " ";
            }


            // dersleri getirme cmb ye
            SqlCommand komut4 = new SqlCommand("Select DersAd from Tbl_Dersler", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                cmbders.Items.Add(dr4[0]);
            }
            bgl.baglanti().Close();
        }

        private void cmbders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbders.Text == "MobilProgramlama")
            {
                label9.Text = "1";
            }
            else if (cmbders.Text == "VeriTabanıYönetimSistemi")
            {
                label9.Text = "2";
            }
            else if (cmbders.Text == "YazılımMühendisliği")
            {
                label9.Text = "3";
            }
            else if (cmbders.Text == "BilgisayarAğları")
            {
                label9.Text = "4";
            }
            else if (cmbders.Text == "Girişimcilik")
            {
                label9.Text = "5";
            }

            cmbhoca.Items.Clear();
            SqlCommand komut = new SqlCommand("Select HocaAdSoyad from Tbl_Hocalar where HocaBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbhoca.Items.Add(dr[0] + " ");
            }
            bgl.baglanti().Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Dersler ");
        }

        private void btndersekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into Tbl_Dersler (DersAd) values (@d1)",bgl.baglanti());
            komutekle.Parameters.AddWithValue("@d1",txtdersgir.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ders Ekleme Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnhocaekle_Click(object sender, EventArgs e)
        {
            if (cmbders.Text == "MobilProgramlama")
            {
                label12.Text = "1";
            }
            else if (cmbders.Text == "VeriTabanıYönetimSistemi")
            {
                label12.Text = "2";
            }
            else if (cmbders.Text == "YazılımMühendisliği")
            {
                label12.Text = "3";
            }
            else if (cmbders.Text == "BilgisayarAğları")
            {
                label12.Text = "4";
            }
            else if (cmbders.Text == "Girişimcilik")
            {
                label12.Text = "5";
            }

            SqlCommand komutekle = new SqlCommand("insert into Tbl_Hocalar (HocaAdSoyad,HocaBrans,HocaTC,HocaSifre) values (@h1,@h2,@h3,@h4)",bgl.baglanti());
            komutekle.Parameters.AddWithValue("@h1",cmbhoca.Text);
            komutekle.Parameters.AddWithValue("@h2", label12.Text);
            komutekle.Parameters.AddWithValue("@h3", msktc.Text);
            komutekle.Parameters.AddWithValue("@h4", txtsifre.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Hoca Ekleme Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            cmbders.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            cmbhoca.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            msktc.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            txtsifre.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btnhocasil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Tbl_Hocalar where HocaTC=@p1",bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1",msktc.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Hoca Silme Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void btnderssil_Click(object sender, EventArgs e)
        {
            SqlCommand komutderssil = new SqlCommand("delete from Tbl_Dersler where DersID=@p1",bgl.baglanti());
            komutderssil.Parameters.AddWithValue("@p1",txtid.Text);
            komutderssil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ders Silme İşlemi Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtdersgir.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btndersguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update Tbl_Dersler set DersAd=@p1 where DersID=@p2",bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtdersgir.Text);
            komutguncelle.Parameters.AddWithValue("@p2",txtid.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ders Güncelleme İşlemi Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
