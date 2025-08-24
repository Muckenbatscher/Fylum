using Microsoft.AspNetCore.Mvc;

namespace Fylum.Tags
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        // GET: api/<TagsController>
        [HttpGet]
        public IEnumerable<TagResponse> Get()
        {
            var firstTagGuid = Guid.NewGuid();
            var secondTagGuid = Guid.NewGuid();
            return new List<TagResponse>
            {
                new TagResponse
                {
                    Id = firstTagGuid,
                    Name = $"Tag-{firstTagGuid.ToString().Substring(0, 8)}",
                    Type = "TypeA"
                },
                new TagResponse
                {
                    Id = secondTagGuid,
                    Name = $"Tag-{secondTagGuid.ToString().Substring(0, 8)}",
                    Type = "TypeB"
                }
            };
        }

        // POST api/<TagsController>
        [HttpPost]
        public void Create([FromBody] TagCreationRequest value)
        {
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
