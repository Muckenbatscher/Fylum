using Microsoft.AspNetCore.Mvc;

namespace Fylum.Files
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // GET: api/<FilesController>
        [HttpGet]
        public IEnumerable<FileResponse> Get([FromQuery] int page)
        {
            var file1 = new FileResponse()
            {
                Id = Guid.NewGuid(),
                Name = "File1.txt",
                ParentFolderId = Guid.NewGuid(),
                LatestRevisionId = Guid.NewGuid()
            };
            var file2 = new FileResponse()
            {
                Id = Guid.NewGuid(),
                Name = "File2.txt",
                ParentFolderId = Guid.NewGuid(),
                LatestRevisionId = Guid.NewGuid()
            };
            return new FileResponse[] { file1, file2 };
        }

        // GET api/<FilesController>/5
        [HttpGet("{id}")]
        public FileResponse Get(Guid id)
        {
            return new FileResponse() 
            { 
                Id = id,  
                Name = "ExampleFile.txt",
                ParentFolderId = Guid.NewGuid(),
                LatestRevisionId = Guid.NewGuid()
            };
        }

        // POST api/<FilesController>
        [HttpPost]
        public void Post([FromBody] FileCreationRequest creation)
        {
        }

        // PUT api/<FilesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
