using Kata04_DataMunging.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04_DataMunging
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlPrefix = string.Empty;
            if (args.Length>0 && args[0].Equals("managerStartMode"))
            {
                urlPrefix = AppDomain.CurrentDomain.BaseDirectory.Replace("\\MyCodeKatas\\bin\\Debug\\", "\\Kata04_DataMunging\\bin\\Debug\\");
            }
            DatReader datReader = new DatReader(urlPrefix + "weather.dat");
            WeatherDTO morristownWeather = new WeatherDTO(datReader);
            morristownWeather.ShowDayWithSmallestTemperatureSpread();
            datReader = new DatReader(urlPrefix + "football.dat");
            FootballDTO premierLeagueResults = new FootballDTO(datReader);
            premierLeagueResults.ShowTeamWithSmallestGoalDifference();
            Console.ReadKey();
        }
    }
}
