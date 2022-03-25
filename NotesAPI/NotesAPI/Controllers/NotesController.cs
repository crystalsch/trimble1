using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Exceptions;
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
        //INoteCollectionService _noteCollectionService;
        //public NotesController(INoteCollectionService noteCollectionService)
        //{
        //    _noteCollectionService = noteCollectionService ?? throw new ArgumentNullException(nameof(noteCollectionService));
        //}

        //[HttpPut("{id},{idO}")]
        //public IActionResult UpdateNote(Guid id, Guid idO, [FromBody] Note note)
        //{
        //    List<Note> _notes;
        //    _notes = _noteCollectionService.GetAll();
        //    if (note == null)
        //    {
        //        return BadRequest("note can't be null");
        //    }
        //    int index = _notes.FindIndex(x => x.Id == id && x.OwnerId == idO);
        //    if (index == -1)
        //    {

        //        return NotFound("note not found");
        //    }
        //    note.Id = id;
        //    note.OwnerId = idO;
        //    _notes[index] = note;
        //    return Ok(_notes);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateNoteId(Guid id, [FromBody] Note note)
        //{

        //    if (_noteCollectionService.Update(id, note))
        //    {
        //        return Ok("the note update");
        //    }
        //    return NotFound("note not found");
        //}

        //[HttpDelete("{id},{idO}")]
        //public IActionResult DeleteNote(Guid id, Guid idO)
        //{
        //    List<Note> _notes;
        //    _notes = _noteCollectionService.GetAll();
        //    int index = _notes.FindIndex(x => x.Id == id && x.OwnerId == idO);
        //    if (index == -1)
        //    {
        //        return NotFound("note not found");
        //    }
        //    _notes.RemoveAt(index);
        //    return Ok("the note was deleted");
        //}

        //[HttpDelete("DeleteAllNotes/{idO}")]
        //public IActionResult DeleteAllNotes(Guid idO)
        //{
        //    List<Note> _notes;
        //    _notes = _noteCollectionService.GetAll();
        //    int index = _notes.FindIndex(x => x.OwnerId == idO);
        //    if (index == -1)
        //    {
        //        return NotFound("note not found");
        //    }
        //    _notes.RemoveAll(x => x.OwnerId == idO);
        //    return Ok("the notes was deleted");
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteNote(Guid id)
        //{

        //    if (_noteCollectionService.Delete(id))
        //    {
        //        return Ok("the notes was deleted");
        //    }
        //    return NotFound("note not found");
        //}

        [HttpPost]
        public async  Task<IActionResult> CreateNotes([FromBody] Note note)
        {
            if (note == null)
                return BadRequest("Note is null");
            await _noteCollectionService.Create(note);
            return Ok(await _noteCollectionService.GetAll();
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            return Ok(await _noteCollectionService.GetAll());
        }

        //[HttpGet("{id}")]
        //public IActionResult GetNote(Guid id)
        //{
        //    try
        //    {
        //        return Ok(_noteCollectionService.Get(id));
        //    }
        //    catch (NoteNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}

        //[HttpGet(" owner/{oId}")]
        //public IActionResult GetNotesO(Guid oId)
        //{
        //    return Ok(_noteCollectionService.GetNotesByOwnerId(oId));
        //}
    }
}

