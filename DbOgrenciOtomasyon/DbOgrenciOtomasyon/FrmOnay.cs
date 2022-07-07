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
    public partial class FrmOnay : Form
    {
        public FrmOnay()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void btnbul_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Select * from Tbl_SecilenDers Where OgrenciNumara=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", txtnogir.Text);
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
            bgl.baglanti().Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtders1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtders2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtders3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtders4.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btndersekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("update Tbl_SecilenDers set Secmeli1=@p1, Secmeli2=@p2, AnaDers1=@p3, AnaDers2=@p4 where OgrenciNumara=@p5", bgl.baglanti());
            komutekle.Parameters.AddWithValue("@p1", txtders1.Text);
            komutekle.Parameters.AddWithValue("@p2", txtders2.Text);
            komutekle.Parameters.AddWithValue("@p3", txtders3.Text);
            komutekle.Parameters.AddWithValue("@p4", txtders4.Text);
            komutekle.Parameters.AddWithValue("@p5", txtnogir.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ders Ekleme Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnderssil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_SecilenDers where OgrenciNumara=@p1",bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1",txtnogir.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ders Kaydı Silme Başarılı Bir Şekilde Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
