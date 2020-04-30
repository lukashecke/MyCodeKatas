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
    public class LineCounter2
    {
        /// <summary>
        /// This flags indicates if a line starts, ends , or is a multiline comment.
        /// </summary>
        private bool multilineComment = false;
        public int linesOfCode = 0;
        public LineCounter2(string path)
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
                // Step One: Remove all "real" strings (that are not inside a multiline command) so /* inside them cannot trigger a false handeling
                // Step Two: Remove all multiline commands so the handeling of the codeline counting is as easy as possible
                string fileText = File.ReadAllText(file);
               // string clearedFileText = languageSpecifications.RomoveInLineComments(fileText);
                //var lines = clearedFileText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            }
            return counter;
            // TODO: @MAW - Nach über 10 Stunden umsetzung der Lösung ohne, bzw. sehr wenig code-entfernung -> Multiline handeling wird zu komplex, weil vor während und nach dem zeilenauslösen prüfungen gemacht werden müssen, das wird teilweise einfach unnötig komplex -> neuer Ansatz alle kommentare entfernen, danach durch den Code gehen
            //T languageSpecifications = new T();
            //int counter = 0;
            //foreach (string file in javaFilePaths)
            //{
            //    var lines = File.ReadAllLines(file);
            //    multilineComment = languageSpecifications.IsMultilineCommentStartLine(lines.First());
            //    foreach (string line in lines)
            //    {
            //        string clearedLine = line.TrimStart();
            //        if (!multilineComment) // counteract nesting
            //        {
            //            // TODO: inline comments and strings heve to be removed in each regular line auch nach dem ende einer multiline commentzeile und die Tests sind noch nicht grün
            //            clearedLine = languageSpecifications.RomoveInLineComments(line.TrimStart());
            //            clearedLine =  Regex.Replace(clearedLine, languageSpecifications.StringDefinition, "");
                        
            //            multilineComment = languageSpecifications.IsMultilineCommentStartLine(clearedLine);
            //        }
            //        else
            //        {

            //        }
            //        if (new T().IsLineOfCode(clearedLine, multilineComment))
            //        {
            //            counter++;
            //        }
            //        if (multilineComment)
            //        {
            //            multilineComment = !languageSpecifications.IsMultilineCommentEndLine(line);
            //        }
            //    }
            //}
            //return counter;
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

        ///// <summary>
        ///// T can be instantiated to get the LanguageSpecifications of the child from ILanguageFile.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="path"></param>
        ///// <returns></returns>
        //private bool IsLineOfCode<T>(string line) where T : ILanguageFile, new()
        //{
        //    return 
        //    throw new NotImplementedException();
        //}
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
