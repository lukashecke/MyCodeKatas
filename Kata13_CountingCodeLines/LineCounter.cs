using Kata13_CountingCodeLines.Language_specifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines
{
    public class LineCounter
    {
        /// <summary>
        /// This flags indicates if a line starts, ends , or is a multiline comment.
        /// </summary>
        private bool multilineComment = false;
        public int totalLinesOfCode = 0;
        public LineCounter(string path)
        {
            if (ValidatePath(path))
            {
                Console.WriteLine("Please wait, while counting...");
                List<string> javaFilePaths = GetAllFilePaths<JavaFile>(path);
                int javaLinesOfCode = GetAmountOfCodeLines<JavaFile>(javaFilePaths);
                totalLinesOfCode += javaLinesOfCode;

                List<string> csharpFilePaths = GetAllFilePaths<CSharpFile>(path);
                int csharpLinesOfCode = GetAmountOfCodeLines<CSharpFile>(csharpFilePaths);
                totalLinesOfCode += csharpLinesOfCode;

                Console.WriteLine($"Found {totalLinesOfCode} lines of code:");
                Console.WriteLine($"Java:\t{javaLinesOfCode}");
                Console.WriteLine($"C#:\t{csharpLinesOfCode}");
            }
            else
            {
                Console.WriteLine("No valid path!");
            }
        }

        /// <summary>
        /// T can be instantiated to get the LanguageSpecifications of the child from ILanguageFile.
        /// <para>Step One: Removes all multiline commands. Comment sequences are ignored inside of strings.</para>
        /// <para>Step Two: Removes all singleline commands.</para>
        /// <para>Step Three: Removes all documentation comments.</para>
        /// <para>Step Four: Counts all the not-empty lines.</para>
        /// </summary>
        /// <typeparam name="T">Child of ILanguageFile which gives the sntax ruling of a language.</typeparam>
        /// <param name="sourceCodeFilePaths">File paths to the delivered language specification.</param>
        /// <returns></returns>
        public int GetAmountOfCodeLines<T>(List<string> sourceCodeFilePaths) where T : ILanguageFile, new()
        {
            T languageSpecifications = new T();
            int counter = 0;
            foreach (string file in sourceCodeFilePaths)
            {
                Console.WriteLine(file);
                string fileText = File.ReadAllText(file);
                string clearedFileText = languageSpecifications.RomoveMultiLineComments(fileText);
                clearedFileText = languageSpecifications.RemoveSingleLineComments(clearedFileText);
                clearedFileText = languageSpecifications.RemoveDocumentationComments(clearedFileText);
                var lines = clearedFileText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        counter++;
                    }
                }
            }
            return counter;

        }
        // TODO: Anschauen! evtl. auch hier Factory einbauen
        // IAbrechner abrechner = Abrechnerfactory.GetInstance().CreateAbrechner(patientenDTO); // Singleton

        /// <summary>
        /// T can be instantiated to get the LanguageSpecifications of the child from ILanguageFile.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string> GetAllFilePaths<T>(string path) where T : ILanguageFile, new()
        {
            string fileExtensioin = new T().Extension;
            List<string> filePaths = new List<string>();
            try
            {
                filePaths = Directory.GetFiles(path, $"*{fileExtensioin}", SearchOption.AllDirectories).ToList();
            }
            catch (System.IO.IOException) // it is a single file
            {
                if (Path.GetExtension(path).TrimEnd().Equals(fileExtensioin))
                {
                    filePaths.Add(path);
                }
            }
            return filePaths;
        }
        /// <summary>
        /// Standart validation for either a valid file- or directorypath.
        /// </summary>
        /// <param name="path">File or Directory</param>
        /// <returns>"Path not found!" if either file or directory exists.</returns>
        private bool ValidatePath(string path)
        {
            if (!File.Exists(path) && !Directory.Exists(path))
            {
                Console.WriteLine("Path not found!");
                return false;
            }
            return true;
        }
    }
}