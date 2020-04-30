using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata13_CountingCodeLines.Language_specifications
{
    public interface ILanguageFile
    {
        /// <summary>
        /// Extension of the language specific source code.
        /// </summary>
        string Extension { get; }
        /// <summary>
        /// Stringpattern, that defines a string in this language.
        /// </summary>
        string StringDefinition { get; }
        /// <summary>
        /// Checks if a line is a countable line of code.
        /// </summary>
        /// <param name="line">Line without indent of code to be checked.</param>
        /// <param name="insideMultilineComment">Has to be processed from outside in the context of the whole source code.</param>
        /// <returns></returns>
        bool IsLineOfCode(string line, bool multilineComment);
        /// <summary>
        /// Returns true if a multilinecommand is starting in this line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        bool IsMultilineCommentStartLine(string line);
        /// <summary>
        /// Returns true if a multilinecommand is ending in this line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        bool IsMultilineCommentEndLine(string line);
        /// <summary>
        /// Returns if this whoile line is a comment line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        bool IsCommentLine(string line);
        string RemoveSingleLineComments(string fileText);

        /// <summary>
        /// Removes all In Line Commands that are int this line. 
        /// <para>! Be aware if starting patterns of a multilinecomment should be ignored inside of a string!</para>
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        string RomoveInLineComments(string line);
        /// <summary>
        /// Removes the inline commands and all strings for proper multiline command handeling.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        string ClearLine(string line);

        /// <summary>
        /// Removes all multiline comment inside of the source code. 
        /// <para>Attention: Be aware if starting patterns of a multilinecomment should be ignored inside of a string!</para>
        /// </summary>
        /// <param name="fileText"></param>
        /// <returns>Source code without the multiline comments.</returns>
        string RomoveMultiLineComments(string fileText);
    }
}
