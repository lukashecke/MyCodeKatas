using System;
using System.Collections.Generic;

namespace Kata04_DataMunging.DTOs
{
    internal class FootballDTO
    {
        public List<TeamResultDTO> Results { get; private set; }

        public FootballDTO(DatReader datReader)
        {
            Results = GetTeamResultDTOs(datReader);
        }

        private List<TeamResultDTO> GetTeamResultDTOs(DatReader datReader)
        {
            List<TeamResultDTO> teamResultDTOs = new List<TeamResultDTO>();
            foreach (string line in datReader.FileTextLines)
            {
                TeamResultDTO teamResultDTO = new TeamResultDTO(line);
                if (!string.IsNullOrWhiteSpace(teamResultDTO.Teamname))
                {
                    teamResultDTOs.Add(teamResultDTO);
                }
            }
            return teamResultDTOs;
        }

        internal void ShowTeamWithSmallestGoalDifference()
        {
            string team = string.Empty;
            int min = int.MaxValue;
            foreach (TeamResultDTO teamResultDTO in this.Results)
            {
                if (Math.Abs(teamResultDTO.GoalsAgainst - teamResultDTO.GoalsFor) < min)
                {
                    min = Math.Abs(teamResultDTO.GoalsAgainst - teamResultDTO.GoalsFor);
                    team = teamResultDTO.Teamname;
                }
            }
            Console.WriteLine($"{team} has the smallest goal difference.");
        }
    }
}