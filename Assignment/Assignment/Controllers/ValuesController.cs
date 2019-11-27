using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Data.Contracts;
using Assignment.Data.Domains;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase

    {
       private IFileProcessingRepository repository;
        public ValuesController(IFileProcessingRepository _repository)
        {
            this.repository = _repository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var test= this.repository.GetAll();
            STORE_ORDER obj = new STORE_ORDER();
            string A=null;
            obj.ORDER_DATE = !string.IsNullOrEmpty(A) ? DateTime.ParseExact(A, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null;
            obj.CATEGORY = "A";
            obj.CUSTOMER_ID = "!212";
            obj.CUSTOMER_NAME = "Ravi Kumar";
            obj.DISCOUNT = 1.5m;
            obj.ORDER_DATE = DateTime.Now;
            obj.ORDER_ID = "455";
            obj.PRODUCT_ID = "45645645";
            obj.PROFIT = 10;
            obj.QUANTITY = 1;
            obj.SHIP_DATE = DateTime.Now;
            obj.SHIP_MODE = "Fedex";
            this.repository.Add(obj);
          
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
