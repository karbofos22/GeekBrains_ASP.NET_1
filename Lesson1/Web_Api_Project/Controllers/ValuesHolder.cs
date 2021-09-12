using System;
using System.Collections.Generic;
using System.IO;

namespace Web_Api_Project.Controllers
{
    public class ValuesHolder
    {

        public string userInput { get; set;}
        
        public List<string> Values { get; set;} = new List<string>();

        public object Get()
        {
            return Values;
        }
    }
}