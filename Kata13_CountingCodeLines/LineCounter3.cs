using Kata13_CountingCodeLines.Language_specifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines
{
    public class LineCounter3
    {
        /// <summary>
        /// This flags indicates if a line starts, ends , or is a multiline comment.
        /// </summary>
        private bool multilineComment = false;
        public int linesOfCode = 0;
        public LineCounter3(string path)
        {
            if (ValidatePath(path))
            {
                List<string> javaFilePaths = GetAllFilePaths<JavaFile>(path);
                linesOfCode = GetAmountOfCodeLines<JavaFile>(javaFilePaths);
                Console.WriteLine($"{linesOfCode} code lines found.");
            }
            else
            {
                Console.WriteLine("No valid path!");
            }
        }

        /// <summary>
        /// T can be instantiated to get the LanguageSpecifications of the child from ILanguageFile.
        /// <para>Step One: Remove all "real" strings (that are not inside a multiline command) so /* inside them cannot trigger a false handeling.</para>
        /// <para>Step Two: Remove all multiline commands so the handeling of the codeline counting is as easy as possible.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="javaFilePaths"></param>
        /// <returns></returns>
        public int GetAmountOfCodeLines<T>(List<string> javaFilePaths) where T : ILanguageFile, new()
        {
            T languageSpecifications = new T();
            int counter = 0;
            foreach (string file in javaFilePaths)
            {
                string fileText = File.ReadAllText(file);
                string clearedFileText = languageSpecifications.RomoveMultiLineComments(fileText);
                clearedFileText = languageSpecifications.RemoveSingleLineComments(clearedFileText);
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