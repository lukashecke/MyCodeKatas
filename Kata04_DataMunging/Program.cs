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
            DatReader datReader = new DatReader("weather.dat");
            WeatherDTO morristownWeather = new WeatherDTO(datReader);
            morristownWeather.ShowDayWithSmallestTemperatureSpread();
            datReader = new DatReader("football.dat");
            FootballDTO premierLeagueResults = new FootballDTO(datReader);
            premierLeagueResults.ShowTeamWithSmallestGoalDifference();
            Console.ReadKey();
        }
    }
}
