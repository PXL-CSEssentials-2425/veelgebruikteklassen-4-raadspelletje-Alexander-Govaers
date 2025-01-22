using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
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
using Microsoft.VisualBasic;

namespace raadspelletje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;
        bool hasWon = false;
        bool inputBox;
        int inputUser;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void sluitenButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void startButton(object sender, RoutedEventArgs e)
        {
            
            Random rnd = new Random();
            int winningNumber = rnd.Next(0, 101);
            counter = 0;
           
             //int.TryParse(Interaction.InputBox("Geef een willekeurig getal tussen 0 en 100", "Raadspel", "0"), out inputUser); //inputbox aanmaken

            startcheck(winningNumber);


        }
        private void startcheck(int winningNumber)
        {
            do
            {
                inputUser = GiveAnswer();
                Checkanswer(inputUser,winningNumber);
            }
            while (inputUser != winningNumber);
                
                
        }
        private int GiveAnswer()
        {
            int inputNumber;
           
           
                inputBox = int.TryParse(Interaction.InputBox("Geef een willekeurig getal tussen 0 en 100", "Raadspel", "0"), out inputNumber);
                while (inputBox == false)
                {


                    MessageBox.Show("Dit is geen getal", "raadspel", MessageBoxButton.OK, MessageBoxImage.Error);
                    inputBox = int.TryParse(Interaction.InputBox("Geef een willekeurig getal tussen 0 en 100", "Raadspel", "0"), out inputNumber);


                }
          
            return inputNumber;
        }
        private void Checkanswer(int inputNumber, int winningNumber)
        {
            if (inputNumber > winningNumber)
            {

                MessageBox.Show("Raad lager", "raadspel", MessageBoxButton.OK);
                counter++;


            }
            else if (inputNumber < winningNumber)
            {

                MessageBox.Show("Raad hoger", "raadspel", MessageBoxButton.OK);
                counter++;


            }

            else
            {
                counter++;
                MessageBox.Show($"U heeft het getal geraden in {counter} beurten ", "Proficiat", MessageBoxButton.OK);
                hasWon = true;

            }
        }
    }
}








