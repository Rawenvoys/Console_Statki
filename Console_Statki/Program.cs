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
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Methods.SetCursor(19, 3);
            Console.Write(Messages.SHIP);
            Console.Read();
            Methods.ShowStartScreen();
            Const.PLAYER_NICKNAME = Console.ReadLine();
            (new SoundPlayer(@"d:\Music\imperial_march_long.wav")).Play();
            Console.Clear();
            Methods.ShowMenuScreen(28, 14, Messages.MENU_NEW_GAME);


            while (true)
            {
                string selected = Console.ReadKey().Key.ToString();
                if (selected == "Enter")
                {
                    int y = Console.CursorTop;
                    if (y == 14)
                    {
                        Console.Clear();
                        Game.StartNewGame();
                        Console.Read();
                        break;

                    }
                    else
                        if (y == 16)
                        {
                            Console.Clear();
                            Game.StartNewGame2Players();
                            Console.Read();
                            break;
                        }
                        else
                            if (y == 18)
                            {
                                Console.Clear();
                                Highscore.ShowHighscores();
                                Console.Read();
                                Console.Clear();
                                //Console.Write(Messages.GIRL_PART1);
                                //Console.Write(Messages.GIRL_PART2);
                                Console.Read();
                                break;
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                }
                Methods.SelectOption(selected);
            }
        }
    }
}
