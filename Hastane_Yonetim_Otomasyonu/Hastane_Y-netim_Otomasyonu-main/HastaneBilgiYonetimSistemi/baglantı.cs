using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneBilgiYonetimSistemi
{
    public class baglantı
    {
       public int genelid;
        public SqlConnection bagla()
        {

            //    SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=MCI_Hospital;" +
            //"user=sa;password=1234");

            //Bağlantı ayarı buradan yapıldıgında kendı bılgısayarınızdan da erısebılırsınız
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-QJ144O6\\SQLEXPRESS; Initial Catalog=MCI_Hospital;Integrated Security=True");
            baglan.Open();
            
            return baglan;
        }
      

    }
}
