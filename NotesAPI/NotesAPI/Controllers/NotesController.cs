using Microsoft.AspNetCore.Http;
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
    public class NotesController : ControllerBase
    {
        static List<Note> _notes = new List<Note> { new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "First Note", Description = "First Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("2ADEA345-7F7A-4313-87AE-F05E8B2DE678"), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fifth Note", Description = "Fifth Note Description" }
        };

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notes);
        }

        [HttpPost]
        public IActionResult CreateNotes([FromBody] Note note)
        {
            _notes.Add(note);
            return Ok(_notes);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {
            List<Note> selectedNotes = _notes.FindAll(_notes => _notes.OwnerId == id);
            return Ok(selectedNotes);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneNote(Guid id)
        {
            Note selectedNotes = _notes.Find(_notes => _notes.Id == id);
            return Ok(selectedNotes);
        }

    }
}
