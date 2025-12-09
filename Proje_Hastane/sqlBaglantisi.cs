using System.Data.SqlClient;

namespace Proje_Hastane
{
    public class sqlBaglantisi // sınıf ismi sqlBaglantisi
    {
        public SqlConnection baglanti() // baglanti method ismi
        {
            //            baglan; SqlConnection sınıfımdan türettiğim ve benim adresimi tutan nesnemin adı
            SqlConnection baglan = new SqlConnection("Data Source=YAZıLıM;Initial Catalog=Hastane_Proje;Integrated Security=True");
            baglan.Open();

            return baglan;
        }
    }
}
