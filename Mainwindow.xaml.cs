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
        string[] goals = new string[9];
        string[] guessed = new string[9];
        //StreamReader streamreader = new StreamReader("https://raw.githubusercontent.com/MysticalWarrior/u3AidanMHangman/master/list.txt");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateLabel(int i, string content)
        {
            Label myLabel = new Label();
            myLabel.Content = content;
            Canvas.SetTop(myLabel, 92);
            Canvas.SetLeft(myLabel, (235 + (i * 10)));
            myCanvas.Children.Add(myLabel);
        }

        private void btnSetWord_Click(object sender, RoutedEventArgs e)
        {
            string tempWord = "sebisbad"; //streamreader.ReadLine();
            //MessageBox.Show(tempWord);

            //add to array
            for (int i = 0; i < tempWord.Length; i++)
            {
                goals[i] = tempWord.Substring(i, 1);
                //MessageBox.Show(goals[i]);
            }

            //add underlines
            lblUnderlines.Content = "";
            for (int i = 0; i < tempWord.Length; i++)
            {
                CreateLabel(i, "_");
            }
            MessageBox.Show("word set");
        }

        private void btnGuessLetter_Click(object sender, RoutedEventArgs e)
        {
            string tempLetter = txtLetterInput.Text;
            MessageBox.Show("letter: " + tempLetter);
            for (int i = 0; i < 9; i++)
            {
                if (tempLetter == goals[i])
                {
                    guessed[i] = tempLetter;
                    CreateLabel(i, tempLetter);
                }
            }
        }
    }
}
