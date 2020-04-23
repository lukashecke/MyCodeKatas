using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04_DataMunging.DTOs
{
    class WeatherDTO
    {
        public List<WeatherDayInfoDTO> Weather { get; private set; }
        public WeatherDTO(DatReader datReader)
        {
            Weather = GetWeatherDayInfoDTOs(datReader);
        }

        internal void ShowDayWithSmallestTemperatureSpread()
        {
            int day = 0;
            int min = int.MaxValue;
            foreach (WeatherDayInfoDTO weatherDayInfoDTO in this.Weather)
            {
                if (Math.Abs(weatherDayInfoDTO.MaxTemp - weatherDayInfoDTO.MinTemp) < min)
                {
                    min = Math.Abs(weatherDayInfoDTO.MaxTemp - weatherDayInfoDTO.MinTemp);
                    day = weatherDayInfoDTO.Day;
                }
            }
            Console.WriteLine($"Day {day} has the smallest temperature spread.");
        }

        private List<WeatherDayInfoDTO> GetWeatherDayInfoDTOs(DatReader datReader)
        {
            List<WeatherDayInfoDTO> weatherDayInfoDTOs = new List<WeatherDayInfoDTO>();
            foreach (string line in datReader.FileTextLines)
            {
                WeatherDayInfoDTO weatherDayInfoDTO = new WeatherDayInfoDTO(line);
                if (weatherDayInfoDTO.Day != 0)
                {
                    weatherDayInfoDTOs.Add(weatherDayInfoDTO);
                }
            }
            return weatherDayInfoDTOs;
        }
    }
}
