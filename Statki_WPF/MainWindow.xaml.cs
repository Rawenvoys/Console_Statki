using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Console_Statki.Model;
using Statki_WPF.Helper;



namespace Statki_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        static ImageSource imgWater = new BitmapImage(new Uri("water.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgHit = new BitmapImage(new Uri("statekZatopiony.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgMiss = new BitmapImage(new Uri("miss.jpg", UriKind.RelativeOrAbsolute));
        static ImageSource imgPointer = new BitmapImage(new Uri("wodaCelownik.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgShip = new BitmapImage(new Uri("statekTrafiony.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgHighs = new BitmapImage(new Uri("highScores.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgPlaceShip = new BitmapImage(new Uri("statek.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgPointerMiss = new BitmapImage(new Uri("wodaCelownikpudlo.jpg", UriKind.RelativeOrAbsolute));
        static ImageSource imgPointerShip = new BitmapImage(new Uri("trafionyCelownik.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgPointerHit = new BitmapImage(new Uri("zatopionyCelownik.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgShipColide = new BitmapImage(new Uri("statekKolizja.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgLogo = new BitmapImage(new Uri("battleship.jpg", UriKind.RelativeOrAbsolute));
        public Image[,] gameBoard = new Image[10, 10];
        public Image[,] gameBoard1 = new Image[10, 10];
        public Image[,] gameBoard2 = new Image[10, 10];
        public Image hiSc;
        Game.Ship s;
        PlayerMatrix pM;
        PlayerMatrix eM = new PlayerMatrix();
        EnenemyPlans eP = new EnenemyPlans();
        int x = 0;
        int y = 0;
        int x1 = 0;
        int y1 = 0;
        bool rdy = false; //false 2 gracz sie jeszcze nie ustawil
        bool type = false; //false tryp dla 1 gracza
        public Image imgL = new Image
        {
            Source = imgLogo,
            Stretch = Stretch.Fill
        };
        // Game g = new Game();

        public MainWindow()
        {
            InitializeComponent();



            Grid.SetColumn(imgL, 1);
            Grid.SetColumnSpan(imgL, 5);
            Grid.SetRow(imgL, 0);
            GridStart.Children.Add(imgL);
                    
            
        }

        private void NewGame1P(object sender, RoutedEventArgs e)
        {
            new Game();
            type = false;
            rdy = false;
            gameBoard1 = new Image[10, 10];
            gameBoard2 = new Image[10, 10];
            // Console_Statki.Model.DAL.HighscoreModel.InsertInto(Console_Statki.Helper.Variable.PLAYER1_NICKNAME, Game.g1);
            //Variable2.CZTEROMASZTOWCE = 0;
            //Variable2.TRZYMASZTOWCE = 2;
            //Variable2.DWUMASZTOWCE = 3;
            //Variable2.JEDNOMASZTOWIEC = 4;
            new Variable2();
            Player1Nickname p = new Player1Nickname();
            p.ShowDialog();
            PlaceShip(4, pM = new PlayerMatrix(), false);


        }  //błąd z konsoli poprawiona logika (rozbita na 2 metody)

        private void NewGame2P(object sender, RoutedEventArgs e)
        {
            new Game();
            type = true;
            rdy = false;
            MainWindow1.Height = 600;
            MainWindow1.Width = 600;
            GridStart.Visibility = Visibility.Hidden;
            PlaceShipScreen.Visibility = Visibility.Visible;
            gameBoard1 = new Image[10, 10];
            gameBoard2 = new Image[10, 10];
            //Variable2.CZTEROMASZTOWCE = 0;
            //Variable2.TRZYMASZTOWCE = 2;
            //Variable2.DWUMASZTOWCE = 3;
            //Variable2.JEDNOMASZTOWIEC = 4;
            new Variable2();

            Player1Nickname p = new Player1Nickname();
            p.ShowDialog();

            PlaceShip(4, pM = new PlayerMatrix(), false);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameBoard[i, j] = new Image
                    {
                        Source = imgWater,
                        Stretch = Stretch.Fill
                    };

                }
            }
        }   //ale sam kod nie zmieniony 

        public PlayerMatrix PlaceShip(int size, PlayerMatrix pM, bool player)
        {
            s = new Game.Ship(size);
            if (!rdy)
            {
                pM = Game.SetShip(pM, s);
                if (!Game.CheckAllPosition(pM)) // jeżeli okazuje się że są nakładki
                {
                    AcceptButton.IsEnabled = false;
                }
                else
                {
                    AcceptButton.IsEnabled = true;
                }
                CreateScreen(pM);
                return pM;
            }
            else
            {
                eM = Game.SetShip(eM, s);
                if (!Game.CheckAllPosition(eM)) // jeżeli okazuje się że są nakładki
                {
                    AcceptButton.IsEnabled = false;
                }
                else
                {
                    AcceptButton.IsEnabled = true;
                }
                CreateScreen(eM);
                return eM;
            }



        }

        public void CreateScreen(PlayerMatrix pM)
        {
            MainWindow1.Height = 600;
            MainWindow1.Width = 600;
            GridStart.Visibility = Visibility.Hidden;
            PlaceShipScreen.Visibility = Visibility.Visible;
            //if (!rdy)
            //{
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (pM.playerMatrix[i, j] == 0)
                        {
                            gameBoard[i, j] = new Image
                            {
                                Source = imgWater,  // zero znaczy nic tu nie ma woda
                                Stretch = Stretch.Fill
                            };
                        }
                        else if (pM.playerMatrix[i, j] == 9)
                        {
                            gameBoard[i, j] = new Image
                            {
                                Source = imgMiss,  //jeżeli to 9 to tu nie można stawiać 
                                Stretch = Stretch.Fill
                            };
                        }
                        else if(pM.playerMatrix[i,j] == 1 ||pM.playerMatrix[i,j] == 3 ||pM.playerMatrix[i,j] == 5 ||pM.playerMatrix[i,j] == 7)
                        {
                            gameBoard[i, j] = new Image
                            {
                                Source = imgPlaceShip,        // to statek
                                Stretch = Stretch.Fill
                            };
                        }
                        else
                        {
                            gameBoard[i, j] = new Image
                            {
                                Source = imgShipColide ,      //kolizja
                                Stretch = Stretch.Fill
                            };
                        }


                        Grid.SetColumn(gameBoard[i, j], i + 1);
                        Grid.SetRow(gameBoard[i, j], j + 1);
                        PlaceShipScreen.Children.Add(gameBoard[i, j]);
                    }
                }
            //}
           //else
           // {
           //     for (int i = 0; i < 10; i++)
           //     {
           //         for (int j = 0; j < 10; j++)
           //         {
           //             if (pM.playerMatrix[i, j] == 0)
           //             {
           //                 gameBoard[i, j] = new Image
           //                 {
           //                     Source = imgWater,  // zero znaczy nic tu nie ma woda
           //                     Stretch = Stretch.Fill
           //                 };
           //             }
           //             else if (pM.playerMatrix[i, j] == 9)
           //             {
           //                 gameBoard[i, j] = new Image
           //                 {
           //                     Source = imgMiss,  //jeżeli to 9 to tu nie można stawiać 
           //                     Stretch = Stretch.Fill
           //                 };
           //             }
           //             else if(pM.playerMatrix[i,j] == 1 ||pM.playerMatrix[i,j] == 3 ||pM.playerMatrix[i,j] == 5 ||pM.playerMatrix[i,j] == 7)
           //             {
           //                 gameBoard[i, j] = new Image
           //                 {
           //                     Source = imgPlaceShip,        // to statek
           //                     Stretch = Stretch.Fill
           //                 };
           //             }
           //             else
           //             {
           //                 gameBoard[i, j] = new Image
           //                 {
           //                     Source = imgShipColide ,      //kolizja
           //                     Stretch = Stretch.Fill
           //                 };
           //             }
           //             Grid.SetColumn(gameBoard[i, j], i + 1);
           //             Grid.SetRow(gameBoard[i, j], j + 1);
           //             PlaceShipScreen.Children.Add(gameBoard[i, j]);
           //         }
           //     }
           // }
        }

        private void MoveShipRight(object sender, RoutedEventArgs e)
        {
            if ((s.y < 9 && s.rotate == false) || (s.rotate == true && s.y + s.size - 1 < 9))
            {
                if (!rdy)
                {
                    Game.ClearShip(pM, s);
                    s.y++;
                    Game.SetShip(pM, s);
                    CreateScreen(pM);
                    if (!Game.CheckAllPosition(pM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }
                }
                else
                {
                    Game.ClearShip(eM, s);
                    s.y++;
                    Game.SetShip(eM, s);
                    CreateScreen(eM);
                    if (!Game.CheckAllPosition(eM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }

                }
            }
            else
            {
                if (!rdy)
                {

                    CreateScreen(pM);
                }
                else
                {
                    CreateScreen(eM);
                }
            }

        }

        private void MoveShipLeft(object sender, RoutedEventArgs e)
        {
            if (s.y > 0)
            {
                if (!rdy)
                {
                    Game.ClearShip(pM, s);
                    s.y--;
                    Game.SetShip(pM, s);
                    CreateScreen(pM);
                    if (!Game.CheckAllPosition(pM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }
                }
                else
                {
                    Game.ClearShip(eM, s);
                    s.y--;
                    Game.SetShip(eM, s);
                    CreateScreen(eM);
                    if (!Game.CheckAllPosition(eM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }

                }
            }
            else
            {
                if (!rdy)
                {

                    CreateScreen(pM);
                }
                else
                {
                    CreateScreen(eM);
                }
            }

        }

        private void MoveShipUp(object sender, RoutedEventArgs e)
        {

            if (s.x > 0)
            {
                if (!rdy)
                {

                    Game.ClearShip(pM, s);
                    s.x--;
                    Game.SetShip(pM, s);
                    CreateScreen(pM);
                    if (!Game.CheckAllPosition(pM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }
                }
                else
                {
                    Game.ClearShip(eM, s);
                    s.x--;
                    Game.SetShip(eM, s);
                    CreateScreen(eM);
                    if (!Game.CheckAllPosition(eM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }

                }
            }

            else
            {
                if (!rdy)
                {

                    CreateScreen(pM);
                }
                else
                {
                    CreateScreen(eM);
                }
            }

        }

        private void MoveShipDown(object sender, RoutedEventArgs e)
        {
            if ((s.x < 9 && s.rotate == true) || (s.rotate == false && s.x + s.size - 1 < 9))
            {
                if (!rdy)
                {
                    Game.ClearShip(pM, s);
                    s.x++;
                    Game.SetShip(pM, s);
                    CreateScreen(pM);
                    if (!Game.CheckAllPosition(pM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }
                }
                else
                {
                    Game.ClearShip(eM, s);
                    s.x++;
                    Game.SetShip(eM, s);
                    CreateScreen(eM);
                    if (!Game.CheckAllPosition(eM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }

                }
            }
            else
            {
                if (!rdy)
                {

                    CreateScreen(pM);
                }
                else
                {
                    CreateScreen(eM);
                }
            }

        }

        private void RotateShip(object sender, RoutedEventArgs e)
        {
            if ((s.rotate == false && s.y + s.size - 1 <= 9) || (s.rotate == true && s.x + s.size - 1 <= 9))
            {
                if (!rdy)
                {
                    Game.ClearShip(pM, s);
                    s.rotate = !s.rotate;
                    Game.SetShip(pM, s);
                    CreateScreen(pM);
                    if (!Game.CheckAllPosition(pM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }
                }
                else
                {
                    Game.ClearShip(eM, s);
                    s.rotate = !s.rotate;
                    Game.SetShip(eM, s);
                    CreateScreen(eM);
                    if (!Game.CheckAllPosition(eM)) // jeżeli okazuje się że są nakładki
                    {
                        AcceptButton.IsEnabled = false;
                    }
                    else
                    {
                        AcceptButton.IsEnabled = true;
                    }
                }
            }
            else
            {
                if (!rdy)
                {

                    CreateScreen(pM);
                }
                else
                {
                    CreateScreen(eM);
                }
            }

        }

        private void SetShipOnPlace(object sender, RoutedEventArgs e)
        {
            if (!type || !rdy)
            {
                if (Variable2.TRZYMASZTOWCE > 0)
                {
                    pM = Game.SuroundShip(pM, s);
                    Variable2.TRZYMASZTOWCE--;
                    PlaceShip(3, pM, false);
                }
                else
                {
                    if (Variable2.DWUMASZTOWCE > 0)
                    {
                        pM = Game.SuroundShip(pM, s);
                        Variable2.DWUMASZTOWCE--;
                        PlaceShip(2, pM, false);
                    }
                    else
                    {
                        if (Variable2.JEDNOMASZTOWIEC > 0)
                        {
                            pM = Game.SuroundShip(pM, s);
                            Variable2.JEDNOMASZTOWIEC--;
                            PlaceShip(1, pM, false);
                        }
                        else
                        {
                            if (!type)
                            {
                                pM = Game.SuroundShip(pM, s);
                                Game.EnemyPlaceShips(eM);
                                GameScreen();
                                //zaczynamy gre trzeba podmienić grida na tego do gry
                            }
                            else
                            {
                                pM = Game.SuroundShip(pM, s);
                                for (int i = 0; i < 10; i++)
                                {
                                    for (int j = 0; j < 10; j++)
                                    {
                                        gameBoard[i, j] = new Image
                                        {
                                            Source = imgWater,
                                            Stretch = Stretch.Fill
                                        };

                                    }
                                }
                                Player1Nickname p = new Player1Nickname(false);
                                p.ShowDialog();
                                //Variable2.CZTEROMASZTOWCE = 0;
                                //Variable2.TRZYMASZTOWCE = 2;
                                //Variable2.DWUMASZTOWCE = 3;
                                //Variable2.JEDNOMASZTOWIEC = 4;
                                new Variable2();
                                rdy = true;
                                PlaceShip(4, eM = new PlayerMatrix(), false);


                            }

                        }
                    }
                }
            }
            else
            {
                if (Variable2.TRZYMASZTOWCE > 0)
                {
                    eM = Game.SuroundShip(eM, s);
                    Variable2.TRZYMASZTOWCE--;
                    PlaceShip(3, eM, false);
                }
                else
                {
                    if (Variable2.DWUMASZTOWCE > 0)
                    {
                        eM = Game.SuroundShip(eM, s);
                        Variable2.DWUMASZTOWCE--;
                        PlaceShip(2, eM, false);
                    }
                    else
                    {
                        if (Variable2.JEDNOMASZTOWIEC > 0)
                        {
                            eM = Game.SuroundShip(eM, s);
                            Variable2.JEDNOMASZTOWIEC--;
                            PlaceShip(1, eM, false);
                        }
                        else
                        {
                            eM = Game.SuroundShip(eM, s);
                            pM.playerMatrix[x1, y1] += 1000;
                            GameScreen();
                        }

                    }
                }

            }
        }

        public void GameScreen()
        {
            MainWindow1.Height = 600;
            MainWindow1.Width = 800;
            Grid1.Visibility = Visibility.Visible;
            PlaceShipScreen.Visibility = Visibility.Hidden;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    gameBoard1[i, j] = new Image
                    {
                        Source = imgWater,  // zero znaczy nic tu nie ma woda
                        Stretch = Stretch.Fill
                    };



                    Grid.SetColumn(gameBoard1[i, j], i + 1);
                    Grid.SetRow(gameBoard1[i, j], j + 1);
                    Grid1.Children.Add(gameBoard1[i, j]);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    gameBoard2[i, j] = new Image
                    {
                        Source = imgWater,  // zero znaczy nic tu nie ma woda
                        Stretch = Stretch.Fill
                    };


                    Grid.SetColumn(gameBoard2[i, j], i + 12);
                    Grid.SetRow(gameBoard2[i, j], j + 1);
                    Grid1.Children.Add(gameBoard2[i, j]);
                    if(type)
                    {
                        p2Name.Content = Console_Statki.Helper.Variable.PLAYER2_NICKNAME;
                        p1Name.Content = Console_Statki.Helper.Variable.PLAYER1_NICKNAME;
                    }
                    else
                    {
                        p2Name.Content = "Komputer";
                        p1Name.Content = Console_Statki.Helper.Variable.PLAYER1_NICKNAME;
                    }
                }
            }

            // tu pierwszo ustawić celownik
            eM.playerMatrix[x, y] += 1000;
            gameBoard1[x, y].Source = imgPointer;
        }

        private void PointerGoUp(object sender, RoutedEventArgs e)
        {
            if (y > 0 && !Game.turn)
            {

                eM.playerMatrix[x, y] -= 1000;
                y--;
                eM.playerMatrix[x, y] += 1000;
                if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                {
                   
                gameBoard1[x, y].Source = imgPointer;
                }
                if(eM.playerMatrix[x,y]==1123)
                {
                    gameBoard1[x, y].Source = imgPointerMiss;
                }
                if (eM.playerMatrix[x, y] == 1321)
                {
                    gameBoard1[x, y].Source = imgPointerShip;
                }
                if (eM.playerMatrix[x, y] == 1999)
                {
                    gameBoard1[x, y].Source = imgPointerHit;
                }
                if (eM.playerMatrix[x, y + 1] == 123)
                {
                    gameBoard1[x, y + 1].Source = imgMiss;
                }
                if (eM.playerMatrix[x, y + 1] == 321)
                {
                    gameBoard1[x, y + 1].Source = imgShip;
                }
                if (eM.playerMatrix[x, y + 1] == 999)
                {
                    gameBoard1[x, y + 1].Source = imgHit;
                }
                if (eM.playerMatrix[x, y + 1] == 0 || eM.playerMatrix[x, y + 1] == 9 || eM.playerMatrix[x, y + 1] == 1 || eM.playerMatrix[x, y + 1] == 3 || eM.playerMatrix[x, y + 1] == 5 || eM.playerMatrix[x, y + 1] == 7)
                {
                    gameBoard1[x, y + 1].Source = imgWater;
                }
                if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                {
                    ApprovedShot.IsEnabled = true;
                }
                else
                {
                    ApprovedShot.IsEnabled = false;
                }

            }
            if (y1 > 0 && Game.turn)
            {

                pM.playerMatrix[x1, y1] -= 1000;
                y1--;
                pM.playerMatrix[x1, y1] += 1000;
                //gameBoard2[x1, y1].Source = imgPointer;
                elsemach();
                if (pM.playerMatrix[x1, y1 + 1] == 123)
                {
                    gameBoard2[x1, y1 + 1].Source = imgMiss;
                }
                if (pM.playerMatrix[x1, y1 + 1] == 321)
                {
                    gameBoard2[x1, y1 + 1].Source = imgShip;
                }
                if (pM.playerMatrix[x1, y1 + 1] == 999)
                {
                    gameBoard2[x1, y1 + 1].Source = imgHit;
                }
                if (pM.playerMatrix[x1, y1 + 1] == 0 || pM.playerMatrix[x1, y1 + 1] == 9 || pM.playerMatrix[x1, y1 + 1] == 1 || pM.playerMatrix[x1, y1 + 1] == 3 || pM.playerMatrix[x1, y1 + 1] == 5 || pM.playerMatrix[x1, y1 + 1] == 7)
                {
                    gameBoard2[x1, y1 + 1].Source = imgWater;
                }
                if (pM.playerMatrix[x1, y1] == 1000 || pM.playerMatrix[x1, y1] == 1009 || pM.playerMatrix[x1, y1] == 1001 || pM.playerMatrix[x1, y1] == 1003 || pM.playerMatrix[x1, y1] == 1005 || pM.playerMatrix[x1, y1] == 1007)
                {
                    ApprovedShot.IsEnabled = true;
                }
                else
                {
                    ApprovedShot.IsEnabled = false;
                }
            }
        }   //poruszania wskaznikiem strzalu

        public void elsemach()
        {
            if (pM.playerMatrix[x1, y1] == 1000 || pM.playerMatrix[x1, y1] == 1009 || pM.playerMatrix[x1, y1] == 1001 || pM.playerMatrix[x1, y1] == 1003 || pM.playerMatrix[x1, y1] == 1005 || pM.playerMatrix[x1, y1] == 1007)
            {

                gameBoard2[x1, y1].Source = imgPointer;
            }
            if (pM.playerMatrix[x1, y1] == 1123)
            {
                gameBoard2[x1, y1].Source = imgPointerMiss;
            }
            if (pM.playerMatrix[x1, y1] == 1321)
            {
                gameBoard2[x1, y1].Source = imgPointerShip;
            }
            if (pM.playerMatrix[x1, y1] == 1999)
            {
                gameBoard2[x1, y1].Source = imgPointerHit;
            }
        }

        private void PointerGoDown(object sender, RoutedEventArgs e)
        {
            if (y < 9 && !Game.turn)
            {

                eM.playerMatrix[x, y] -= 1000;
                y++;
                eM.playerMatrix[x, y] += 1000;
                if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                {

                    gameBoard1[x, y].Source = imgPointer;
                }
                if (eM.playerMatrix[x, y] == 1123)
                {
                    gameBoard1[x, y].Source = imgPointerMiss;
                }
                if (eM.playerMatrix[x, y] == 1321)
                {
                    gameBoard1[x, y].Source = imgPointerShip;
                }
                if (eM.playerMatrix[x, y] == 1999)
                {
                    gameBoard1[x, y].Source = imgPointerHit;
                }
                if (eM.playerMatrix[x, y - 1] == 123)
                {
                    gameBoard1[x, y - 1].Source = imgMiss;
                }
                if (eM.playerMatrix[x, y - 1] == 321)
                {
                    gameBoard1[x, y - 1].Source = imgShip;
                }
                if (eM.playerMatrix[x, y - 1] == 999)
                {
                    gameBoard1[x, y - 1].Source = imgHit;
                }
                if (eM.playerMatrix[x, y - 1] == 0 || eM.playerMatrix[x, y - 1] == 9 || eM.playerMatrix[x, y - 1] == 1 || eM.playerMatrix[x, y - 1] == 3 || eM.playerMatrix[x, y - 1] == 5 || eM.playerMatrix[x, y - 1] == 7)
                {
                    gameBoard1[x, y - 1].Source = imgWater;
                }
                if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                {
                    ApprovedShot.IsEnabled = true;
                }
                else
                {
                    ApprovedShot.IsEnabled = false;
                }
            }
            if (y1 < 9 && Game.turn)
            {
                pM.playerMatrix[x1, y1] -= 1000;
                y1++;
                pM.playerMatrix[x1, y1] += 1000;
                //gameBoard2[x1, y1].Source = imgPointer;
                elsemach();
                if (pM.playerMatrix[x1, y1 - 1] == 123)
                {
                    gameBoard2[x1, y1 - 1].Source = imgMiss;
                }
                if (pM.playerMatrix[x1, y1 - 1] == 321)
                {
                    gameBoard2[x1, y1 - 1].Source = imgShip;
                }
                if (pM.playerMatrix[x1, y1 - 1] == 999)
                {
                    gameBoard2[x1, y1 - 1].Source = imgHit;
                }
                if (pM.playerMatrix[x1, y1 - 1] == 0 || pM.playerMatrix[x1, y1 - 1] == 9 || pM.playerMatrix[x1, y1 - 1] == 1 || pM.playerMatrix[x1, y1 - 1] == 3 || pM.playerMatrix[x1, y1 - 1] == 5 || pM.playerMatrix[x1, y1 - 1] == 7)
                {
                    gameBoard2[x1, y1 - 1].Source = imgWater;
                }
                if (pM.playerMatrix[x1, y1] == 1000 || pM.playerMatrix[x1, y1] == 1009 || pM.playerMatrix[x1, y1] == 1001 || pM.playerMatrix[x1, y1] == 1003 || pM.playerMatrix[x1, y1] == 1005 || pM.playerMatrix[x1, y1] == 1007)
                {
                    ApprovedShot.IsEnabled = true;
                }
                else
                {
                    ApprovedShot.IsEnabled = false;
                }
            }


        } //to co wyzej 

        private void PointerGoLeft(object sender, RoutedEventArgs e)
        {
            if (x > 0 && !Game.turn)
            {

                eM.playerMatrix[x, y] -= 1000;
                x--;
                eM.playerMatrix[x, y] += 1000;
                if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                {

                    gameBoard1[x, y].Source = imgPointer;
                }
                if (eM.playerMatrix[x, y] == 1123)
                {
                    gameBoard1[x, y].Source = imgPointerMiss;
                }
                if (eM.playerMatrix[x, y] == 1321)
                {
                    gameBoard1[x, y].Source = imgPointerShip;
                }
                if (eM.playerMatrix[x, y] == 1999)
                {
                    gameBoard1[x, y].Source = imgPointerHit;
                }
                if (eM.playerMatrix[x + 1, y] == 123)
                {
                    gameBoard1[x + 1, y].Source = imgMiss;
                }
                if (eM.playerMatrix[x + 1, y] == 321)
                {
                    gameBoard1[x + 1, y].Source = imgShip;
                }
                if (eM.playerMatrix[x + 1, y] == 999)
                {
                    gameBoard1[x + 1, y].Source = imgHit;
                }
                if (eM.playerMatrix[x + 1, y] == 0 || eM.playerMatrix[x + 1, y] == 9 || eM.playerMatrix[x + 1, y] == 1 || eM.playerMatrix[x + 1, y] == 3 || eM.playerMatrix[x + 1, y] == 5 || eM.playerMatrix[x + 1, y] == 7)
                {
                    gameBoard1[x + 1, y].Source = imgWater;
                }
                if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                {
                    ApprovedShot.IsEnabled = true;
                }
                else
                {
                    ApprovedShot.IsEnabled = false;
                }
            }

            if (x1 > 0 && Game.turn)
            {
                pM.playerMatrix[x1, y1] -= 1000;
                x1--;
                pM.playerMatrix[x1, y1] += 1000;
               // gameBoard2[x1, y1].Source = imgPointer;
                elsemach();
                if (pM.playerMatrix[x1 + 1, y1] == 123)
                {
                    gameBoard2[x1 + 1, y1].Source = imgMiss;
                }
                if (pM.playerMatrix[x1 + 1, y1] == 321)
                {
                    gameBoard2[x1 + 1, y1].Source = imgShip;
                }
                if (pM.playerMatrix[x1 + 1, y1] == 999)
                {
                    gameBoard2[x1 + 1, y1].Source = imgHit;
                }
                if (pM.playerMatrix[x1 + 1, y1] == 0 || pM.playerMatrix[x1 + 1, y1] == 9 || pM.playerMatrix[x1 + 1, y1] == 1 || pM.playerMatrix[x1 + 1, y1] == 3 || pM.playerMatrix[x1 + 1, y1] == 5 || pM.playerMatrix[x1 + 1, y1] == 7)
                {
                    gameBoard2[x1 + 1, y1].Source = imgWater;
                }
                if (pM.playerMatrix[x1, y1] == 1000 || pM.playerMatrix[x1, y1] == 1009 || pM.playerMatrix[x1, y1] == 1001 || pM.playerMatrix[x1, y1] == 1003 || pM.playerMatrix[x1, y1] == 1005 || pM.playerMatrix[x1, y1] == 1007)
                {
                    ApprovedShot.IsEnabled = true;
                }
                else
                {
                    ApprovedShot.IsEnabled = false;
                }
            }


        } //to co wyzej 

        private void PointerGoRight(object sender, RoutedEventArgs e)
        {

            if (x < 9 && !Game.turn)
            {

                eM.playerMatrix[x, y] -= 1000;
                x++;
                eM.playerMatrix[x, y] += 1000;
                if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                {

                    gameBoard1[x, y].Source = imgPointer;
                }
                if (eM.playerMatrix[x, y] == 1123)
                {
                    gameBoard1[x, y].Source = imgPointerMiss;
                }
                if (eM.playerMatrix[x, y] == 1321)
                {
                    gameBoard1[x, y].Source = imgPointerShip;
                }
                if (eM.playerMatrix[x, y] == 1999)
                {
                    gameBoard1[x, y].Source = imgPointerHit;
                }
                if (eM.playerMatrix[x - 1, y] == 123)
                {
                    gameBoard1[x - 1, y].Source = imgMiss;
                }
                if (eM.playerMatrix[x - 1, y] == 321)
                {
                    gameBoard1[x - 1, y].Source = imgShip;
                }
                if (eM.playerMatrix[x - 1, y] == 999)
                {
                    gameBoard1[x - 1, y].Source = imgHit;
                }
                if (eM.playerMatrix[x - 1, y] == 0 || eM.playerMatrix[x - 1, y] == 9 || eM.playerMatrix[x - 1, y] == 1 || eM.playerMatrix[x - 1, y] == 3 || eM.playerMatrix[x - 1, y] == 5 || eM.playerMatrix[x - 1, y] == 7)
                {
                    gameBoard1[x - 1, y].Source = imgWater;
                }
                if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                {
                    ApprovedShot.IsEnabled = true;
                }
                else
                {
                    ApprovedShot.IsEnabled = false;
                }
            }
            if (x1 < 9 && Game.turn)
            {
                pM.playerMatrix[x1, y1] -= 1000;
                x1++;
                pM.playerMatrix[x1, y1] += 1000;
                //gameBoard2[x1, y1].Source = imgPointer;
                elsemach();
                if (pM.playerMatrix[x1 - 1, y1] == 123)
                {
                    gameBoard2[x1 - 1, y1].Source = imgMiss;
                }
                if (pM.playerMatrix[x1 - 1, y1] == 321)
                {
                    gameBoard2[x1 - 1, y1].Source = imgShip;
                }
                if (pM.playerMatrix[x1 - 1, y1] == 999)
                {
                    gameBoard2[x1 - 1, y1].Source = imgHit;
                }
                if (pM.playerMatrix[x1 - 1, y1] == 0 || pM.playerMatrix[x1 - 1, y1] == 9 || pM.playerMatrix[x1 - 1, y1] == 1 || pM.playerMatrix[x1 - 1, y1] == 3 || pM.playerMatrix[x1 - 1, y1] == 5 || pM.playerMatrix[x1 - 1, y1] == 7)
                {
                    gameBoard2[x1 - 1, y1].Source = imgWater;
                }
                if (pM.playerMatrix[x1, y1] == 1000 || pM.playerMatrix[x1, y1] == 1009 || pM.playerMatrix[x1, y1] == 1001 || pM.playerMatrix[x1, y1] == 1003 || pM.playerMatrix[x1, y1] == 1005 || pM.playerMatrix[x1, y1] == 1007)
                {
                    ApprovedShot.IsEnabled = true;
                }
                else
                {
                    ApprovedShot.IsEnabled = false;
                }
            }
        }//to co wyzej 

        private void ApprovedShotGo(object sender, RoutedEventArgs e)
        {
            if (!type)
            {
                eM.playerMatrix[x, y] -= 1000;
                eM = Game.Shoot(eM, x, y);

                if (eM.playerMatrix[Game.playerHit.X, Game.playerHit.Y] == 999 || eM.playerMatrix[Game.playerHit.X, Game.playerHit.Y] == 321)
                {


                    Game.g1 += Game.state * Game.combo;
                    Game.combo++;
                    CheckIsEnd();
                }
                else
                {
                    Game.combo = 1;
                    Game.coordinate = eP.Shoot(Game.hit, pM);
                    pM = Game.ShootEnemy(pM, Game.coordinate.X, Game.coordinate.Y);


                    while (pM.playerMatrix[Game.coordinate.X, Game.coordinate.Y] == 999 || pM.playerMatrix[Game.coordinate.X, Game.coordinate.Y] == 321)
                    {
                        Game.g2 += Game.state * Game.combo;
                        Game.combo++;
                        if (CheckIsEnd())
                        {
                            break;
                        }

                        if (Game.defeat == true)
                        {
                            eP.IsDefeat(Game.defeat, pM, Game.defeatlenght, Game.defeaty, Game.defeatx, Game.defeatr);
                            Game.defeat = false;


                        }
                        Game.coordinate = eP.Shoot(Game.hit, pM);
                        pM = Game.ShootEnemy(pM, Game.coordinate.X, Game.coordinate.Y);
                    }


                    Game.combo = 1;

                }
                eM.playerMatrix[x, y] += 1000;
                AfterShootsScreen();
                ApprovedShot.IsEnabled = false;
            }
            else
            {
                if (!Game.turn)
                {
                    eM.playerMatrix[x, y] -= 1000;
                    eM = Game.Shoot(eM, x, y);

                    if (eM.playerMatrix[Game.playerHit.X, Game.playerHit.Y] == 999 || eM.playerMatrix[Game.playerHit.X, Game.playerHit.Y] == 321)
                    {


                        Game.g1 += Game.state * Game.combo;
                        Game.combo++;
                        CheckIsEnd();
                    }
                    else
                    {
                        Game.turn = true;
                        Game.combo = 1;

                    }
                    eM.playerMatrix[x, y] += 1000;
                    AfterShootsScreen();
                    ApprovedShot.IsEnabled = false;
                }
                else
                {
                    pM.playerMatrix[x1, y1] -= 1000;
                    pM = Game.Shoot(pM, x1, y1);
                    if (pM.playerMatrix[Game.playerHit.X, Game.playerHit.Y] == 999 || pM.playerMatrix[Game.playerHit.X, Game.playerHit.Y] == 321)
                    {


                        Game.g2 += Game.state * Game.combo;
                        Game.combo++;
                        CheckIsEnd();
                    }
                    else
                    {
                        Game.turn = false;
                        Game.combo = 1;
                    }
                    pM.playerMatrix[x1, y1] += 1000;
                    AfterShootsScreen();
                    ApprovedShot.IsEnabled = false;
                }
            }

        }

        public void AfterShootsScreen()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (eM.playerMatrix[i, j] == 0)
                    {
                        gameBoard1[i, j].Source = imgWater;  // zero znaczy nic tu nie ma woda

                    }
                    if (eM.playerMatrix[i, j] == 123)
                    {
                        gameBoard1[i, j].Source = imgMiss; //jeżeli to 123 to tu nie można stawiać bo już spudłowano


                    }
                   if (eM.playerMatrix[i, j] == 321)
                    {
                        gameBoard1[i, j].Source = imgShip;        //jeżeli  jest 321  to jest to statek na razie gówno bo brak rys statku

                    }
                    if (eM.playerMatrix[i, j] == 999)
                    {
                        gameBoard1[i, j].Source = imgHit;        //jeżeli jest 999  ani 0 to jest to statek zatopiony razie ogien bo brak rys statku


                    }
                    if (eM.playerMatrix[x, y] == 1000 || eM.playerMatrix[x, y] == 1009 || eM.playerMatrix[x, y] == 1001 || eM.playerMatrix[x, y] == 1003 || eM.playerMatrix[x, y] == 1005 || eM.playerMatrix[x, y] == 1007)
                    {

                        gameBoard1[x, y].Source = imgPointer;
                    }
                    if (eM.playerMatrix[x, y] == 1123)
                    {
                        gameBoard1[x, y].Source = imgPointerMiss;
                    }
                    if (eM.playerMatrix[x, y] == 1321)
                    {
                        gameBoard1[x, y].Source = imgPointerShip;
                    }
                    if (eM.playerMatrix[x, y] == 1999)
                    {
                        gameBoard1[x, y].Source = imgPointerHit;
                    }


                }
            }


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (pM.playerMatrix[i, j] == 0)
                    {
                        gameBoard2[i, j].Source = imgWater;  // zero znaczy nic tu nie ma woda

                    }
                    else if (pM.playerMatrix[i, j] == 123)
                    {
                        gameBoard2[i, j].Source = imgMiss;  //jeżeli to 123 to tu nie można stawiać bo już spudłowano

                    }
                    else if (pM.playerMatrix[i, j] == 321)
                    {
                        gameBoard2[i, j].Source = imgShip;       //jeżeli  jest 321  to jest to statek na razie gówno bo brak rys statku

                    }
                    else if (pM.playerMatrix[i, j] == 999)
                    {
                        gameBoard2[i, j].Source = imgHit;       //jeżeli jest 999  ani 0 to jest to statek zatopiony razie ogien bo brak rys statku

                    }
                    elsemach();

                }
            }
        }

        public bool CheckIsEnd()
        {
            bool state = false;
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
                if (!type)
                {
                    EndScore.Content = "Wygrał Komputer";
                    EndScore.Visibility = Visibility.Visible;
                    EndGameButton.Visibility = Visibility.Visible;
                    pointerDown.IsEnabled = false;
                    pointerUp.IsEnabled = false;
                    pointerLeft.IsEnabled = false;
                    pointerRight.IsEnabled = false;
                    ApprovedShot.IsEnabled = false;
                    state = true;
                }
                else
                {
                    EndScore.Content = "Wygrał " + Console_Statki.Helper.Variable.PLAYER2_NICKNAME; //trza ten nick zczytac
                    EndScore.Visibility = Visibility.Visible;
                    EndGameButton.Visibility = Visibility.Visible;
                    pointerDown.IsEnabled = false;
                    pointerUp.IsEnabled = false;
                    pointerLeft.IsEnabled = false;
                    pointerRight.IsEnabled = false;
                    ApprovedShot.IsEnabled = false;
                    state = true;
                    Console_Statki.Model.DAL.HighscoreModel.InsertInto(Console_Statki.Helper.Variable.PLAYER2_NICKNAME, Game.g2);

                }

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
                    EndScore.Content = "Wygrał " + Console_Statki.Helper.Variable.PLAYER1_NICKNAME; //trza ten nick zczytac
                    EndScore.Visibility = Visibility.Visible;
                    EndGameButton.Visibility = Visibility.Visible;
                    pointerDown.IsEnabled = false;
                    pointerUp.IsEnabled = false;
                    pointerLeft.IsEnabled = false;
                    pointerRight.IsEnabled = false;
                    ApprovedShot.IsEnabled = false;
                    state = true;
                    Console_Statki.Model.DAL.HighscoreModel.InsertInto(Console_Statki.Helper.Variable.PLAYER1_NICKNAME, Game.g1);
                }
            }
            return state;
        }

        private void HighScoreButton(object sender, RoutedEventArgs e)
        {
            GridStart.Visibility = Visibility.Hidden;
            HighscoreWindow.Visibility = Visibility.Visible;
            hiSc = new Image
            {
                Source = imgHighs,
                Stretch = Stretch.Fill
            };



            Grid.SetColumn(hiSc, 0);
            Grid.SetRow(hiSc, 0);
            HighscoreWindow.Children.Add(hiSc);
            Listbox.Items.Clear();
            List<Highscore> highscore = Console_Statki.Model.DAL.HighscoreModel.SelectAll();
            foreach (object o in highscore)
            {
                Listbox.Items.Add(o);
            }
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoToMenu(object sender, RoutedEventArgs e)
        {
            MainWindow1.Height = 300;
            MainWindow1.Width = 400;
            GridStart.Visibility = Visibility.Visible;
            Grid1.Visibility = Visibility.Hidden;

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            GridStart.Visibility = Visibility.Visible;
            HighscoreWindow.Visibility = Visibility.Hidden;
        }
    }


}



