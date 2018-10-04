using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() =>
            new string[] { "value1", "value2" };

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) => "value";

        [HttpPost]
        public ActionResult<string> Post([FromBody] string value) =>
            value + value;

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}