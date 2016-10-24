using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Statki.Helper;
using Console_Statki.Model;
using System.Windows;
using Console_Statki;


namespace Console_Statki.Helper
{
    class Methods
    {
        public static void ShowStartScreen()
        {
            try
            {
                Console.WriteLine(Messages.UPPER_LOWER_FRAME);
                #region MID_FRAME
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                #endregion
                Console.WriteLine(Messages.WELCOME_TEXT);
                #region MID_FRAME
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                Console.WriteLine(Messages.MID_FRAME);
                #endregion
                Console.WriteLine(Messages.UPPER_LOWER_FRAME);
                SetCursor(28, 14);

            }
            catch
            {
                Console.WriteLine(Messages.START_ALERT);
            }
        }

        public static void EnterNicknameP1()
        {
            Methods.SetCursor(0, 4);
            Console.WriteLine(Messages.WELCOME_TEXT);
            Methods.SetCursor(33, 6);
            Variable.PLAYER1_NICKNAME = Console.ReadLine();
            Console.Clear();
        }

        public static void EnterNicknameP2()
        {
            Methods.SetCursor(0, 4);
            Console.WriteLine(Messages.WELCOME_TEXT1);
            Methods.SetCursor(33, 6);
            Variable.PLAYER1_NICKNAME = Console.ReadLine();
            Console.Clear();
            Methods.SetCursor(0, 4);
            Console.WriteLine(Messages.WELCOME_TEXT2);
            Methods.SetCursor(33, 6);
            Console.ReadLine();
            Variable.PLAYER2_NICKNAME = Console.ReadLine();
         //   string k = Console.ReadLine();
          //  Variable.PLAYER2_NICKNAME = k;

            Console.Clear();
        }

        public static void SetCursor(int x, int y)
        {
            try
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
            }
            catch
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.WriteLine(Messages.CURSOR_ALERT);
            }
        }

        public static void ColorText(string text)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void ShowMenuScreen(int x, int y, string textToColor)
        {
            try
            {

                Methods.SetCursor(19, 3);
                Console.Write(Messages.SHIP);
                //Console.WriteLine(Messages.UPPER_LOWER_FRAME);
                //#region MID_FRAME
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //#endregion
                Console.WriteLine(Messages.MENU_TEXT);
                Console.Write("\n");

                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                Console.Write(Messages.MENU_FIRST_PART);
                Console.Write(Messages.MENU_NEW_GAME);
                Console.WriteLine(Messages.MENU_SECOND_PART);

                //Console.WriteLine(Messages.MID_FRAME);
                Console.Write(Messages.MENU_FIRST_PART);
                Console.Write(Messages.MENU_NEW_GAME_2_PLAYERS);
                Console.WriteLine(Messages.MENU_SECOND_PART);

                //Console.WriteLine(Messages.MID_FRAME);
                Console.Write(Messages.MENU_FIRST_PART);
                Console.Write(Messages.MENU_HIGHSCORES);
                Console.WriteLine(Messages.MENU_SECOND_PART);

                //Console.WriteLine(Messages.MID_FRAME);
                Console.Write(Messages.MENU_FIRST_PART);
                Console.Write(Messages.MENU_CLOSE);
                Console.WriteLine(Messages.MENU_SECOND_PART);

                //#region MID_FRAME

                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //Console.WriteLine(Messages.MID_FRAME);
                //#endregion
                //Console.WriteLine(Messages.UPPER_LOWER_FRAME);
                SetCursor(x, y);
                ColorText(textToColor);

            }
            catch
            {
                Console.WriteLine(Messages.MENU_ALERT);
            }
        }

        public static void SelectOption(string selected)
        {
            int y = Console.CursorTop;
            Console.TreatControlCAsInput = true;

            if (selected == "UpArrow")
            {
                if (y > 12)
                {
                    if (y == 15)
                    {
                        ShowMenuScreen(25, y - 1, Messages.MENU_HIGHSCORES);
                    }
                    else
                        if (y == 14)
                        {

                            ShowMenuScreen(25, y - 1, Messages.MENU_NEW_GAME_2_PLAYERS);

                        }
                        else
                        {

                            ShowMenuScreen(25, y - 1, Messages.MENU_NEW_GAME);
                        }
                }
            }
            if (selected == "DownArrow")
            {
                if (y < 15)
                {
                    if (y == 12)
                    {

                        ShowMenuScreen(25, y + 1, Messages.MENU_NEW_GAME_2_PLAYERS);
                    }
                    else
                        if (y == 13)
                        {

                            ShowMenuScreen(25, y + 1, Messages.MENU_HIGHSCORES);
                        }
                        else
                        {
                            ShowMenuScreen(25, y + 1, Messages.MENU_CLOSE);
                        }
                }
            }
            
        }

        public static void ColorPosition(int x, int y, PlayerMatrix pM)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            SetCursor(x, y);

            if (pM.playerMatrix[(x - Const.EM_X) / 2, y - Const.EM_Y] == 999)
            {
                Console.Write("&");
            }
            else
                if (pM.playerMatrix[(x - Const.EM_X) / 2, y - Const.EM_Y] == 123)
                    Console.Write("*");
                else
                    if (pM.playerMatrix[(x - Const.EM_X) / 2, y - Const.EM_Y] == 321)
                        Console.Write("$");
                    else
                        Console.Write("~");
            Console.ResetColor();
            Console.Write(" ");
        }

        public static void ColorPosition2(int x, int y, PlayerMatrix pM)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            SetCursor(x, y);

            if (pM.playerMatrix[(x - Const.EM_X - 31) / 2, y - Const.EM_Y] == 999)
            {
                Console.Write("&");
            }
            else
                if (pM.playerMatrix[(x - Const.EM_X - 31) / 2, y - Const.EM_Y] == 123)
                    Console.Write("*");
                else
                    if (pM.playerMatrix[(x - Const.EM_X - 31) / 2, y - Const.EM_Y] == 321)
                        Console.Write("$");
                    else
                        Console.Write("~");
            Console.ResetColor();
            Console.Write(" ");
        }

        public static void ColorWrongPlace(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            SetCursor(x, y);
            Console.Write("#");
            Console.ResetColor();
            Console.Write(" ");
        }

        public static void GameScreen(int x, int y, PlayerMatrix pM)
        {
            //DA FAK
            try
            {


                SetCursor(Const.NICKNAME1_X + (20 - Variable.PLAYER1_NICKNAME.Length) / 2, Const.NICKNAME1_Y);
                Console.WriteLine(Variable.PLAYER1_NICKNAME);
                SetCursor(Const.VS_X, Const.VS_Y);
                Console.WriteLine("vs");





                SetCursor(Const.EM_X , Const.EM_Y);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (pM.playerMatrix[i, j] == 999)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("& ");
                            Console.ResetColor();

                        }
                        else
                            if (pM.playerMatrix[i, j] == 123)
                                Console.Write("* ");
                            else
                                if (pM.playerMatrix[i, j] == 321)
                                {
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write("$ ");
                                    Console.ResetColor();
                                }
                                else
                                    Console.Write("~ ");
                    }
                    SetCursor(Const.EM_X, Const.EM_Y + i + 1);
                }

                SetCursor(Const.EM_X, Const.EM_Y);
                if (x != 0 && y != 0)
                {
                    ColorPosition(x, y, pM);
                }

                SetCursor(Const.MENU_CONTROL_X + 1, Const.MENU_CONTROL_Y);
                Console.WriteLine(Messages.CONTROL);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 1);
                Console.WriteLine(Messages.CONTROLS_GAME_UP);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 2);
                Console.WriteLine(Messages.CONTROLS_GAME_DOWN);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 3);
                Console.WriteLine(Messages.CONTROLS_GAME_LEFT);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 4);
                Console.WriteLine(Messages.CONTROLS_GAME_RIGHT);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 5);
                Console.WriteLine(Messages.CONTROLS_GAME_ENTER);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 6);
                Console.WriteLine(Messages.CONTROLS_GAME_TILDE);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 7);
                Console.WriteLine(Messages.CONTROLS_GAME_STAR);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 8);
                Console.WriteLine(Messages.CONTROLS_GAME_DOLAR);

                SetCursor(Const.MENU_CONTROL_X - 2, Const.MENU_CONTROL_Y + 9);
                Console.WriteLine(Messages.CONTROLS_GAME_ET);






                //SetCursor(0, 50);
                //for(int i=0 ;i<10;i++)  //pokazuje jak jest zapisana macierz w pamięci i jest chujowo po 1 strzale
                //{
                //    for(int j=0;j<10;j++)
                //    {
                //        Console.Write(pM.playerMatrix[i, j]);
                //    }
                //    Console.Write("\n");
                //}
            }
            catch
            {
                Console.WriteLine(Messages.GAME_SCREEN_ALERT);
            }
        }

        public static void GameScreen2(int x, int y, PlayerMatrix pM, string nickname)
        {
            //DA FAK
            try
            {

                int vector = 31;
                SetCursor(Const.NICKNAME1_X + vector + (20 - nickname.Length) / 2, Const.NICKNAME1_Y);
                Console.WriteLine(nickname);






                SetCursor(Const.EM_X + vector, Const.EM_Y);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (pM.playerMatrix[i, j] == 999)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("& ");
                            Console.ResetColor();

                        }
                        else
                            if (pM.playerMatrix[i, j] == 123)
                                Console.Write("* ");
                            else
                                if (pM.playerMatrix[i, j] == 321)
                                {
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write("$ ");
                                    Console.ResetColor();
                                }
                                else
                                    Console.Write("~ ");
                    }
                    SetCursor(Const.EM_X + vector, Const.EM_Y + i + 1);
                }
                SetCursor(Const.EM_X + vector, Const.EM_Y);
                if (x != 0 && y != 0)
                {
                    ColorPosition2(x, y, pM);
                }






                //SetCursor(0, 50);
                //for(int i=0 ;i<10;i++)  //pokazuje jak jest zapisana macierz w pamięci i jest chujowo po 1 strzale
                //{
                //    for(int j=0;j<10;j++)
                //    {
                //        Console.Write(pM.playerMatrix[i, j]);
                //    }
                //    Console.Write("\n");
                //}
            }
            catch
            {
                Console.WriteLine(Messages.GAME_SCREEN_ALERT);
            }
        }

        public static PlayerMatrix PlaceBomb(PlayerMatrix pM)
        {
            int x = Const.EM_X;
            int trueX = Const.EM_X;
            int y = Const.EM_Y;
            ColorPosition(x, y, pM);
            GameScreen(x, y, pM);
            Methods.SetCursor(26, Const.MENU_CONTROL_Y + 15);
            Console.Write("                                                                                           ");
            Console.TreatControlCAsInput = true;

            while (true)
            {

                string selected = Console.ReadKey().Key.ToString();
                if (selected == "Enter")
                {
                    if (pM.playerMatrix[y - Const.EM_Y, trueX - Const.EM_X] == 123 || pM.playerMatrix[y - Const.EM_Y, trueX - Const.EM_X] == 321 || pM.playerMatrix[y - Const.EM_Y, trueX - Const.EM_X] == 999)
                    {
                        Methods.SetCursor(26, Const.MENU_CONTROL_Y + 15);
                        Console.Write(Messages.SET_BOMB_ALERT);

                    }
                    else
                    {
                        pM = Game.Shoot(pM, y - Const.EM_Y, /*(x - 23) / 2*/trueX - Const.EM_X);
                        GameScreen(x, y, pM);
                        break;
                    }
                }

                if (selected == "UpArrow")
                {
                    if (y > 5)
                    {
                        y = y - 1;
                        GameScreen(x, y, pM);
                    }
                    else
                    {
                        GameScreen(x, y, pM);
                    }
                }
                if (selected == "DownArrow")
                {

                    if (y < 14)
                    {
                        y = y + 1;
                        GameScreen(x, y, pM);
                    }
                    else
                    {
                        GameScreen(x, y, pM);
                    }
                }
                if (selected == "RightArrow")
                {

                    if (x < 35)
                    {
                        x = x + 2;
                        trueX++;
                        GameScreen(x, y, pM);
                    }
                    else
                    {
                        GameScreen(x, y, pM);
                    }
                }
                if (selected == "LeftArrow")
                {

                    if (x > 18)
                    {
                        trueX--;
                        x = x - 2;
                        GameScreen(x, y, pM);
                    }
                    else
                    {
                        GameScreen(x, y, pM);
                    }
                }
            }
            return pM;
        }

        public static PlayerMatrix PlaceBomb2(PlayerMatrix pM)
        {
            int vector = 31;
            int x = Const.EM_X + vector;
            int trueX = Const.EM_X;
            int y = Const.EM_Y;
            ColorPosition2(x, y, pM);
            GameScreen2(0, 0, pM, Variable.PLAYER2_NICKNAME);
            Methods.SetCursor(26, Const.MENU_CONTROL_Y + 15);
            Console.Write("                                                                                           ");
            Console.TreatControlCAsInput = true;

            while (true)
            {

                string selected = Console.ReadKey().Key.ToString();
                if (selected == "Enter")
                {
                    if (pM.playerMatrix[y - Const.EM_Y, trueX - Const.EM_X] == 123 || pM.playerMatrix[y - Const.EM_Y, trueX - Const.EM_X] == 321 || pM.playerMatrix[y - Const.EM_Y, trueX - Const.EM_X] == 999)
                    {
                        Methods.SetCursor(26, Const.MENU_CONTROL_Y + 15);
                        Console.Write(Messages.SET_BOMB_ALERT);

                    }
                    else
                    {
                        pM = Game.Shoot(pM, y - Const.EM_Y, /*(x - 23) / 2*/trueX - Const.EM_X);
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                        break;
                    }
                }

                if (selected == "UpArrow")
                {
                    if (y > 5)
                    {
                        y = y - 1;
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                    }
                    else
                    {
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                    }
                }
                if (selected == "DownArrow")
                {

                    if (y < 14)
                    {
                        y = y + 1;
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                    }
                    else
                    {
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                    }
                }
                if (selected == "RightArrow")
                {

                    if (x < 35 + vector )
                    {
                        x = x + 2;
                        trueX++;
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                    }
                    else
                    {
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                    }
                }
                if (selected == "LeftArrow")
                {

                    if (x > 18 + vector)
                    {
                        trueX--;
                        x = x - 2;
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                    }
                    else
                    {
                        GameScreen2(x, y, pM, Variable.PLAYER2_NICKNAME);
                    }
                }
            }
            return pM;
        }

        public static void CreateScreen(PlayerMatrix pM,bool player)
        {
            try
            {
                Console.Clear();
                SetCursor(Const.MENU_NICKNAME_X, Const.MENU_NICKNAME_Y);
                if (player)
                {
                    Console.WriteLine(Variable.PLAYER1_NICKNAME);
                }
                else 
                {
                    Console.WriteLine(Variable.PLAYER2_NICKNAME);
                }
                SetCursor(Const.MENU_SET_X, Const.MENU_SET_Y);
                Console.WriteLine(Messages.SET_SHIP_MESSAGE);
                #region MATRIX
                SetCursor(Const.MATRIX_X, Const.MATRIX_Y);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (pM.playerMatrix[i, j] == 1 || pM.playerMatrix[i, j] == 3 || pM.playerMatrix[i, j] == 5 || pM.playerMatrix[i, j] == 7)
                        {
                            Console.Write("# ");
                        }
                        else
                            if (pM.playerMatrix[i, j] == 10 || pM.playerMatrix[i, j] == 12 || pM.playerMatrix[i, j] == 14 || pM.playerMatrix[i, j] == 16 || pM.playerMatrix[i, j] == 4 || pM.playerMatrix[i, j] == 8 || pM.playerMatrix[i, j] == 10 || pM.playerMatrix[i, j] == 12 || pM.playerMatrix[i, j] == 6)
                            {
                                ColorWrongPlace(Console.CursorLeft, Console.CursorTop);
                            }
                            else
                                if (pM.playerMatrix[i, j] == 9 || pM.playerMatrix[i, j] == 18)
                                {
                                    Console.Write("X ");
                                }
                                else
                                {
                                    Console.Write("~ ");
                                }
                    }
                    SetCursor(Const.MATRIX_X, Const.MATRIX_Y + i + 1);
                }
                #endregion
                SetCursor(Const.LOST_SHIP_X, Const.LOST_SHIP_Y1);
                Console.WriteLine(Variable.CZTEROMASZTOWCE + " - ####");
                SetCursor(Const.LOST_SHIP_X, Const.LOST_SHIP_Y2);
                Console.WriteLine(Variable.TRZYMASZTOWCE + " - ###");
                SetCursor(Const.LOST_SHIP_X, Const.LOST_SHIP_Y3);
                Console.WriteLine(Variable.DWUMASZTOWCE + " - ##");
                SetCursor(Const.LOST_SHIP_X, Const.LOST_SHIP_Y4);
                Console.WriteLine(Variable.JEDNOMASZTOWIEC + " - #");

                SetCursor(Const.MENU_CONTROL_X, Const.MENU_CONTROL_Y);
                Console.WriteLine(Messages.CONTROL);
                SetCursor(Const.MENU_CONTROL_X - 10, Const.MENU_CONTROL_Y + 1);
                Console.WriteLine(Messages.CONTROLS_PLACE_SHIP_UP);
                SetCursor(Const.MENU_CONTROL_X - 10, Const.MENU_CONTROL_Y + 2);
                Console.WriteLine(Messages.CONTROLS_PLACE_SHIP_DOWN);
                SetCursor(Const.MENU_CONTROL_X - 10, Const.MENU_CONTROL_Y + 3);
                Console.WriteLine(Messages.CONTROLS_PLACE_SHIP_LEFT);
                SetCursor(Const.MENU_CONTROL_X - 10, Const.MENU_CONTROL_Y + 4);
                Console.WriteLine(Messages.CONTROLS_PLACE_SHIP_RIGHT);
                SetCursor(Const.MENU_CONTROL_X - 10, Const.MENU_CONTROL_Y + 5);
                Console.WriteLine(Messages.CONTROLS_PLACE_SHIP_F1);
                SetCursor(Const.MENU_CONTROL_X - 10, Const.MENU_CONTROL_Y + 6);
                Console.WriteLine(Messages.CONTROLS_PLACE_SHIP_ENTER);
                SetCursor(Const.MATRIX_X, Const.MATRIX_Y);
            }
            catch
            {
                Console.WriteLine(Messages.CREATE_SCREEN_ALERT);
            }
        }

    }


}

