using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Console_Statki.Helper;
using System.Threading;
using System.Data.SqlClient;


namespace Console_Statki.Model
{
    class Game
    {
        public class Ship
        {
            public int x { get; set; }
            public int y { get; set; }
            public bool rotate { get; set; }
            public int size { get; set; }
            

            public Ship(int size)
            {
                rotate = false;
                x = 0;
                y = 0;
                this.size = size;
            }
        }
        public static bool defeat = false;
        public static int defeatx = 0;
        public static int defeaty = 0;
        public static int defeatr = 1;
        public static int defeatlenght = 0;
        public static bool hit = false;
        public static Coordinate coordinate;
        public static bool turn = false;
        public static Coordinate playerHit;
        public static bool game = true;
        public static int g1 = 0;//gracz 1 
        public static int g2 = 0;//gracz 2 lub komputer
        public static int state = 10;//stała premia
        public static int combo = 1;

        public static void StartNewGame()
        {
            PlayerMatrix pM = new PlayerMatrix();
            PlayerMatrix eM = new PlayerMatrix();
            EnenemyPlans eP = new EnenemyPlans();

            Methods.EnterNicknameP1();

           
            PlaceShips(pM, true);
            EnemyPlaceShips(eM);
            Methods.CreateScreen(eM,true);

            Console.Clear();
            Methods.GameScreen2(0, 0, pM, Const.COMPUTER_NICKNAME);
            //W GAME SCREEN ZROBIC 2 OBRAZY
            while (game)
            {
                Methods.GameScreen2(0, 0, pM, Const.COMPUTER_NICKNAME);
                if (turn == false)
                {
                    eM = Methods.PlaceBomb(eM);
           
                    Methods.GameScreen(0, 0, eM);

                    if (eM.playerMatrix[playerHit.X, playerHit.Y] == 999 || eM.playerMatrix[playerHit.X, playerHit.Y] == 321) //to nie działa
                    {
                        turn = false;
                        g1 += state * combo;
                        combo++;
                    }
                    else
                    {
                        turn = true;
                        combo = 1;
                    }
                }

                else
                {
                    coordinate = eP.Shoot(hit, pM);
                    pM = ShootEnemy(pM, coordinate.X, coordinate.Y);
           
                    Methods.GameScreen2(0, 0, pM, Const.COMPUTER_NICKNAME);
  
                    if (pM.playerMatrix[coordinate.X, coordinate.Y] == 999 || pM.playerMatrix[coordinate.X, coordinate.Y] == 321)
                    {
                        turn = true;
                        g2 += state * combo;
                        combo++;
                    }
                    else
                    {
                        turn = false;
                        combo = 1;
                    }
                }

                if (defeat == true)
                {
                    eP.IsDefeat(defeat, pM, defeatlenght, defeaty, defeatx, defeatr);
                    defeat = false;


                }
                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (pM.playerMatrix[i, j] == 999)
                        {
                            count++;
                        }
                    }
                }
                if (count == 20)
                {
                    game = false;
                    Methods.SetCursor(35, 16);
                    Methods.ColorText(String.Format("Wygrał: {0}",Const.COMPUTER_NICKNAME));
                    DAL.HighscoreModel.InsertInto(Const.COMPUTER_NICKNAME, g2);

                }
                else
                {
                    count = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (eM.playerMatrix[i, j] == 999)
                            {
                                count++;
                            }
                        }
                    }
                    if (count == 20)
                    {
                        game = false;
                        Methods.SetCursor(35, 16);
                        Methods.ColorText(String.Format("Wygrał: {0}", Variable.PLAYER1_NICKNAME));
                        DAL.HighscoreModel.InsertInto(Variable.PLAYER1_NICKNAME, g1);
                        Console.Read();
               //MATKO JAKI PRL
                    }

                 

                }


            }
        }

        public static void StartNewGame2Players()
        {
            PlayerMatrix pM = new PlayerMatrix();
            PlayerMatrix eM = new PlayerMatrix();
            EnenemyPlans eP = new EnenemyPlans();

            //NIE MAM POJECIA DLACZEGO DOUBLE ENTER
            Methods.EnterNicknameP2();





            PlaceShips(pM, true);
            PlaceShips(eM, false);
            //EnemyPlaceShips(eM);
            //EnemyPlaceShips(pM);

            Console.Clear();
            Methods.GameScreen2(0, 0, pM, Variable.PLAYER2_NICKNAME);
            while (game)
            {
                if (turn == false)
                {
                    eM = Methods.PlaceBomb(eM);
                    Methods.GameScreen(0, 0, eM);

                    if (eM.playerMatrix[playerHit.X, playerHit.Y] == 999 || eM.playerMatrix[playerHit.X, playerHit.Y] == 321) //to nie działa
                    {
                        turn = false;
                        g1 += state * combo;
                        combo++;
                    }
                    else
                    {
                        turn = true;
                        combo = 1;
                    }
                }

                else
                {
                    pM = Methods.PlaceBomb2(pM);
                    Methods.GameScreen2(0, 0, pM, Variable.PLAYER2_NICKNAME);


                    if (pM.playerMatrix[playerHit.X, playerHit.Y] == 999 || pM.playerMatrix[playerHit.X, playerHit.Y] == 321)
                    {
                        turn = true;
                        g2 += state * combo;
                        combo++;

                    }
                    else
                    {
                        turn = false;
                        combo = 1;
                    }
                }


                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (pM.playerMatrix[i, j] == 999)
                        {
                            count++;
                        }
                    }
                }
                if (count == 20)
                {
                    game = false;
                    Methods.SetCursor(35, 16);
                    Methods.ColorText(String.Format("Wygrał: {0}", Variable.PLAYER2_NICKNAME));
                    DAL.HighscoreModel.InsertInto(Variable.PLAYER2_NICKNAME, g2);
                    Console.Read();
                }
                else
                {
                    count = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (eM.playerMatrix[i, j] == 999)
                            {
                                count++;
                            }
                        }
                    }
                    if (count == 20)
                    {
                        game = false;
                        Methods.SetCursor(35, 16);
                        Methods.ColorText(String.Format("Wygrał: {0}", Variable.PLAYER1_NICKNAME));
                        DAL.HighscoreModel.InsertInto(Variable.PLAYER1_NICKNAME, g1);
                        Console.Read();
                        //MATKO JAKI PRL
                    }



                }


            }
        }

        public static PlayerMatrix PlaceShips(PlayerMatrix pM, bool player)
        {
            Variable.CZTEROMASZTOWCE = 1;
            Variable.TRZYMASZTOWCE = 2;
            Variable.DWUMASZTOWCE = 3;
            Variable.JEDNOMASZTOWIEC = 4;
            for (int i = 1; i <= 1; i++)
            {
                pM = Methods.PlaceShip(4, pM,player);
                Variable.CZTEROMASZTOWCE = 1 - i;
            }
            for (int i = 1; i <= 2; i++)
            {
                pM = Methods.PlaceShip(3, pM, player);
                Variable.TRZYMASZTOWCE = 2 - i;
            }
            for (int i = 1; i <= 3; i++)
            {
                pM = Methods.PlaceShip(2, pM, player);
                Variable.DWUMASZTOWCE = 3 - i;
            }
            for (int i = 1; i <= 4; i++)
            {
                pM = Methods.PlaceShip(1, pM, player);
                Variable.JEDNOMASZTOWIEC = 4 - i;
            }

            return pM;
        }

        public static PlayerMatrix EnemyPlaceShips(PlayerMatrix pM)
        {
            pM = EnemyPlaceShip(4, pM);
            for (int i = 0; i < 2; i++) pM = EnemyPlaceShip(3, pM);
            for (int i = 0; i < 3; i++) pM = EnemyPlaceShip(2, pM);
            for (int i = 0; i < 4; i++) pM = EnemyPlaceShip(1, pM);

            return pM;
        }

        public static Ship Randomize(int size)
        {
            Ship s = new Ship(size);
            Random rnd = new Random();
            s.size = size;
            if (rnd.Next(0, 12578) % 2 == 0)
            {
                s.rotate = false;
                s.x = rnd.Next(0, 9 - s.size + 1);
                s.y = rnd.Next(0, 9);
            }
            else
            {
                s.rotate = true;
                s.x = rnd.Next(0, 9);
                s.y = rnd.Next(0, 9 - s.size + 1);
            }
            return s;
        }

        public static PlayerMatrix EnemyPlaceShip(int size, PlayerMatrix pM)
        {
            Ship s = new Ship(size);
            SetShip(pM, s);
            do
            {
                ClearShip(pM, s);
                s = Randomize(size);
                SetShip(pM, s);
                if (CheckAllPosition(pM))
                {
                    pM = SuroundShip(pM, s);
                    break;
                }
            } while (true);
            return pM;
        }

        //public static PlayerMatrix PlaceShip(int size, PlayerMatrix pM, bool player) //prawdopodobnie czesc interfejsu
        //{
        //    Ship s = new Ship(size);
        //    int x = 23;
        //    int y = 3;

        //    pM = SetShip(pM, s);
           
        //    Methods.CreateScreen(pM,player);

        //    Methods.SetCursor(23, 3);
        //    while (true)
        //    {
        //        string selected = Console.ReadKey().Key.ToString();
        //        if (selected == "Enter")
        //        {
        //            if (!CheckAllPosition(pM))
        //            {
        //                Methods.SetCursor(15, Const.MENU_CONTROL_Y+10);
        //                Console.WriteLine(Messages.SET_ALERT);
        //                Methods.SetCursor(23, Const.MENU_CONTROL_Y + 11);
        //                Console.WriteLine(Messages.SET_ALERT2);
        //            }
        //            else
        //            {
        //                pM = SuroundShip(pM, s);
        //                Methods.CreateScreen(pM,player);
        //                break;
        //            }
        //        }
        //        if (selected == "F1")
        //        {
        //            if ((s.rotate == false && y + s.size - 1 < 13) || (s.rotate == true && x + s.size * 2 - 1 < 43))
        //            {
        //                ClearShip(pM, s);
        //                s.rotate = !s.rotate;
        //                SetShip(pM, s);
        //                Methods.CreateScreen(pM, player);
        //            }
        //            else
        //                Methods.CreateScreen(pM,player);
        //        }
        //        if (selected == "UpArrow")
        //        {
        //            if (y > 3)
        //            {
        //                ClearShip(pM, s);
        //                y--;
        //                s.y--;
        //                SetShip(pM, s);
        //                Methods.CreateScreen(pM, player);
        //            }
        //            else
        //            {
        //                Methods.CreateScreen(pM, player);
        //            }
        //        }
        //        if (selected == "DownArrow")
        //        {

        //            if ((y < 12 && s.rotate == false) || (s.rotate == true && y + s.size - 1 < 12))
        //            {
        //                ClearShip(pM, s);
        //                y++;
        //                s.y++;
        //                SetShip(pM, s);
        //                Methods.CreateScreen(pM, player);
        //            }
        //            else
        //            {
        //                Methods.CreateScreen(pM, player);
        //            }
        //        }
        //        if (selected == "RightArrow")
        //        {

        //            if ((x < 41 && s.rotate == true) || (s.rotate == false && x + s.size * 2 - 1 < 41))
        //            {
        //                ClearShip(pM, s);
        //                x += 2;
        //                s.x++;
        //                SetShip(pM, s);
        //                Methods.CreateScreen(pM, player);
        //            }
        //            else
        //            {
        //                Methods.CreateScreen(pM, player);
        //            }
        //        }
        //        if (selected == "LeftArrow")
        //        {

        //            if (x > 23)
        //            {
        //                ClearShip(pM, s);
        //                x -= 2;
        //                s.x--;
        //                SetShip(pM, s);
        //                Methods.CreateScreen(pM, player);
        //            }
        //            else
        //            {
        //                Methods.CreateScreen(pM, player);
        //            }
        //        }
        //    }


        //    return pM;
        //}

        public static PlayerMatrix SetShip(PlayerMatrix pM, Ship s)
        {
            if (s.rotate)
                for (int i = s.y; i < s.y + s.size; i++)
                    pM.playerMatrix[i, s.x] += (s.size * 2) - 1;
            else
                for (int j = s.x; j < s.x + s.size; j++)
                    pM.playerMatrix[s.y, j] += (s.size * 2) - 1;
            return pM;
        }

        public static PlayerMatrix ClearShip(PlayerMatrix pM, Ship s)
        {
            if (s.rotate)
                for (int i = s.y; i < s.y + s.size; i++)
                    pM.playerMatrix[i, s.x] -= (s.size * 2) - 1;
            else
                for (int j = s.x; j < s.x + s.size; j++)
                    pM.playerMatrix[s.y, j] -= (s.size * 2) - 1;
            return pM;
        }

        public static bool CheckAllPosition(PlayerMatrix pM)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        if ((pM.playerMatrix[i, j] != 0) && (pM.playerMatrix[i, j] != 1) && (pM.playerMatrix[i, j] != 3) && (pM.playerMatrix[i, j] != 5) && (pM.playerMatrix[i, j] != 7) && (pM.playerMatrix[i, j] != 9))
                            return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static PlayerMatrix SuroundShip(PlayerMatrix pM, Ship s)
        {
            if (s.rotate)
            {
                for (int i = s.x - 1; i <= s.x + 1; i++)
                    for (int j = s.y - 1; j <= s.y + s.size; j++)
                    {
                        if (i < 10 && j < 10 && i >= 0 && j >= 0)
                            if (pM.playerMatrix[j, i] == 0)
                                pM.playerMatrix[j, i] = 9;
                    }
            }
            else
            {
                for (int i = s.x - 1; i <= s.x + s.size; i++)
                    for (int j = s.y - 1; j <= s.y + 1; j++)
                    {
                        if (i < 10 && j < 10 && i >= 0 && j >= 0)
                            if (pM.playerMatrix[j, i] == 0)
                                pM.playerMatrix[j, i] = 9;
                    }
            }
            return pM;
        }

        public static PlayerMatrix Shoot(PlayerMatrix pM, int x, int y)
        {
            int tx = x;
            int ty = y;
            if (pM.playerMatrix[x, y] == 1 || pM.playerMatrix[x, y] == 3 || pM.playerMatrix[x, y] == 5 || pM.playerMatrix[x, y] == 7)
            {
                if (pM.playerMatrix[x, y] == 1)
                {
                    pM.playerMatrix[x, y] = 999; // zatopiony

                    int truey = y;
                    int truex = x;
                    int rotate = 2; // pozioma
                    int lenght = 0;


                    y--; //zatapiamy pozostałe maszty
                    if (y >= 0)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            rotate = 2;//poziom
                            pM.playerMatrix[x, y] = 999;
                            y--;
                            if (y < 0)
                                break;
                        }
                    y = truey + 1;
                    if (y <= 9)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            rotate = 2;//poziom
                            pM.playerMatrix[x, y] = 999;
                            y++;
                            if (y > 9)
                                break;
                        }
                    x--;
                    y = truey;
                    if (x >= 0)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            rotate = 1;//pionowa
                            pM.playerMatrix[x, y] = 999;
                            x--;
                            if (x < 0)
                                break;
                        }
                    x = truex + 1;
                    if (x <= 9)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            rotate = 1;//pionowa
                            pM.playerMatrix[x, y] = 999;
                            x++;
                            if (x > 9)
                                break;
                        }

                    x = truex;
                    y = truey;
                    if (rotate == 1) //pionowa
                    {

                        while (x > 0 && pM.playerMatrix[x, y] == 999)
                        {
                            if (pM.playerMatrix[x - 1, y] == 999)
                            {
                                truex = x - 1;
                            }
                            x--;

                        }
                        x = truex;
                        while (x < 9 && pM.playerMatrix[x, y] == 999)
                        {
                            x++;
                            lenght++;
                        }
                    }
                    else //poziom
                    {
                        while (y > 0 && pM.playerMatrix[x, y] == 999)
                        {
                            if (pM.playerMatrix[x, y - 1] == 999)
                            {
                                truey = y - 1;
                            }
                            y--;

                        }
                        y = truey;
                        while (y < 9 && pM.playerMatrix[x, y] == 999)
                        {
                            y++;
                            lenght++;
                        }
                    }

                    if (rotate == 1)
                    {
                        for (int i = truey - 1; i <= truey + 1; i++)
                            for (int j = truex - 1; j <= truex + lenght; j++)
                            {
                                if (i < 10 && j < 10 && i >= 0 && j >= 0)
                                    if (pM.playerMatrix[j, i] != 999) // JA JEBIE XD
                                        pM.playerMatrix[j, i] = 123;
                            }
                    }
                    else
                    {
                        for (int i = truex - 1; i <= truex + 1; i++)
                            for (int j = truey - 1; j <= truey + lenght; j++)
                            {
                                if (i < 10 && j < 10 && i >= 0 && j >= 0)
                                    if (pM.playerMatrix[i, j] != 999)
                                        pM.playerMatrix[i, j] = 123;
                            }
                    }


                }
                else
                {
                    pM.playerMatrix[x, y] = 321; //trafiony

                    int truey = y;
                    int truex = x;

                    y--;
                    if (y >= 0)   //odejmujemy stałą 2 od pozostałych masztów
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            if (pM.playerMatrix[x, y] != 321)
                                pM.playerMatrix[x, y] -= 2;
                            y--;
                            if (y < 0)
                                break;
                        }
                    y = truey + 1;
                    if (y <= 9)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            if (pM.playerMatrix[x, y] != 321)
                                pM.playerMatrix[x, y] -= 2;
                            y++;
                            if (y > 9)
                                break;
                        }
                    x--;
                    y = truey;
                    if (x >= 0)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            if (pM.playerMatrix[x, y] != 321)
                                pM.playerMatrix[x, y] -= 2;
                            x--;
                            if (x < 0)
                                break;
                        }
                    x = truex + 1;
                    if (x <= 9)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            if (pM.playerMatrix[x, y] != 321)
                                pM.playerMatrix[x, y] -= 2;
                            x++;
                            if (x > 9)
                                break;
                        }


                }

            }
            else
                if (pM.playerMatrix[x, y] != 321 && pM.playerMatrix[x, y] != 999)
                {

                    pM.playerMatrix[x, y] = 123;
                }
            playerHit = new Coordinate(tx * 10 + ty);
            return pM;
        }

        public static PlayerMatrix ShootEnemy(PlayerMatrix pM, int x, int y)
        {
            if (pM.playerMatrix[x, y] == 1 || pM.playerMatrix[x, y] == 3 || pM.playerMatrix[x, y] == 5 || pM.playerMatrix[x, y] == 7)
            {
                if (pM.playerMatrix[x, y] == 1)
                {

                    pM.playerMatrix[x, y] = 999; // zatopiony
                    defeat = true;
                    hit = false;
                    int truey = y;
                    int truex = x;
                    int rotate = 2; // pozioma
                    int lenght = 0;


                    y--; //zatapiamy pozostałe maszty
                    if (y >= 0)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            rotate = 2;//poziom
                            pM.playerMatrix[x, y] = 999;
                            y--;
                            if (y < 0)
                                break;
                        }
                    y = truey + 1;
                    if (y <= 9)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            rotate = 2;//poziom
                            pM.playerMatrix[x, y] = 999;
                            y++;
                            if (y > 9)
                                break;
                        }
                    x--;
                    y = truey;
                    if (x >= 0)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            rotate = 1;//pionowa
                            pM.playerMatrix[x, y] = 999;
                            x--;
                            if (x < 0)
                                break;
                        }
                    x = truex + 1;
                    if (x <= 9)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            rotate = 1;//pionowa
                            pM.playerMatrix[x, y] = 999;
                            x++;
                            if (x > 9)
                                break;
                        }

                    x = truex;
                    y = truey;
                    if (rotate == 1) //pionowa
                    {

                        while (x > 0 && pM.playerMatrix[x, y] == 999)
                        {
                            if (pM.playerMatrix[x - 1, y] == 999)
                            {
                                truex = x - 1;
                            }
                            x--;

                        }
                        x = truex;
                        while (x < 9 && pM.playerMatrix[x, y] == 999)
                        {
                            x++;
                            lenght++;
                        }
                    }
                    else //poziom
                    {
                        while (y > 0 && pM.playerMatrix[x, y] == 999)
                        {
                            if (pM.playerMatrix[x, y - 1] == 999)
                            {
                                truey = y - 1;
                            }
                            y--;

                        }
                        y = truey;
                        while (y < 9 && pM.playerMatrix[x, y] == 999)
                        {
                            y++;
                            lenght++;
                        }
                    }
                    defeatr = rotate;
                    defeatx = truey;
                    defeaty = truex;
                    defeatlenght = lenght;
                    if (rotate == 1)
                    {
                        for (int i = truey - 1; i <= truey + 1; i++)
                            for (int j = truex - 1; j <= truex + lenght; j++)
                            {
                                if (i < 10 && j < 10 && i >= 0 && j >= 0)
                                    if (pM.playerMatrix[j, i] != 999)
                                        pM.playerMatrix[j, i] = 123;
                            }
                    }
                    else
                    {
                        for (int i = truex - 1; i <= truex + 1; i++)
                            for (int j = truey - 1; j <= truey + lenght; j++)
                            {
                                if (i < 10 && j < 10 && i >= 0 && j >= 0)
                                    if (pM.playerMatrix[i, j] != 999)
                                        pM.playerMatrix[i, j] = 123;
                            }
                    }


                }
                else
                {
                    pM.playerMatrix[x, y] = 321; //trafiony
                    hit = true;
                    int truey = y;
                    int truex = x;

                    y--;
                    if (y >= 0)   //odejmujemy stałą 2 od pozostałych masztów
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            if (pM.playerMatrix[x, y] != 321)
                                pM.playerMatrix[x, y] -= 2;
                            y--;
                            if (y < 0)
                                break;
                        }
                    y = truey + 1;
                    if (y <= 9)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            if (pM.playerMatrix[x, y] != 321)
                                pM.playerMatrix[x, y] -= 2;
                            y++;
                            if (y > 9)
                                break;
                        }
                    x--;
                    y = truey;
                    if (x >= 0)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            if (pM.playerMatrix[x, y] != 321)
                                pM.playerMatrix[x, y] -= 2;
                            x--;
                            if (x < 0)
                                break;
                        }
                    x = truex + 1;
                    if (x <= 9)
                        while (pM.playerMatrix[x, y] != 9 && pM.playerMatrix[x, y] != 18 && pM.playerMatrix[x, y] != 123)
                        {
                            if (pM.playerMatrix[x, y] != 321)
                                pM.playerMatrix[x, y] -= 2;
                            x++;
                            if (x > 9)
                                break;
                        }


                }

            }
            else
                if (pM.playerMatrix[x, y] != 321 && pM.playerMatrix[x, y] != 999)
                {
                    hit = false;
                    pM.playerMatrix[x, y] = 123;
                }
            return pM;
        }

    }
}
