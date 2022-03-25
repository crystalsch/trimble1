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

    public class OwnerController : ControllerBase
    {

        IOwnerCollectionService _ownerCollectionService;

        public OwnerController(IOwnerCollectionService ownerCollectionService)
        {
            _ownerCollectionService = ownerCollectionService ?? throw new ArgumentNullException(nameof(ownerCollectionService));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwnerIdAsync(Guid id, [FromBody] Owner owner)
        {

            if (await _ownerCollectionService.Update(id, owner))
            {
                return Ok("the owner update");
            }
            return NotFound("owner not found");
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnerAsync(Guid id)
        {

            if (await _ownerCollectionService.Delete(id))
            {
                return Ok("the owner was deleted");
            }
            return NotFound("owner not found");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {
            if (owner == null)
                return BadRequest("owner is null");
            await _ownerCollectionService.Create(owner);
            return Ok(await _ownerCollectionService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            return Ok(await _ownerCollectionService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerAsync(Guid id)
        {
            Owner owner = await _ownerCollectionService.Get(id);
            if (owner == null) { 
                return NotFound("the owner is not found");
            }
            return Ok(owner);
        }

        //    [HttpGet]
        //    public IActionResult GetNotes()
        //    {
        //        return Ok(_owner);
        //    }

        //    [HttpPost]
        //    public IActionResult CreateNotes([FromBody] Owner owner)
        //    {
        //        _owner.Add(owner);
        //        return Ok(_owner);
        //    }
        //    [HttpPut("{id}")]
        //    public IActionResult UpdateNote(Guid id, [FromBody] Owner owner)
        //    {
        //        if (owner == null)
        //        {
        //            return BadRequest("owner can't be null");
        //        }
        //        int index = _owner.FindIndex(n => n.Id == id);
        //        if (index == -1)
        //        {
        //            return CreateNotes(owner);
        //            //return NotFound("index not found");
        //        }
        //        owner.Id = id;
        //        _owner[index] = owner;
        //        return Ok(_owner);
        //    }

        //    [HttpDelete("{id}")]
        //    public IActionResult DeleteNote(Guid id)
        //    {
        //        int index = _owner.FindIndex(x => x.Id == id);
        //        if (index == -1)
        //        {
        //            return NotFound("the note wasn't found");
        //        }
        //        _owner.RemoveAt(index);
        //        return Ok("the note was deleted");
        //    }
        //}
    }
}
