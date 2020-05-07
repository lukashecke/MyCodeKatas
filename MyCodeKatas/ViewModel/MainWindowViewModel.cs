using Microsoft.Win32;
using Model.MyCodeKatas;
using MyCodeKatas.Commands;
using MyCodeKatas.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Input;

namespace MyCodeKatas.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly string localRootPath = @"C:\Users\hecke\source\repos\lukashecke\MyCodeKatas"; // private
        private readonly string alternativeRootPath = @"C:\Users\l.hecke\source\repos\lukashecke\MyCodeKatas"; // work
        #region commands
        public ICommand WebsiteCommand { get; set; }
        public ICommand ProgramCommand { get; set; }
        public ICommand SolutionCommand { get; set; }
        public ICommand ExportCommand { get; set; }
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
            ExportCommand = new RelayCommand(ExecuteExportCommand, CanExecuteExportCommand);
        }

        private bool CanExecuteExportCommand(object arg)
        {
            return Directory.Exists(localRootPath) || Directory.Exists(alternativeRootPath);
        }

        private void ExecuteExportCommand(object obj)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = "CodeKatas_Projektmappe",
                Filter = "Zip file(*.zip)| *.zip "
            };
            if (saveFileDialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                try
                {
                    if (Directory.Exists(localRootPath))
                    {
                        ZipFile.CreateFromDirectory(localRootPath, saveFileDialog.FileName);
                    }
                    else if (Directory.Exists(alternativeRootPath))
                    {
                        ZipFile.CreateFromDirectory(alternativeRootPath, saveFileDialog.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Dateien konnten nicht gefunden werden.", "Nicht gefunden");
                    }
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Datei wir bereits von einem anderen Programm benutzt.", "Fehler!");
                    File.Delete(saveFileDialog.FileName); // Deletes the incomplete "zip-directory" which is created up to the blocked file
                }
            }



            //Decrypter decrypter = new Decrypter();
            //string fileText = decrypter.DecryptFile(UserData.bookingFilePath);
            //SaveFileDialog saveFileDialog = new SaveFileDialog
            //{
            //    FileName = "Buchungszeiten",
            //    Filter = "XML file(*.xml)| *.xml | Text file (*.txt)|*.txt"
            //};
            //// saveFileDialog.ShowDialog(); // unneccessary, shows automatically
            //if (saveFileDialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            //{
            //    File.WriteAllText(Path.GetFullPath(saveFileDialog.FileName), fileText);
            //}
        }

        private void InitializeKatas()
        {
            Katas.Add(new Kata()
            {
                Name = "Kata01: Supermarket Pricing",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = false
            }); // 01
            Katas.Add(new Kata()
            {
                Name = "Kata02: Karate Chop",
                WorkingState = WorkingState.Closed,
                Note =
                "InconsistentBinarySearch:\n" +
                "Problem: Schleife muss umgekehrt werden um die Abfrage nach der Arrayhalbierung durchführen zu können.\n\n" +
                "IterativeDynamicBinarySearch:\n" +
                "\n\n" +
                "IterativeRangeBinarySearch:\n" +
                "Vorteil: Keine zusätzliche Parameterübergabe benötigt.\n" +
                "Vorteil: Selbe Funktionsweise wie rekursives Gegenstück, jedoch iterativ (sicherer und verständlicher).\n\n" +
                "RecursiveDynamicBinarySearch:\n" +
                "Jedem rekursiven Aufruf wird ein neues halbiertes Array mitgegeben.\n" +
                "Vorteil: \n" +
                "Nachteil: Die Indizes entsprechen nicht mehr dem des Originalarrays. -> IndexOffset muss der Methode mitgegeben werden.\n" +
                "Nachteil: Unnötig jedes mal ein neues Array zu erzeugen (Speicher + Laufzeit).\n\n" +
                "RecursiveRangeBinarySearch:\n" +
                "Jedem rekursiven Aufruf wirden Suchbegrenzungen für das Array mitgegeben.\n" +
                "Vorteil: Speicherfreundlich und Abbruchbedingung kann einfach über die Suchbegrenzungen geschehen.\n" +
                "Vorteil: Auf schnelligkeit ausgerichtet.\n" +
                "Nachteil: Die Mitte ist bei geraden (Sub)Arrays immer +-1. -> Die Übergebenen Suchbegrenzungsindezes müssen dass unbeachtete Element mit -+1 wieder greifen.\n\n" +
                "SyntacticSugarBinarySearch:\n" +
                "Vorteil: Gut zu lesen mit minimal längerer Laufzeit als RecursiveRange-Variante.", // TODO: Kata 2 Notes
                CodingInvolved = true
            }); // 02
            Katas.Add(new Kata()
            {
                Name = "Kata03: How Big? How Fast?",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = false
            }); // 03
            Katas.Add(new Kata()
            {
                Name = "Kata04: Data Munging",
                WorkingState = WorkingState.Closed,
                Note =
                "", // TODO: Kata 4 Notes
                CodingInvolved = true
            }); // 04
            Katas.Add(new Kata()
            {
                Name = "Kata05: Bloom Filters",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = true
            }); // 05
            Katas.Add(new Kata()
            {
                Name = "Kata06: Anagrams",
                WorkingState = WorkingState.Resolved,
                Note =
                "", // TODO: Kata 6 Notes
                CodingInvolved = true
            }); // 06
            Katas.Add(new Kata()
            {
                Name = "Kata07: How'd I Do?",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved=false
        }); // 07
            Katas.Add(new Kata()
            {
                Name = "Kata08: Conflicting Objectives",
                WorkingState = WorkingState.Active,
                Note =
                "Gute Namen für Variablen, Eigenschaften, Methode, usw. sind sehr wichtig und verbessern die Lesbarkeit des Quelltextes enorm.\n" +
                "Wenn mit großen Mengen an Daten gearbeitet werden soll, ist es von essentieller Bedeutung diese für ihre Verwendung spezifisch zu Filtern, bzw. oft verwendete Inhalte einmal vorab zu laden.", // TODO: Kata 8 Notes
                CodingInvolved = true
            }); // 08
            Katas.Add(new Kata()
            {
                Name = "Kata09: Back to the Checkout",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = true
            }); // 09
            Katas.Add(new Kata()
            {
                Name = "Kata10: Hashes vs. Classes",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = false
            }); // 10
            Katas.Add(new Kata()
            {
                Name = "Kata11: Sorting It Out",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = true
            }); // 11
            Katas.Add(new Kata()
            {
                Name = "Kata12: Best Sellers",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = false
            }); // 12
            Katas.Add(new Kata()
            {
                Name = "Kata13: Counting Code Lines",
                WorkingState = WorkingState.Resolved,
                Note =
                "", // TODO: Kata 13 Notes
                CodingInvolved = true
            }); // 13
            Katas.Add(new Kata()
            {
                Name = "Kata14: Tom Swift Under the Milkwood",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = true
            }); // 14
            Katas.Add(new Kata()
            {
                Name = "Kata15: A Diversion",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = false
            }); // 15
            Katas.Add(new Kata()
            {
                Name = "Kata16: Business Rules",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = false
            }); // 16
            Katas.Add(new Kata()
            {
                Name = "Kata17: More Business Rules",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = false
            }); // 17
            Katas.Add(new Kata()
            {
                Name = "Kata18: Transitive Dependencies",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = true
            }); // 18
            Katas.Add(new Kata()
            {
                Name = "Kata19: Word Chains",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = true
            }); // 19
            Katas.Add(new Kata()
            {
                Name = "Kata20: Klondike",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = true
            }); // 20
            Katas.Add(new Kata()
            {
                Name = "Kata21: Simple Lists",
                WorkingState = WorkingState.New,
                Note =
                "",
                CodingInvolved = true
            }); // 21
        }
        #endregion

        #region executes & canExecutes
        private void ExecuteSolutionCommand(object obj)
        {
            string localSolutionPath = localRootPath + @"\MyCodeKatas.sln";
            string alternativeSolutionPath = alternativeRootPath + @"\MyCodeKatas.sln";
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
                MessageBox.Show("Solution konnte nicht gefunden werden.", "Nicht gefunden");
            }
        }
        private bool CanExecuteSolutionCommand(object arg)
        {
            return Directory.Exists(localRootPath) || Directory.Exists(alternativeRootPath);
        }
        private void ExecuteProgramCommand(object obj)
        {
            if (!Katas.Current.CodingInvolved)
            {
                MessageBox.Show("Dies ist eine reine Denkaufgabe.", "Nope :)");
            }
            else
            {
                switch (Katas.Current.Name)
                {
                    case "Kata02: Karate Chop":
                        // Kata02_KarateChop.Program.Main(null); // Geht so nicht, weil Manager ein WPF und die einzelnen Programme Konsolenprogramme sind
                        Process.Start(new ProcessStartInfo("Kata02_KarateChop.exe"));
                        break;
                    case "Kata04: Data Munging":
                        Process.Start(new ProcessStartInfo("Kata04_DataMunging.exe", "managerStartMode"));
                        break;
                    case "Kata06: Anagrams":
                        Process.Start(new ProcessStartInfo("Kata06_Anagrams.exe", "managerStartMode"));
                        break;
                    case "Kata08: Conflicting Objectives":
                        Process.Start(new ProcessStartInfo("Kata08_ConflictingObjectives.exe", "managerStartMode"));
                        break;
                    case "Kata13: Counting Code Lines":
                        Process.Start(new ProcessStartInfo("Kata13_CountingCodeLines.exe"));
                        break;
                    default:
                        MessageBox.Show("Dieser Code-Kata wurde wahrscheinlich noch nicht bearbeitet.", "Nope :)");
                        break;
                }
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