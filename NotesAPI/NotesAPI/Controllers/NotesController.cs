using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using NotesAPI.Services;
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
        INoteCollectionService _noteCollectionService;
        public NotesController(INoteCollectionService noteCollectionService)
       {
        _noteCollectionService = noteCollectionService ?? throw new ArgumentNullException(nameof(noteCollectionService));
        }

        //[HttpPut("{id}")]
        //    public IActionResult UpdateNote(Guid id, [FromBody] Note note)
        //    {
        //        if (note == null)
        //        {
        //            return BadRequest("note can't be null");
        //        }
        //        int index = _notes.FindIndex(n => n.Id == id);
        //        if (index == -1)
        //        {
        //            return CreateNotes(note);
        //            //return NotFound("index not found");
        //        }
        //        note.Id = id;
        //        _notes[index] = note;
        //        return Ok(_notes);
        //    }

        [HttpPut("{id},{idO}")]
        public IActionResult UpdateNote(Guid id,Guid idO, [FromBody] Note note)
        {
            List<Note> _notes;
            _notes = _noteCollectionService.GetAll();
            if (note == null)
            {
                return BadRequest("note can't be null");
            }
            int index = _notes.FindIndex(x => x.Id == id && x.OwnerId == idO);
            if (index == -1)
            {
                
                return NotFound("note not found");
            }
            note.Id = id;
            note.OwnerId = idO;
            _notes[index] = note;
            return Ok(_notes);
        }

        [HttpDelete("{id},{idO}")]
        public IActionResult DeleteNote(Guid id, Guid idO)
        {
            List<Note> _notes;
            _notes = _noteCollectionService.GetAll();
            int index = _notes.FindIndex(x => x.Id == id && x.OwnerId == idO);
            if (index == -1)
            {
                return NotFound("note not found");
            }
            _notes.RemoveAt(index);
            return Ok("the note was deleted");
        }

        [HttpDelete("{idO}")]
        public IActionResult DeleteAllNotes(Guid idO)
        {
            List<Note> _notes;
            _notes = _noteCollectionService.GetAll();
            int index = _notes.FindIndex(x => x.OwnerId == idO);
            if (index == -1)
            {
                return NotFound("note not found");
            }
            _notes.RemoveAll(x => x.OwnerId == idO);
            return Ok("the notes was deleted");
        }


        //    [HttpDelete("{id}")]
        //    public IActionResult DeleteNote(Guid id)
        //    {
        //        int index = _notes.FindIndex(x => x.Id == id);
        //        if (index == -1)
        //        {
        //            return NotFound("the note wasn't found");
        //        }
        //        _notes.RemoveAt(index);
        //        return Ok("the note was deleted");
        //    }
        //    /// <summary>
        //    /// Get all notes
        //    /// </summary>
        //    /// <returns></returns>
        //    [HttpGet]
        //    public IActionResult GetNotes()
        //    {
        //        return Ok(_notes);
        //    }

        [HttpPost]
        public IActionResult CreateNotes([FromBody] Note note)
        {
            if (note == null)
                return BadRequest("Note is null");
            _noteCollectionService.Create(note);
            return Ok(note);
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_noteCollectionService.GetAll());
        }


    }
}
