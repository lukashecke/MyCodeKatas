using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04_DataMunging
{
    class WeatherDTO
    {
        public List<WeatherDayInfoDTO> Weather { get; private set; }
        public WeatherDTO(DatReader datReader)
        {
            Weather = GetWeatherDayInfoDTOs(datReader);
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
