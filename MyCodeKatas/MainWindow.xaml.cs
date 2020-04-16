using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

namespace MyCodeKatas
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        #region MouseDoubleClicks
        private void Kata01_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata02_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata03_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata04_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata05_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata06_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata07_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata08_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata09_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata10_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata11_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata12_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata13_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("Kata13_CountingCodeLines.exe"));
        }
        private void Kata14_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata15_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata16_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata17_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata18_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata19_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata20_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void Kata21_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion

        private void ProgramButton_Click(object sender, RoutedEventArgs e)
        {
            switch (((ListViewItem)PART_ListView.SelectedItem).Content.ToString())
            {
                case "Kata13: Counting Code Lines":
                    Process.Start(new ProcessStartInfo("Kata13_CountingCodeLines.exe"));
                    break;
                default:
                    MessageBox.Show("Dieser Code-Kata wurde wahrscheinlich noch nicht bearbeitet.", "Nope :)");
                    break;
            }
        }
        private void WebsiteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (((ListViewItem)PART_ListView.SelectedItem).Content.ToString())
            {
                case "Kata01: Supermarket Pricing":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata01-supermarket-pricing/"));
                    break;
                case "Kata02: Karate Chop":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata02-karate-chop/"));
                    break;
                case "Kata03: How Big? How Fast?":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata03-how-big-how-fast/"));
                    break;
                case "Kata04: Data Munging":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata04-data-munging/"));
                    break;
                case "Kata05: Bloom Filters":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata05-bloom-filters/"));
                    break;
                case "Kata06: Anagrams":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata06-anagrams/"));
                    break;
                case "Kata07: How’d I Do?":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata07-howd-i-do/"));
                    break;
                case "Kata08: Conflicting Objectives":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata08-conflicting-objectives/"));
                    break;
                case "Kata09: Back to the Checkout":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata09-back-to-the-checkout/"));
                    break;
                case "Kata10: Hashes vs. Classes":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata10-hashes-vs-classes/"));
                    break;
                case "Kata11: Sorting It Out":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata11-sorting-it-out/"));
                    break;
                case "Kata12: Best Sellers":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata12-best-sellers/"));
                    break;
                case "Kata13: Counting Code Lines":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata13-counting-code-lines/"));
                    break;
                case "Kata14: Tom Swift Under the Milkwood":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata14-tom-swift-under-the-milkwood/"));
                    break;
                case "Kata15: A Diversion":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata15-a-diversion/"));
                    break;
                case "Kata16: Business Rules":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata16-business-rules/"));
                    break;
                case "Kata17: More Business Rules":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata17-more-business-rules/"));
                    break;
                case "Kata18: Transitive Dependencies":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata18-transitive-dependencies/"));
                    break;
                case "Kata19: Word Chains":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata19-word-chains/"));
                    break;
                case "Kata20: Klondike":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata20-klondike/"));
                    break;
                case "Kata21: Simple Lists":
                    Process.Start(new ProcessStartInfo("http://codekata.com/kata/kata21-simple-lists/"));
                    break;
                default:
                    MessageBox.Show("Dieser Code-Kata wurde wahrscheinlich noch nicht bearbeitet.", "Nope :)");
                    break;
            }
        }
        private void SolutionButton_Click(object sender, RoutedEventArgs e)
        {
            string localSolutionPath = @"C:\Users\hecke\source\repos\lukashecke\MyCodeKatas\MyCodeKatas.sln";
            if (File.Exists(localSolutionPath))
            {
                Process.Start(new ProcessStartInfo(localSolutionPath));
            }
            else
            {
                MessageBox.Show("Die Projektmappe liegt auf meinem Rechner.\n\nLukas", "Sorry");
            }

        }
        private void PART_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PART_WebsiteButton.IsEnabled = true;
            PART_ProgramButton.IsEnabled = true;
        }
    }
}
