using Kata13_CountingCodeLines.Language_specifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines
{
    /// <summary>
    /// Get you the approximate lines of code. Ignores special cases such as comment-sequences inside of strings and do not filter them out.
    /// </summary>
    class TurboCounterCSharp
    {
        public int totalLinesOfCode = 0;
        public TurboCounterCSharp(string path)
        {
            if (ValidatePath(path))
            {
                List<string> csharpFilePaths = GetAllFilePaths<CSharpFile>(path);
                int csharpLinesOfCode = GetApproximateAmountOfCodeLines(csharpFilePaths);

                Console.WriteLine();
                Console.WriteLine($"Found {csharpLinesOfCode} lines of C# code:");
            }
            else
            {
                Console.WriteLine("No valid path!");
            }
        }
        /// <summary>
        /// Ignores Strings and mainly deletes comments via Regex.
        /// Removes only multiline comments.
        /// After that it counts the not empty code lines. If they do not start with a //.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceCodeFilePaths"></param>
        /// <returns></returns>
        public int GetApproximateAmountOfCodeLines(List<string> sourceCodeFilePaths)
        {
            int counter = 0;
            foreach (string filePath in sourceCodeFilePaths)
            {
                Console.WriteLine(filePath);
                string fileText = File.ReadAllText(filePath);
                string clearedFileText = Regex.Replace(fileText, "(/\\*)(.*)(\\*/)", "");
                var lines = clearedFileText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.TrimStart().StartsWith("//"))
                    {
                        counter++;
                    }
                }
            }
            return counter;

        }
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
