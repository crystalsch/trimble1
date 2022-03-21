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
    }
}
