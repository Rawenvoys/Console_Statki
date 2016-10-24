using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Console_Statki.Model.DAL
{
    class HighscoreModel
    {
        public static SqlConnection Connection()
        {
            string str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Student\Source\Repos\Console_Statki\Console_Statki\Data\Highscore.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            return conn;
        }

        public static void InsertInto(string name, int score)
        {
            SqlConnection conn = Model.DAL.HighscoreModel.Connection();
            conn.Open();
            string s = "INSERT INTO Winners (Nickname,Score) VALUES ('" + name + "'," + score + ")";
            SqlCommand sC = new SqlCommand(s, conn);
            sC.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Highscore> SelectAll()
        {

            SqlConnection conn = Model.DAL.HighscoreModel.Connection();
            conn.Open();
            SqlCommand sC = new SqlCommand(Helper.Const.SELECT_ALL,conn);
            SqlDataReader sdr = sC.ExecuteReader();

            List<Highscore> highscore = new List<Highscore>();
            while(sdr.Read())
            {
                highscore.Add(new Highscore(sdr.GetValue(1).ToString(),(int)sdr.GetValue(2)));
            }
            conn.Close();
            return highscore;
        }
    }

}