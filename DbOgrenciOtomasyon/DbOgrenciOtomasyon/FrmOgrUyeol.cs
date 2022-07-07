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
    public partial class FrmOgrUyeol : Form
    {
        public FrmOgrUyeol()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        private void FrmOgrUyeol_Load(object sender, EventArgs e)
        {

        }

        private void txtkayıtol_Click(object sender, EventArgs e)
        {
            SqlCommand tabloyaekle = new SqlCommand("insert into Tbl_SecilenDers (OgrenciNumara) values (@g1)", bgl.baglanti());
            tabloyaekle.Parameters.AddWithValue("@g1", txtogrno.Text);
            tabloyaekle.ExecuteNonQuery();
            bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("insert into Tbl_Ogrenciler (OgrenciAd,OgrenciSoyad,OgrenciNo,BolumID,OgrenciSifre) values (@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtogrno.Text);
            komut.Parameters.AddWithValue("@p4", label6.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text.ToString());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Başarılı Bir Şekilde Gerçekleşmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void cmbbolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbbolum.Text == "Bilgisayar Mühendisliği")
            {
                label6.Text = "1";
            }else if(cmbbolum.Text == "Makine Mühendisliği")
            {
                label6.Text = "2";
            }
            else if (cmbbolum.Text == "Elektrik Mühendisliği")
            {
                label6.Text = "3";
            }
        }
    }
}
