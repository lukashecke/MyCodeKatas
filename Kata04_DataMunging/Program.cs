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
            WeatherDTO weather = new WeatherDTO(datReader);
            int day=0;
            int min = int.MaxValue;
            foreach (WeatherDayInfoDTO weatherDayInfoDTO in weather.Weather)
            {
                if (Math.Abs(weatherDayInfoDTO.MaxTemp-weatherDayInfoDTO.MinTemp)<min)
                {
                    min = Math.Abs(weatherDayInfoDTO.MaxTemp - weatherDayInfoDTO.MinTemp);
                    day = weatherDayInfoDTO.Day;
                }
            }
            Console.WriteLine($"Day {day} has the smallest temperature spread.");
            Console.ReadKey();
        }
    }
}
