using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace MusteriDefteri
{
    internal class DBislemleri
    {
        static string conAdres = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Zafer\\Desktop\\MuşteriDefteriX\\AdresDefteri.mdf;Integrated Security=True;Connect Timeout=30";

        static SqlConnection con = new SqlConnection(conAdres);

        public static DataSet ulkeleriCek()
        {
            string sql = "select * from Ulkeler";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ulkelerDS = new DataSet();
            con.Open();
            adapter.Fill(ulkelerDS);
            con.Close();
            return ulkelerDS;

        }
        public static DataSet sehirleriCek(int ulkeID)
        {
            string sql = "select * from Sehirler where UlkeID=@ulkeID";
            SqlConnection con = new SqlConnection(conAdres);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ulkeID", ulkeID);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet sehirlerDS = new DataSet();
            con.Open();
            adapter.Fill(sehirlerDS);
            con.Close();
            return sehirlerDS;

        }

        public static void Addss(string ad , string soyad, string tel, int sid, string adr )
        {
            SqlConnection con = new SqlConnection(conAdres);
            string sql = "insert into Kisiler values(@AD,@SOYAD,@TEL,@SİD,@ADR)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@AD",ad);
            cmd.Parameters.AddWithValue("@SOYAD", soyad);
            cmd.Parameters.AddWithValue("@TEL", tel);
            cmd.Parameters.AddWithValue("@SİD", sid);
            cmd.Parameters.AddWithValue("@ADR", adr);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        } //ADD

        public static DataSet search(string ad)
        {
            string sql = "select * from Kisiler where Adi like @AD+'%'";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@AD",ad);

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = cmd;

            DataSet sonuclar = new DataSet();
            con.Open();
            adaptor.Fill(sonuclar);
            con.Close();
            return sonuclar;

        }

        public static void Edit(int KkisiID,string ad,string soad , string tel, string adres )
        {
            string sql = "update Kisiler set Adi = @pAd, Soadi = @psoadi, Telefon = @pTelefon, Adres = @pAdres  where KisiID = @pkid "; 
            
            SqlCommand cmd = new SqlCommand(sql,con);
            
            cmd.Parameters.AddWithValue("@pAd", ad);
            cmd.Parameters.AddWithValue("@psoadi", soad);
            cmd.Parameters.AddWithValue("@pTelefon", tel);
            cmd.Parameters.AddWithValue("@pAdres", adres);
            cmd.Parameters.AddWithValue("@pkid ", KkisiID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public static void delete(int KkisiID)
        {

            string sql = "delete from Kisiler where KisiID=" + KkisiID;

            SqlCommand cmd = new SqlCommand(sql,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
        



    }
}
