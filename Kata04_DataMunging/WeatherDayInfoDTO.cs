using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata04_DataMunging
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
                int day;
                Int32.TryParse(splittedLine[1], out day);
                Day = day;
                int max;
                Int32.TryParse(splittedLine[2].Replace("*", ""), out max);
                MaxTemp = max;
                int min;
                Int32.TryParse(splittedLine[3].Replace("*",""), out min);
                MinTemp = min;
                int avg;
                Int32.TryParse(splittedLine[4], out avg);
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
