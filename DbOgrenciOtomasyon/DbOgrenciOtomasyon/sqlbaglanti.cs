using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DbOgrenciOtomasyon
{
    class sqlbaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-HJL1ER0;Initial Catalog=DbOgrenciOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
