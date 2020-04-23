using Model.MyCodeKatas;
using MyCodeKatas.Commands;
using MyCodeKatas.Model;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace MyCodeKatas.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region commands
        public ICommand WebsiteCommand { get; set; }
        public ICommand ProgramCommand { get; set; }
        public ICommand SolutionCommand { get; set; }
        #endregion

        #region entities
        private ObservableCollectionEx<Kata> katas;
        public ObservableCollectionEx<Kata> Katas
        {
            get
            {
                if (katas == null)
                {
                    this.katas = new ObservableCollectionEx<Kata>();
                }
                return this.katas;
            }
            set
            {
                this.katas = value;
                OnPropertyChanged("Katas");
            }
        }
        #endregion

        #region contructors & initializing methods
        public MainWindowViewModel()
        {
            InitializeCommands();
            InitializeKatas();
        }
        private void InitializeCommands()
        {
            WebsiteCommand = new RelayCommand(ExecuteWebsiteCommand, CanExecuteWebsiteCommand);
            ProgramCommand = new RelayCommand(ExecuteProgramCommand, CanExecuteProgramCommand);
            SolutionCommand = new RelayCommand(ExecuteSolutionCommand, CanExecuteSolutionCommand);
        }
        private void InitializeKatas()
        {
            Katas.Add(new Kata() { Name = "Kata01: Supermarket Pricing", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata02: Karate Chop", WorkingState = WorkingState.Active });
            Katas.Add(new Kata() { Name = "Kata03: How Big? How Fast?", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata04: Data Munging", WorkingState = WorkingState.Resolved });
            Katas.Add(new Kata() { Name = "Kata05: Bloom Filters", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata06: Anagrams", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata07: How'd I Do?", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata08: Conflicting Objectives", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata09: Back to the Checkout", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata10: Hashes vs. Classes", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata11: Sorting It Out", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata12: Best Sellers", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata13: Counting Code Lines", WorkingState = WorkingState.Resolved });
            Katas.Add(new Kata() { Name = "Kata14: Tom Swift Under the Milkwood", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata15: A Diversion", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata16: Business Rules", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata17: More Business Rules", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata18: Transitive Dependencies", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata19: Word Chains", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata20: Klondike", WorkingState = WorkingState.New });
            Katas.Add(new Kata() { Name = "Kata21: Simple Lists", WorkingState = WorkingState.New });
        }
        #endregion

        #region executes & canExecutes
        private void ExecuteSolutionCommand(object obj)
        {
            string localSolutionPath = @"C:\Users\hecke\source\repos\lukashecke\MyCodeKatas\MyCodeKatas.sln"; // private
            string alternativeSolutionPath = @"C:\Users\l.hecke\source\repos\lukashecke\MyCodeKatas\MyCodeKatas.sln"; // work
            if (File.Exists(localSolutionPath))
            {
                Process.Start(new ProcessStartInfo(localSolutionPath));
            }
            else if (File.Exists(alternativeSolutionPath))
            {
                Process.Start(new ProcessStartInfo(alternativeSolutionPath));
            }
            else
            {
                MessageBox.Show("Die Projektmappe liegt auf meinem Rechner.\n\nLukas", "Sorry");
            }
        }
        private bool CanExecuteSolutionCommand(object arg)
        {
            return true;
        }
        private void ExecuteProgramCommand(object obj)
        {
            switch (Katas.Current.Name)
            {
                case "Kata02: Karate Chop":
                    Process.Start(new ProcessStartInfo("Kata02_KarateChop.exe"));
                    break;
                case "Kata04: Data Munging":
                    Process.Start(new ProcessStartInfo("Kata04_DataMunging.exe"));
                    break;
                case "Kata13: Counting Code Lines":
                    Process.Start(new ProcessStartInfo("Kata13_CountingCodeLines.exe"));
                    break;
                default:
                    MessageBox.Show("Dieser Code-Kata wurde wahrscheinlich noch nicht bearbeitet.", "Nope :)");
                    break;
            }
        }
        private bool CanExecuteProgramCommand(object arg)
        {
            return Katas.Current != null;
        }
        private void ExecuteWebsiteCommand(object obj)
        {
            switch (Katas.Current.Name)
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
                case "Kata07: How'd I Do?":
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
                    MessageBox.Show("Dieser Code-Kata wurde noch nicht eingerichtet.", "Nope :)");
                    break;
            }
        }
        private bool CanExecuteWebsiteCommand(object arg)
        {
            return Katas.Current != null;
        }
        #endregion
    }
}