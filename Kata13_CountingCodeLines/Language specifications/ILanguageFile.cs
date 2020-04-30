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

        string RemoveSingleLineComments(string fileText);
        /// <summary>
        /// Removes all multiline comment inside of the source code. 
        /// <para>Attention: Be aware if starting patterns of a multilinecomment should be ignored inside of a string!</para>
        /// </summary>
        /// <param name="fileText"></param>
        /// <returns>Source code without the multiline comments.</returns>
        ///
        string RomoveMultiLineComments(string fileText);
        /// <summary>
        /// Removes all the documentation commentaries inside the source code.
        /// </summary>
        /// <param name="fileText"></param>
        /// <returns></returns>
        string RemoveDocumentationComments(string fileText);
    }
}
