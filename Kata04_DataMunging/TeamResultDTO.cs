using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata04_DataMunging
{
    class TeamResultDTO
    {
        public string Teamname { get; private set; }
        public int GoalsFor { get; private set; }
        public int GoalsAgainst { get; private set; }
        public TeamResultDTO(string line)
        {
            GetData(line);
        }

        private void GetData(string line)
        {
            if (!string.IsNullOrWhiteSpace(line.Replace("-", " "))) // Filteing "the line"
            {
                line = Regex.Replace(line, " +", " ");
                string[] splittedLine = line.Split(' ');
                if (splittedLine.Length>=10) // Filtering Header
                {
                    Teamname = splittedLine[2];
                    int goalsFor;
                    Int32.TryParse(splittedLine[7], out goalsFor);
                    GoalsFor = goalsFor;
                    int goalsAgainst;
                    Int32.TryParse(splittedLine[9], out goalsAgainst);
                    GoalsAgainst = goalsAgainst;
                }
            }
        }
    }
}
