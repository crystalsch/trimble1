using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        static List<Category> _cat = new List<Category> { new Category { Id = Guid.NewGuid(), Name = "Done" },
        new Category { Id = Guid.NewGuid(), Name = "To Do" },
        new Category { Id = Guid.NewGuid(), Name = "Doing" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cat);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {

            Category selectedCategory = _cat.Find(x => x.Id == id);

            return Ok(selectedCategory);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category a)
        {
            _cat.Add(a);
            return Ok(_cat);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Category selectedCategory = _cat.Find(category => category.Id == id);
            _cat.Remove(selectedCategory);
            return Ok(_cat);
        }


    }
}
