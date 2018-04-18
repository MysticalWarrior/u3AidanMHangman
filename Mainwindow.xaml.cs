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

        private void btnSetWord_Click(object sender, RoutedEventArgs e)
        {
            string tempWord = "lineage"; //streamreader.ReadLine();
            MessageBox.Show(tempWord);
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
                lblUnderlines.Content += "_ ";
            }
            MessageBox.Show("word set");
        }

        private void btnGuessLetter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
