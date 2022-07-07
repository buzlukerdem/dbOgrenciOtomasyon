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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        private void btnogrgir_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ogrenciler where OgrenciNo=@p1 and OgrenciSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtogrno.Text);
            komut.Parameters.AddWithValue("@p2", txtogrsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmOgrenciDetay fr = new FrmOgrenciDetay();
                fr.no = txtogrno.Text;
                fr.sifre = txtogrsifre.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Öğrenci Numarası & Şifre");
            }
            bgl.baglanti().Close();

        }

        private void btnhocagir_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hocalar where HocaTC=@p1 and HocaSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktchoca.Text);
            komut.Parameters.AddWithValue("@p2", txthocasifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHoca fr = new FrmHoca();
                fr.TC = msktchoca.Text;
                fr.sifre = txthocasifre.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı TC Kimlik Numarası & Şifre");
            }
            bgl.baglanti().Close();
        }

        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOgrUyeol fr = new FrmOgrUyeol();
            fr.Show();
        }

        private void btnmemurgir_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Memurlar where MemurTC=@p1 and MemurSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktcmemur.Text);
            komut.Parameters.AddWithValue("@p2", txtmemursifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmMemur fr = new FrmMemur();
                fr.TC = msktcmemur.Text;
                fr.sifre = txtmemursifre.Text;
                fr.Show();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC Kimlik Numarası & Şifre");
            }
            bgl.baglanti().Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
