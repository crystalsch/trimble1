using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class OwnerController : ControllerBase
    {
        static List<Owner> _owner = new List<Owner> { new Owner { Id = Guid.NewGuid(), Name = "Ioane" },
        new Owner { Id = Guid.NewGuid(), Name = "Ana" },
        new Owner { Id = Guid.NewGuid(), Name = "Ioana" },
        new Owner { Id = Guid.NewGuid(), Name = "Sarina" },
        new Owner { Id = Guid.NewGuid(), Name = "Alex" }
        };
        
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_owner);
        }

        [HttpPost]
        public IActionResult CreateNotes([FromBody] Owner owner)
        {
            _owner.Add(owner);
            return Ok(_owner);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateNote(Guid id, [FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("owner can't be null");
            }
            int index = _owner.FindIndex(n => n.Id == id);
            if (index == -1)
            {
                return CreateNotes(owner);
                //return NotFound("index not found");
            }
            owner.Id = id;
            _owner[index] = owner;
            return Ok(_owner);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            int index = _owner.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return NotFound("the note wasn't found");
            }
            _owner.RemoveAt(index);
            return Ok("the note was deleted");
        }
    }
}
