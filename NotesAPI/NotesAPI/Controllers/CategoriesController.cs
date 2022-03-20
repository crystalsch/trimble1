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

        [HttpGet]
        public IActionResult Get()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category("1", "To Do"));
            categories.Add(new Category("2", "Done"));
            categories.Add(new Category("3", "Doing"));

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(string id)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category("1", "To Do"));
            categories.Add(new Category("2", "Done"));
            categories.Add(new Category("3", "Doing"));

            Category selectedCategory = categories.Find(category => category.Id == id);

            return Ok(selectedCategory);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category newCategory)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category("1", "To Do"));
            categories.Add(new Category("2", "Done"));
            categories.Add(new Category("3", "Doing"));
            categories.Add(newCategory);
            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category("1", "To Do"));
            categories.Add(new Category("2", "Done"));
            categories.Add(new Category("3", "Doing"));
            Category selectedCategory = categories.Find(category => category.Id == id);
            categories.Remove(selectedCategory);
            return Ok(categories);
        }


    }
}
