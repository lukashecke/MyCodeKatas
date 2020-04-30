using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines.Language_specifications
{
    public class JavaFile : ILanguageFile
    {
        public string Extension => ".java";
        public string StringDefinition => "\"(.*?)([^\\\\\\\"])\"";
       
        // TODO: Remember when writing C#-File specificatins, "//" filters Documentation comments, too
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
                if (arr.Length == 0)
                {
                    wentThrough = true;
                }
            }
            return clearedFileText;
        }
        /// <summary>
        /// In Java the documentation commentaries are equal to the multiline comments so they don't need to be handled seperately anymore.
        /// </summary>
        /// <param name="fileText"></param>
        /// <returns></returns>
        public string RemoveDocumentationComments(string fileText)
        {
            return fileText;
        }
    }
}
