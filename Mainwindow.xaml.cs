/*
 * Aidan McClung
 * April 23, 2018
 * u3AidanMHangman
 * A program to play "hangman"
*/

//note: a feature to play with custom words has been commented out and is indicated by the comment: "custom words"

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

using System.IO;
using System.Net;

namespace u3AidanMHangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string tempWord = "";
        string[] goals = new string[9];
        string[] guessed = new string[9];
        int lives = 7;
//*change: moved stream reader creation to happen locally (bug where game couldn't be run after streamreader ran out of things, so we reset it each time)
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            //sets a background for the program
            ImageBrush backBrush = new ImageBrush();
            backBrush.ImageSource = new BitmapImage(new Uri
               ("https://gdurl.com/DKoV"));
            myCanvas.Background = backBrush;

            MessageBox.Show("Welcome to hangman. " + '\r' + '\r' + "Your goal is to save the man by guessing the correct word" + '\r' + "before he is hanged." + '\r' + '\r' +
                "Once you have fully revealed the word," + '\r' + "type it into the Guess box to save him and play again.");
            SetWordMethod();
        }

        private void CreateLabel(int i, string content)
        {
            Label myLabel = new Label();
            myLabel.Content = content;
            //Canvas.SetTop(myLabel, 92);
            Canvas.SetLeft(myLabel, (i * 10));
//*Change: added another canvas to confine the guess display - can be cleared
            cvsGuess.Children.Add(myLabel);
        }

        /*private void btnSetWord_Click(object sender, RoutedEventArgs e)
        {
            SetWordMethod();
        }*/ //custom words

        private void SetWordMethod()
        {
            StreamReader streamreader = new StreamReader("List.txt");
            //tempWord = txtTemp.Text; //custom words

            //*change: moved string tempWord to global, so we can check if correct later.

            //sets random number
            int randomNumber = random.Next(1, 9);
            //MessageBox.Show(randomNumber.ToString()); //troubleshooting

            //reads lines rom txt file to set word
            for (int i = 0; i < randomNumber + 1; i++)
            {
                string line = streamreader.ReadLine();
                if (i == randomNumber)
                {
                    tempWord = line;
                }
            }
            streamreader.Close();
            //MessageBox.Show(tempWord); //troubleshooting

            //add to array
            for (int i = 0; i < tempWord.Length; i++)
            {
                goals[i] = tempWord.Substring(i, 1);
                //MessageBox.Show(goals[i]); //troubleshooting
            }

            //add underlines to UI
            for (int i = 0; i < tempWord.Length; i++)
            {
                CreateLabel(i, "_");
            }
            //txtTemp.Text = ""; //custom words
            //MessageBox.Show("word set"); //troubleshooting
        }

        private void btnGuessLetter_Click(object sender, RoutedEventArgs e)
        {
            string tempLetter = txtLetterInput.Text;
            //MessageBox.Show("letter: " + tempLetter); //troubleshooting
            if (tempLetter.Length == 1)
            {
                lblGuessed.Content += tempLetter + ", ";
            }
            //*change: created an extra if statement to add to lblguessed

            // if statements decides if it is a word guess or a letter guess, then check if it's right
            if (tempLetter.Length == 1)
            {
                bool correct = false;
                for (int i = 0; i < 9; i++)
                {
                    if (tempLetter == goals[i])
                    {
                        guessed[i] = tempLetter;
                        CreateLabel(i, tempLetter);
                        correct = true;
                    }
                }
                if (correct == false)
                {
                    lives--;
                }
            }
            else if (tempLetter.Length != 1)
            {
                if (tempLetter == tempWord)
                {
                    MessageBox.Show("You did it!");
                    Reset(sender, e);
                }
                else
                {
                    lives--;
                }
            }

            //runs an action based on remaining lives
            CheckLives(sender, e);
        }

        private void CheckLives(object sender, RoutedEventArgs e)
        {
            if (lives == 0)
            {
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri
                   ("https://images.vexels.com/media/users/3/130785/isolated/lists/27a5763da4867b9f576557a11b9f8f8d-halloween-skull-cartoon-3.png"));
                life0.Fill = imgBrush;
                MessageBox.Show("You failed.");
                Reset(sender, e);
            }

            else if (lives == 1)
            {
                life5.Visibility = Visibility.Visible;
            }

            else if (lives == 2)
            {
                life4.Visibility = Visibility.Visible;
            }

            else if (lives == 3)
            {
                life3.Visibility = Visibility.Visible;
            }

            else if (lives == 4)
            {
                life2.Visibility = Visibility.Visible;
            }

            else if (lives == 5)
            {
                life1.Visibility = Visibility.Visible;
            }

            else if (lives == 6)
            {
                life0.Visibility = Visibility.Visible;
            }
            txtLetterInput.Text = "";
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            //txtTemp.Text = ""; //custom words
            txtLetterInput.Text = "";
            lives = 7;
            //btnSetWord_Click(sender, e); //custom words
            life0.Visibility = Visibility.Hidden;
            life0.Fill = Brushes.Black;
            life1.Visibility = Visibility.Hidden;
            life2.Visibility = Visibility.Hidden;
            life3.Visibility = Visibility.Hidden;
            life4.Visibility = Visibility.Hidden;
            life5.Visibility = Visibility.Hidden;
            lblGuessed.Content = "Guessed Letters: ";
            cvsGuess.Children.Clear();
            for (int i = 0; i < 9; i++)
            {
                guessed[i] = "";
                goals[i] = "";
            }
            SetWordMethod();
        }
    }
}
