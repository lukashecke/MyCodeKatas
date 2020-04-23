using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata04_DataMunging.DTOs
{
    class WeatherDayInfoDTO
    {
        public int Day { get; private set; }
        public int MaxTemp { get; private set; }
        public int MinTemp { get; private set; }
        public int AverageTemp { get; private set; }
        public WeatherDayInfoDTO(string line)
        {
            GetData(line);
        }

        private void GetData(string line)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                line = Regex.Replace(line," +"," ");
                string[] splittedLine = line.Split(' ');
                int.TryParse(splittedLine[1], out int day);
                Day = day;
                int.TryParse(splittedLine[2].Replace("*", ""), out int max);
                MaxTemp = max;
                int.TryParse(splittedLine[3].Replace("*", ""), out int min);
                MinTemp = min;
                int.TryParse(splittedLine[4], out int avg);
                AverageTemp = avg;
            }
        }
        // Gut als 2. Konstruktor
        //public WeatherDayInfoDTO(int day, int maxTemp, int minTemp, int averageTemp)
        //{
        //    Day = day;
        //    MaxTemp = maxTemp;
        //    MinTemp = minTemp;
        //    AverageTemp = averageTemp;
        //}
    }
}
