using System;
using System.Collections.Generic;
using System.IO;

namespace Web_Api_Project.Controllers
{
    public class ValuesHolder
    {

        public string userInput { get; set;}
        
        public List<string> Values { get; set;} = new List<string>();

        //Возможность сохранить температуру в указанное время
        //Возможность отредактировать показатель температуры в указанное время
        //Возможность удалить показатель температуры в указанный промежуток времени
        //Возможность прочитать список показателей температуры за указанный промежуток времени




        public void SaveData(IEnumerable<WeatherForecast> weatherData)
        {
            string testDataFile = @"E:\testDataFile.txt";

            ValuesHolder testDataHolder = new();

            foreach (var item in weatherData)
            {
                    File.AppendAllText(testDataFile, item.Date.ToString());
            }
        }

        
    }
}