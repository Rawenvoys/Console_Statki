using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Statki.Helper;
using Console_Statki.Model;
using System.Media;


namespace Console_Statki
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false; 

            //Main screen do przeniesienia
   //  string connectionString="Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\Cardsd.mdf";
        
            //new SoundPlayer(@"d:\Music\imperial_march_long.wav").Play();
            Methods.ShowMenuScreen(Const.MENU_X, Const.MENU_Y, Messages.MENU_NEW_GAME);
            while (true)
            {
                
                string selected = Console.ReadKey().Key.ToString();
                if (selected == "Enter")
                {
                    int y = Console.CursorTop;
                    if (y == 12)
                    {
                        Console.Clear();
                        Game.StartNewGame();
                        Console.Read();
                        Console.Clear();
                        Methods.ShowMenuScreen(Const.MENU_X, Const.MENU_Y, Messages.MENU_NEW_GAME);
                      

                    }
                    else
                        if (y == 13)
                        {
                            Console.Clear();
                            Game.StartNewGame2Players();
                            Console.Read();
                            Console.Clear();
                            Methods.ShowMenuScreen(Const.MENU_X, Const.MENU_Y, Messages.MENU_NEW_GAME);
                           
                        }
                        else
                            if (y == 14)
                            { //Szybko zrob to ;_;
                                Console.Clear();
                               // Highscore.ShowHighscores();
                                Console.Read();
                                Console.Clear();
                                Console.Write(Messages.GIRL_PART1);
                                Console.Write(Messages.GIRL_PART2);
                                Console.Read();
                                Console.Clear();
                                Methods.ShowMenuScreen(Const.MENU_X, Const.MENU_Y, Messages.MENU_NEW_GAME);
                                
                            }
                            else
                                if (y == 15)
                                {
                                    Environment.Exit(0);
                                }
                }
                Methods.SelectOption(selected);
            }
        }
    }
}
