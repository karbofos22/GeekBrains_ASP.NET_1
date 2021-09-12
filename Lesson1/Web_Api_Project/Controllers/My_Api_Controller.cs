using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class My_Api_Controller : ControllerBase
    {
        private readonly ValuesHolder _holder;

        public My_Api_Controller(ValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost]
        public IActionResult Create([FromQuery] string userInput)
        {
            _holder.Values.Add(userInput);
            return Ok();
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_holder.Get());
        }

        [HttpPut]
        public IActionResult Update([FromQuery] string stringsToUpdate, [FromQuery] string newValue)
        {
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if (_holder.Values[i] == stringsToUpdate)
                    _holder.Values[i] = newValue;
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] string stringsToDelete)
        {
            _holder.Values = _holder.Values.Where(w => w != stringsToDelete).ToList();
            return Ok();
        }

    }
}
