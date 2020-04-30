using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines.Language_specifications
{
    class JavaFile : ILanguageFile
    {
        public string Extension => ".java";
        public string StringDefinition => "\"(.*?)([^\\\\\\\"])\"";
        // TODO: After testing, write Unit Tests instead of the cases on the test files

        public bool IsLineOfCode(string line, bool multilineComment)
        {
            if (!multilineComment)
            {
                line = RomoveInLineComments(line);
            }

            if (IsCommentLine(line) || multilineComment || string.IsNullOrWhiteSpace(line))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsMultilineCommentEndLine(string line)
        {
            if (line.Contains("*/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsMultilineCommentStartLine(string line)
        {

            if (line.Contains("/*"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // TODO: Remember when writing C#-File specificatins, "//" filters Documentation comments, too
        public bool IsCommentLine(string line)
        {
            if (IsMultilineCommentEndLine(line)) // check the code behind the multiline comment ending
            {
                string cleanedLine = line.Substring(line.IndexOf("*/") + 2);
                if (string.IsNullOrWhiteSpace(cleanedLine))
                {
                    return true;
                }
                else
                {
                    return IsLineOfCode(cleanedLine, false);
                }
            }
            if (line.StartsWith("//") || line.StartsWith("/*"))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public string RomoveInLineComments(string line)
        {
            int commentStartIndex = line.IndexOf("/*");
            int commentEndIndex = line.IndexOf("*/");
            while (commentStartIndex != -1 && commentEndIndex != -1) // a sequence of /*...*/ still exists
            {
                line = line.Remove(commentStartIndex, commentEndIndex - commentStartIndex + 2);
                commentStartIndex = line.IndexOf("/*");
                commentEndIndex = line.IndexOf("*/");
            }
            return line;
        }

        public string ClearLine(string line)
        {
            throw new NotImplementedException();
        }

        public string RomoveMultiLineComments(string fileText)
        {
            var arr = fileText.ToCharArray();
            string clearedFileText = fileText;
            bool insideMultilineComment = false;
            bool insideString = false;
            int startCommentIndex = -1;
            int endCommentIndex = -1;
            bool commandFound = false;
            bool wentThrough = false;
            while (!wentThrough)
            {
                for (int i = 0; i < arr.Count(); i++)
                {
                    char currentChar = arr[i];
                    if (!insideString && !insideMultilineComment && currentChar == '"')
                    {
                        insideString = true;
                        continue;
                    }
                    else if (!insideMultilineComment && !insideString && currentChar == '/' && arr[i + 1] == '*')// counteracting nesting of multiline comments with !insideMultilineComment
                    {
                        startCommentIndex = i;
                        insideMultilineComment = true;
                        continue;
                    }
                    if (insideString)
                    {
                        if (currentChar == '\\') // escapingsequence found and skip the next characte so " in \" will not falsely be interprated as the ending of the current string
                        {
                            i += 1;
                            continue;
                        }

                        if (currentChar == '\"')
                        {
                            insideString = false;
                            continue;
                        }
                    }
                    if (insideMultilineComment)
                    {
                        if (currentChar.Equals('*') && arr[i + 1].Equals('/'))
                        {
                            insideMultilineComment = false;
                            endCommentIndex = i;
                            commandFound = true;
                        }
                    }
                    if (commandFound)
                    {
                        clearedFileText = clearedFileText.Remove(startCommentIndex, endCommentIndex - startCommentIndex + 2);
                        arr = clearedFileText.ToCharArray();
                        // Reset searching variables
                        commandFound = false;
                        startCommentIndex = -1;
                        endCommentIndex = -1;
                        break;
                    }
                    if (i == arr.Length - 1)
                    {
                        wentThrough = true;
                    }
                    #region old
                    //if (!insideMultilineComment)
                    //{
                    //    if (arr[i].Equals('/') && arr[i + 1].Equals('*'))
                    //    {
                    //        insideMultilineComment = true;
                    //        startCommentIndex = i;
                    //    }
                    //    else if (arr[i].Equals('"'))
                    //    {
                    //        insideString = true;
                    //    }
                    //}
                    //else // inside multiline comment we are waiting for the end sequence
                    //{
                    //    if (insideString)
                    //    {

                    //    }
                    //    else if (arr[i].Equals('*') && arr[i + 1].Equals('/'))
                    //    {
                    //        insideMultilineComment = false;
                    //        endCommentIndex = i;
                    //        commandFound = true;
                    //    }
                    //}
                    //if (commandFound)
                    //{
                    //    clearedFileText = clearedFileText.Remove(startCommentIndex, endCommentIndex - startCommentIndex + 2);
                    //    arr = clearedFileText.ToCharArray();
                    //    // Reset searching variables
                    //    commandFound = false;
                    //    startCommentIndex = -1;
                    //    endCommentIndex = -1;

                    //    break;
                    //}
                    #endregion
                }
            }
            return clearedFileText;
        }

        public string RemoveSingleLineComments(string fileText)
        {
            var lines = fileText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string clearedLines= string.Empty;
            foreach (string line in lines)
            {
                int commentStartIndex = line.IndexOf("//");
                if (line.IndexOf("//") != -1)
                {
                    clearedLines += line.Substring(0, commentStartIndex)+"\n";
                }
                else
                {
                    clearedLines += line + "\n";
                }
            }
            return clearedLines;
        }
    }
}
