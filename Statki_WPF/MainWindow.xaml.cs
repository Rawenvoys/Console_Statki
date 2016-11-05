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
using Console_Statki;


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
        public Image[,] gameBoard = new Image[10, 10];
        public Image[,] gameBoard1 = new Image[10, 10];
        Game.Ship s;
        PlayerMatrix pM;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void NewGame1P(object sender, RoutedEventArgs e)
        {
            
            PlaceShip(4,  pM =new PlayerMatrix(), false);
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
                   Grid.SetColumn(gameBoard[i, j], i+1);
                   Grid.SetRow(gameBoard[i, j], j +1);
                   PlaceShipScreen.Children.Add(gameBoard[i, j]);
               }
           }
        }

        public void EnterNicknameP1()
        {
            Player1Nickname p = new Player1Nickname();
            p.ShowDialog();
        }

        public  PlayerMatrix PlaceShip(int size, PlayerMatrix pM, bool player)
        {
            s = new Game.Ship(size);
            
           

            pM = Game.SetShip(pM, s);
            CreateScreen(pM);
          
            
            return pM;
        }

        public  void CreateScreen(PlayerMatrix pM)
        {
            MainWindow1.Height = 600;
            MainWindow1.Width = 600;
            GridStart.Visibility = Visibility.Hidden;
            PlaceShipScreen.Visibility = Visibility.Visible;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (pM.playerMatrix[i, j] == 0 )
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
            if ((s.y < 9 && s.rotate == false) || (s.rotate == true && s.y + s.size  - 1 < 9))
            {
                Game.ClearShip(pM, s);
                s.y++;
                Game.SetShip(pM, s);
                CreateScreen(pM);
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
            }
            else
            {
                CreateScreen(pM);
            }

        }

        private void MoveShipDown(object sender, RoutedEventArgs e)
        {
            if ((s.x < 9&& s.rotate == true) || (s.rotate == false && s.x + s.size - 1 < 9))
            {
                Game.ClearShip(pM, s);
                s.x++;
                Game.SetShip(pM, s);
                CreateScreen(pM);
            }
            else
            {
                CreateScreen(pM);
            }

        }

        private void RotateShip(object sender, RoutedEventArgs e)
        {
            if ((s.rotate == false && s.y + s.size - 1 <= 9) || (s.rotate == true && s.x + s.size  - 1 <= 9))
                    {
                        Game.ClearShip(pM, s);
                        s.rotate = !s.rotate;
                        Game.SetShip(pM, s);
                       CreateScreen(pM);
                    }
                    else
                        CreateScreen(pM);
                }
        }
}

        
    
