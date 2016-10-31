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
        public MainWindow()
        {
            InitializeComponent();
            
       
         
       
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow1.Height = 600;
            MainWindow1.Width = 800;
            GridStart.Visibility = Visibility.Hidden;
            Grid1.Visibility = Visibility.Visible;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameBoard[i, j] = new Image
                    {
                        Source = imgWater,
                        Stretch = Stretch.Fill
                    };
                    Grid.SetColumn(gameBoard[i, j], i);
                    Grid.SetRow(gameBoard[i, j], j + 1);
                    Grid1.Children.Add(gameBoard[i, j]);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameBoard1[i, j] = new Image
                    {
                        Source = imgWater,
                        Stretch = Stretch.Fill
                    };
                    Grid.SetColumn(gameBoard1[i, j], i + 11);
                    Grid.SetRow(gameBoard1[i, j], j + 1);
                    Grid1.Children.Add(gameBoard1[i, j]);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow1.Height = 600;
            MainWindow1.Width = 600;
            GridStart.Visibility = Visibility.Hidden;
           PlaceShip.Visibility = Visibility.Visible;
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
                   PlaceShip.Children.Add(gameBoard[i, j]);
               }
           }
        }
      
    }
}
