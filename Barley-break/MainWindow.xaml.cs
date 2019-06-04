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

namespace Barley_break
{
    public partial class MainWindow : Window
    {
        Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            game.Start();
            for (int i = 0; i < 200; i++)
                game.ShiftRandom();
            RefreshButton();
        }

        private void RefreshButton()
        {
            for (int position = 0; position < 16; position++)
            {
                int number = game.GetNumber(position);
                button(position).Content = number.ToString();
                if (number > 0)
                    button(position).Visibility = Visibility.Visible;
                else if (number == 0)
                    button(position).Visibility = Visibility.Collapsed;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt16(((Button)sender).Tag);
            game.Shift(position);
            RefreshButton();
            if (game.CheckNumber())
            {
                MessageBox.Show("You win!");
                StartGame();
            }
        }

        private Button button(int position)
        {
            switch(position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        

    }
}
