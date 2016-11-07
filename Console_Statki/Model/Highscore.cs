using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Statki.Model
{
    public class Highscore
    {
        //public static void ShowHighscores()
        //{
        //    Console.WriteLine("Przepis na jajecznice:");
        //    Console.WriteLine("Składniki idealnej jajecznicy");
        //    Console.WriteLine("* dobre jajka");
        //    Console.WriteLine("* masło");
        //    Console.WriteLine("* śmietana");
        //    Console.WriteLine("* sól i pieprz do smaku");
        //}
        public string Nickname { get; set; }
        public int Score { get; set; }

        public Highscore(string nickname, int score)
        {
            Nickname = nickname;
            Score = score;
        }
        public override string ToString()
        {

            string ret= Nickname +" "+Score;
            return ret;
        }
    }
}
