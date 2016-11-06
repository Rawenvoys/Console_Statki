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
        static ImageSource imgHit = new BitmapImage(new Uri("ogień.gif", UriKind.RelativeOrAbsolute));
        static ImageSource imgMiss = new BitmapImage(new Uri("miss.jpg", UriKind.RelativeOrAbsolute));
        static ImageSource imgPointer = new BitmapImage(new Uri("pointer.jpg", UriKind.RelativeOrAbsolute));
        public Image[,] gameBoard = new Image[10, 10];
        public Image[,] gameBoard1 = new Image[10, 10];
        public Image[,] gameBoard2 = new Image[10, 10];
        Game.Ship s;
        PlayerMatrix pM;
        PlayerMatrix eM = new PlayerMatrix();
        int x = 0;
        int y = 0;
       
        public MainWindow()
        {
            InitializeComponent();

        }

        private void NewGame1P(object sender, RoutedEventArgs e)
        {
            Variable2.CZTEROMASZTOWCE = 0;
            Variable2.TRZYMASZTOWCE = 2;
            Variable2.DWUMASZTOWCE = 3;
            Variable2.JEDNOMASZTOWIEC = 4;
            PlaceShip(4, pM = new PlayerMatrix(), false);
            //Game.StartNewGame();

        }

        private void NewGame2P(object sender, RoutedEventArgs e)
        {
            MainWindow1.Height = 600;
            MainWindow1.Width = 600;
            GridStart.Visibility = Visibility.Hidden;
            PlaceShipScreen.Visibility = Visibility.Visible;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameBoard[i, j] = new Image
                    {
                        Source = imgWater,
                        Stretch = Stretch.Fill
                    };
                    Grid.SetColumn(gameBoard[i, j], i + 1);
                    Grid.SetRow(gameBoard[i, j], j + 1);
                    PlaceShipScreen.Children.Add(gameBoard[i, j]);
                }
            }
        }

        public void EnterNicknameP1()
        {
            Player1Nickname p = new Player1Nickname();
            p.ShowDialog();
        }

        public PlayerMatrix PlaceShip(int size, PlayerMatrix pM, bool player)
        {
            s = new Game.Ship(size);
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

        public void CreateScreen(PlayerMatrix pM)
        {
            MainWindow1.Height = 600;
            MainWindow1.Width = 600;
            GridStart.Visibility = Visibility.Hidden;
            PlaceShipScreen.Visibility = Visibility.Visible;
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
                    else
                    {
                        gameBoard[i, j] = new Image
                        {
                            Source = imgHit,        //jeżeli nie jest 9  ani 0 to jest to statek na razie ogien bo brak rys statku
                            Stretch = Stretch.Fill
                        };
                    }


                    Grid.SetColumn(gameBoard[i, j], i + 1);
                    Grid.SetRow(gameBoard[i, j], j + 1);
                    PlaceShipScreen.Children.Add(gameBoard[i, j]);
                }
            }

        }

        private void MoveShipRight(object sender, RoutedEventArgs e)
        {
            if ((s.y < 9 && s.rotate == false) || (s.rotate == true && s.y + s.size - 1 < 9))
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
                CreateScreen(pM);
            }

        }

        private void MoveShipLeft(object sender, RoutedEventArgs e)
        {
            if (s.y > 0)
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
                CreateScreen(pM);
            }

        }

        private void MoveShipUp(object sender, RoutedEventArgs e)
        {
            if (s.x > 0)
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
                CreateScreen(pM);
            }

        }

        private void MoveShipDown(object sender, RoutedEventArgs e)
        {
            if ((s.x < 9 && s.rotate == true) || (s.rotate == false && s.x + s.size - 1 < 9))
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
                CreateScreen(pM);
            }

        }

        private void RotateShip(object sender, RoutedEventArgs e)
        {
            if ((s.rotate == false && s.y + s.size - 1 <= 9) || (s.rotate == true && s.x + s.size - 1 <= 9))
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
                CreateScreen(pM);
        }

        private void SetShipOnPlace(object sender, RoutedEventArgs e)
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
                        pM = Game.SuroundShip(pM, s);
                        Game.EnemyPlaceShips(eM);
                        GameScreen();
                        //zaczynamy gre trzeba podmienić grida na tego do gry
                    }
                }
            }
        }

        public void GameScreen()
        {
            MainWindow1.Height = 800;
            MainWindow1.Width = 800;
            Grid1.Visibility = Visibility.Visible;
            PlaceShipScreen.Visibility = Visibility.Hidden;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                  /*  if (pM.playerMatrix[i, j] == 0)
                    {*/
                        gameBoard1[i, j] = new Image
                        {
                            Source = imgWater,  // zero znaczy nic tu nie ma woda
                            Stretch = Stretch.Fill
                        };
                   /* }
                  else if (pM.playerMatrix[i, j] == 123)
                    {
                        gameBoard1[i, j] = new Image
                        {
                            Source = imgMiss,  //jeżeli to 123 to tu nie można stawiać bo już spudłowano
                            Stretch = Stretch.Fill
                        };
                    }
                    else
                    {
                        gameBoard1[i, j] = new Image
                        {
                            Source = imgHit,        //jeżeli nie jest 9  ani 0 to jest to statek na razie ogien bo brak rys statku
                            Stretch = Stretch.Fill
                        };
                    }*/


                    Grid.SetColumn(gameBoard1[i, j], i + 1);
                    Grid.SetRow(gameBoard1[i, j], j + 1);
                    Grid1.Children.Add(gameBoard1[i, j]);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                   /* if (eM.playerMatrix[i, j] == 0)
                    {*/
                        gameBoard2[i, j] = new Image
                        {
                            Source = imgWater,  // zero znaczy nic tu nie ma woda
                            Stretch = Stretch.Fill
                        };
                 /*   }
                    else if (eM.playerMatrix[i, j] == 9)
                    {
                        gameBoard2[i, j] = new Image
                        {
                            Source = imgMiss,  //jeżeli to 9 to tu nie można stawiać 
                            Stretch = Stretch.Fill
                        };
                    }
                    else
                    {
                        gameBoard2[i, j] = new Image
                        {
                            Source = imgHit,        //jeżeli nie jest 9  ani 0 to jest to statek na razie ogien bo brak rys statku
                            Stretch = Stretch.Fill
                        };
                    }
                    */

                    Grid.SetColumn(gameBoard2[i, j], i + 12);
                    Grid.SetRow(gameBoard2[i, j], j + 1);
                    Grid1.Children.Add(gameBoard2[i, j]);
                }
            }

            // tu pierwszo ustawić celownik
            eM.playerMatrix[x, y] += 1000;
            gameBoard1[x, y].Source = imgPointer;
        }

        private void PointerGoUp(object sender, RoutedEventArgs e)
        {
            if(y > 0)
            {
                eM.playerMatrix[x, y] -= 1000;
                y--;
                eM.playerMatrix[x, y] += 1000;
                gameBoard1[x, y].Source = imgPointer;
                if( eM.playerMatrix[x, y+1]==123)
                {
                    gameBoard1[x, y + 1].Source = imgMiss;
                }
                if (eM.playerMatrix[x, y + 1] == 321)
                {
                    gameBoard1[x, y + 1].Source = imgHit;
                }
                if (eM.playerMatrix[x, y + 1] == 999)
                {
                    gameBoard1[x, y + 1].Source = imgHit;
                }
                else
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
            
        }   //poruszania wskaznikiem strzalu

        private void PointerGoDown(object sender, RoutedEventArgs e)
        {
            if (y < 9)
            {
                eM.playerMatrix[x, y] -= 1000;
                y++;
                eM.playerMatrix[x, y] += 1000;
                gameBoard1[x, y].Source = imgPointer;
                if (eM.playerMatrix[x, y - 1] == 123)
                {
                    gameBoard1[x, y - 1].Source = imgMiss;
                }
                if (eM.playerMatrix[x, y - 1] == 321)
                {
                    gameBoard1[x, y - 1].Source = imgHit;
                }
                if (eM.playerMatrix[x, y - 1] == 999)
                {
                    gameBoard1[x, y - 1].Source = imgHit;
                }
                else
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
        } //to co wyzej 

        private void PointerGoLeft(object sender, RoutedEventArgs e)
        {
            if (x > 0)
            {
                eM.playerMatrix[x, y] -= 1000;
                x--;
                eM.playerMatrix[x, y] += 1000;
                gameBoard1[x, y].Source = imgPointer;
                if (eM.playerMatrix[x +1, y] == 123)
                {
                    gameBoard1[x +1, y ].Source = imgMiss;
                }
                if (eM.playerMatrix[x +1, y ] == 321)
                {
                    gameBoard1[x + 1, y ].Source = imgHit;
                }
                if (eM.playerMatrix[x +1, y ] == 999)
                {
                    gameBoard1[x +1, y ].Source = imgHit;
                }
                else
                {
                    gameBoard1[x +1, y ].Source = imgWater;
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
        } //to co wyzej 

        private void PointerGoRight(object sender, RoutedEventArgs e)
        {

            if (x < 9)
            {
                eM.playerMatrix[x, y] -= 1000;
                x++;
                eM.playerMatrix[x, y] += 1000;
                gameBoard1[x, y].Source = imgPointer;
                if (eM.playerMatrix[x -1, y ] == 123)
                {
                    gameBoard1[x-1, y ].Source = imgMiss;
                }
                if (eM.playerMatrix[x -1, y ] == 321)
                {
                    gameBoard1[x-1, y ].Source = imgHit;
                }
                if (eM.playerMatrix[x-1, y ] == 999)
                {
                    gameBoard1[x-1, y].Source = imgHit;
                }
                else
                {
                    gameBoard1[x -1, y ].Source = imgWater;
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
        } //to co wyzej 
    }

    
}



