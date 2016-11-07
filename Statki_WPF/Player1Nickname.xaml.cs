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
using System.Windows.Shapes;
using Console_Statki.Model;
using Console_Statki.Helper;

namespace Statki_WPF
{
    /// <summary>
    /// Interaction logic for Player1Nickname.xaml
    /// </summary>
    /// 
   
    public partial class Player1Nickname : Window
    {
        bool player= true;
        public Player1Nickname()
        {
            InitializeComponent();
        }
        public Player1Nickname(bool p)
        {
            
            player = p;
            InitializeComponent();
            label123.Content = "Imie drugiego gracza";
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(text.Text!="")
            {
                zatwierdz.IsEnabled = true;
            }
            else
            {
                zatwierdz.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (player)
            {
                Console_Statki.Helper.Variable.PLAYER1_NICKNAME = "Gracz 1";
                Close();
            }
            else
            {
                Console_Statki.Helper.Variable.PLAYER2_NICKNAME = "Gracz 2";
                Close();
            }
        }

        private void zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (player)
            {
                Console_Statki.Helper.Variable.PLAYER1_NICKNAME = text.Text;
                Close();
            }
            else
            {
                Console_Statki.Helper.Variable.PLAYER2_NICKNAME = text.Text;
                Close();
            }
        }
    }
}
