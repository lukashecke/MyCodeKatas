﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines
{
    /// <summary>
    /// Only support C# and Java so far.
    /// </summary>
    class LineCounter
    {
        #region properties/ entities
        private string Path { get; set; }
        private int AmountOfJavaCodeLines { get; set; }
        private int AmountOfCsCodeLines { get; set; }

        private List<string> javaFilePaths;
        public List<string> JavaFilePaths
        {
            get
            {
                if (this.javaFilePaths == null)
                {
                    this.javaFilePaths = new List<string>();
                }
                return this.javaFilePaths;
            }
            set
            {
                this.javaFilePaths = value;
            }
        }
        private List<string> csFilePaths;
        public List<string> CsFilePaths
        {
            get
            {
                if (this.csFilePaths == null)
                {
                    this.csFilePaths = new List<string>();
                }
                return this.csFilePaths;
            }
            set
            {
                this.csFilePaths = value;
            }
        }
        #endregion

        #region constructors
        public LineCounter(string path)
        {
            if (ValidatePath(path))
            {
                GetFilePaths();
                AmountOfJavaCodeLines = CountJavaLines();
                AmountOfCsCodeLines = CountCsLines();
                Console.WriteLine();
                Console.WriteLine($"Der Übergebene Pfad enthät {AmountOfCsCodeLines} Zeilen C# Code.");
                Console.WriteLine($"Der Übergebene Pfad enthät {AmountOfJavaCodeLines} Zeilen Java Code.");
            }
        }
        #endregion

        #region counting lines functions
        // counting lines functions can be mainly copy pasted for further programming languages
        // but keep in mind, that syntax definition can differ between them
        private int CountCsLines()
        {
            foreach (string filePath in CsFilePaths)
            {
                string[] lines = File.ReadAllLines(filePath);
                string[] linesWithoutComments = new string[lines.Length];
                linesWithoutComments = RemoveMultiLineComments(lines); // Has to be done first because multiline-comments are stronger then one line comments
                linesWithoutComments = RemoveSingleLineComments(linesWithoutComments);
                foreach (string line in linesWithoutComments)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        AmountOfCsCodeLines++;
                    }
                }
            }
            return AmountOfCsCodeLines;
        }
        private int CountJavaLines()
        {
            foreach (string filePath in JavaFilePaths)
            {
                string[] lines = File.ReadAllLines(filePath);
                string[] clearLines = new string[lines.Length];
                clearLines = RemoveMultiLineComments(lines); // Has to be done first because multiline-comments are stronger then one line comments
                clearLines = RemoveSingleLineComments(clearLines);
                foreach (string line in clearLines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        AmountOfJavaCodeLines++;
                    }
                }
            }
            return AmountOfJavaCodeLines;
        }
        #endregion

        #region string manipulation functions
        // TODO: Methode übersichtlicher aufbauen/ schreiben. 
        /// <summary>
        /// <para>Removes all multiline-comments. On one line, over multiple lines and mixtures of both.</para>
        /// Important: Has to be done before the removal of the singleline comments! (due to syntax evaluation order)
        /// </summary>
        /// <param name="clearLines"></param>
        /// <returns></returns>
        private string[] RemoveMultiLineComments(string[] clearLines)
        {
            List<string> linesWithoutComments = new List<string>();
            bool multiLineComment = false;
            foreach (string line in clearLines)
            {
                if (multiLineComment) // Multiline comment line
                {
                    int multiLineCommentEndIndex = line.IndexOf("*/");
                    if (multiLineCommentEndIndex != -1) // Multiline comment ends in this line
                    {
                        multiLineComment = false;
                        string line2 = line.Remove(0, multiLineCommentEndIndex + 2);

                        linesWithoutComments.Add(RemoveInLineMultiLineComments(line2));
                    }
                    else
                    {
                        linesWithoutComments.Add(string.Empty);
                    }
                }
                else
                {
                    int multiLineCommentStartIndex = line.IndexOf("/*");
                    int multiLineCommentEndIndex = line.IndexOf("*/");
                    // Multiline comment in one line
                    if (multiLineCommentStartIndex != -1 && multiLineCommentEndIndex != -1 && !multiLineComment)
                    {
                        string clearedLine = RemoveInLineMultiLineComments(line);
                        multiLineCommentStartIndex = clearedLine.IndexOf("/*");
                        if (multiLineCommentStartIndex != -1 && !multiLineComment && !CommentStartInsideAString(clearedLine))
                        {
                            multiLineComment = true;
                            linesWithoutComments.Add(clearedLine.Remove(multiLineCommentStartIndex));
                        }
                        linesWithoutComments.Add(clearedLine);
                    }
                    // Multiline comment begins in this line
                     else if (multiLineCommentStartIndex != -1 && !multiLineComment && !CommentStartInsideAString(line))
                    {
                        multiLineComment = true;
                        linesWithoutComments.Add(line.Remove(multiLineCommentStartIndex));
                    }
                    else
                    {
                        linesWithoutComments.Add(line);
                    }
                }
            }
            return linesWithoutComments.ToArray();
        }

        /// <summary>
        /// Removes in-line multiline comments (one per loop-iteration) while there are no one left.
        /// Example: ("/*foo*/something/*bar*/" -> "something")
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string RemoveInLineMultiLineComments(string line)
        {
            string s = line;
            int multiLineCommentStartIndex = line.IndexOf("/*");
            int multiLineCommentEndIndex = line.IndexOf("*/");
            while (multiLineCommentStartIndex != -1 && multiLineCommentEndIndex != -1)
            {
                s = s.Remove(multiLineCommentStartIndex, ((multiLineCommentEndIndex - multiLineCommentStartIndex) + 2));
                multiLineCommentStartIndex = s.IndexOf("/*");
                multiLineCommentEndIndex = s.IndexOf("*/");
            }
            return s;
        }
        /// <summary>
        /// <para>Removes "//" plus everything behind per line.</para>
        /// Important: Has to be done after the removal of the multiline comments! (due to syntax evaluation order)
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private string[] RemoveSingleLineComments(string[] lines)
        {
            List<string> linesWithoutComments = new List<string>();
            foreach (string line in lines)
            {
                int inlineCommentIndex = line.IndexOf("//");
                if (inlineCommentIndex >= 0 && !CommentStartInsideAString(line)) // inlineCommentIndex = -1 if no comment found 
                {
                    linesWithoutComments.Add(line.Remove(inlineCommentIndex));
                }
                else // no comment found
                {
                    linesWithoutComments.Add(line);
                }
            }
            return linesWithoutComments.ToArray();
        }
        /// <summary>
        /// <para>Checks if the comment-starting sequence occurs inside of a string.</para>
        /// Explanation:
        /// "/*" and  "//" are valid comment-start-sequences just in case they are not a part of a string (within a "...").
        /// However a comment-end-sequence ("*/") is valid even inside of a string.
        /// </summary>
        /// <param name="line">The line has to be cleared already of all other comments like a single line comment (//...) and one or more multiline comments that can occur in the same line aswell ("/*...*/").</param>
        /// <returns>If valid comment start sequence.</returns>
        private bool CommentStartInsideAString(string line)
        {
            string lineWithoutStrings = Regex.Replace(line, "\".*?\"", ""); // Remove all strings and ckecks if any start comment sequences left
            if (lineWithoutStrings.Contains("//") || lineWithoutStrings.Contains("/*"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region IO functions
        private void GetFilePaths() // TODO: Verknüpfungen zu Dateien oder Ordnern können noch nicht ausgelesen werden, und werden momentan noch ignoriert
        {
            if (File.Exists(Path))
            {
                switch (System.IO.Path.GetExtension(Path))
                {
                    case ".java":
                        JavaFilePaths.Add(Path);
                        break;
                    case ".cs":
                        CsFilePaths.Add(Path);
                        break;
                    default:
                        break;
                }
            }
            else if (Directory.Exists(Path))
            {
                string[] filePaths = Directory.GetFiles(Path, "*.java", SearchOption.AllDirectories);
                foreach (string filePath in filePaths)
                {
                    JavaFilePaths.Add(filePath);
                }
                filePaths = Directory.GetFiles(Path, "*.cs", SearchOption.AllDirectories);
                foreach (string filePath in filePaths)
                {
                    CsFilePaths.Add(filePath);
                }
            }
        }
        private bool ValidatePath(string path)
        {
            if (!File.Exists(path) && !Directory.Exists(path))
            {
                Console.WriteLine("Invalid path!");
                return false;
            }
            Path = path;
            return true;
        }
        #endregion
    }
}
