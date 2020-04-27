using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata04_DataMunging.DTOs
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
                if (splittedLine[1]!="Team") // Filtering Header
                {
                    Teamname = splittedLine[2];
                    int.TryParse(splittedLine[7], out int goalsFor);
                    GoalsFor = goalsFor;
                    int.TryParse(splittedLine[9], out int goalsAgainst);
                    GoalsAgainst = goalsAgainst;
                }
            }
        }
    }
}
