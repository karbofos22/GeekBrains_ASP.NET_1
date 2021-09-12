using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Web_Api_Project
{
    
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public List<WeatherForecast> Values { get; set; } = new List<WeatherForecast>();

        public override string ToString()
        {
            return $"{Date}\r\n  Temperature: {TemperatureC}\r\n Actual feeling: {Summary}";
        }





        //¬озможность сохранить температуру в указанное врем€
        //¬озможность отредактировать показатель температуры в указанное врем€
        //¬озможность удалить показатель температуры в указанный промежуток времени
        //¬озможность прочитать список показателей температуры за указанный промежуток времени


        public void SaveData(List<WeatherForecast> Values)
        {
            string testDataFile = @"E:\WeatherData.txt";

            foreach (var item in Values)
            {
                File.AppendAllText(testDataFile, item + Environment.NewLine);
            }
        }

        public void EditData(List<WeatherForecast> Values, int tempToUpdate, int newTemp)
        {

            foreach (var item in Values)
            {
                if (item.TemperatureC == tempToUpdate)
                {
                    item.TemperatureC = newTemp;
                    break;
                }
            }
        }
        public void DeleteData(List<WeatherForecast> Values, int tempToDelete)
        {
            foreach (var item in Values)
            {
                if (item.TemperatureC == tempToDelete)
                {
                    item.TemperatureC = 0;
                    break;
                }
            }
        }
    }
}
