using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Assignment.Contracts;
using Assignment.Data.Contracts;
using Assignment.Data.Domains;
using Assignment.FileManagers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {


        private IFileProcessingRepository repository;
        private IHostingEnvironment hostingEnvironment;
        public AssignmentController(IFileProcessingRepository _repository, IHostingEnvironment _hostingEnvironment)
        {
            this.repository = _repository;
            this.hostingEnvironment = _hostingEnvironment;
        }
        // GET: api/Assignment
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Assignment/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Assignment
        [HttpPost]
        public async Task<IActionResult> UploadAndProcessFile()
        {
            if (Request.Form.Files[0].Length > 0)
            {
                var file = Request.Form.Files[0];
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    IFileProcessor fileProcessor = new CSVFileReader();
                    List<STORE_ORDER> processedRecrods = fileProcessor.ReadFile(stream);
                    await repository.AddRange(processedRecrods);
                }
                return Ok("Upload Successful.");

            }
            else
            {
                return BadRequest("No File Provided");
            }
        }


        // PUT: api/Assignment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
