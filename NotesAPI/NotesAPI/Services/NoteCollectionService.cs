using MongoDB.Driver;
using NotesAPI.Exceptions;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class NoteCollectionService : INoteCollectionService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteCollectionService(IMongoDBSettings mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.DatabaseName);

            _notes = database.GetCollection<Note>(mongoDBSettings.NoteCollectionName);
        }


        public async Task<bool> Create(Note note)
        {
            await _notes.InsertOneAsync(note);
            return true;
        }


        public async Task<bool> Delete(Guid id)
        {
            var result = await _notes.DeleteOneAsync(note => note.Id == id);
            if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }


        public async Task<Note> Get(Guid id)
        {
            //var result = await _notes.FindAsync(note => note.Id == id);
            //if(result.ToList().Count == 0)
            //{
            //    return null;
            //}
            //return result.ToList()[0];
            var res = (await _notes.FindAsync(note => note.Id == id)).FirstOrDefault();
            return res;


        }

        public async Task<List<Note>> GetAll()
        {
            try
            {
                var result = (await _notes.FindAsync(_ => true)).ToList();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public async Task<List<Note>> GetNotesByOwnerId(Guid ownerId)
        {
            return (await _notes.FindAsync(note => note.OwnerId == ownerId)).ToList();
        }


        public async Task<bool> Update(Guid id, Note note)
        {
            note.Id = id;
            var result = await _notes.ReplaceOneAsync(note => note.Id == id, note);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _notes.InsertOneAsync(note);
                return false;
            }

            return true;
        }

    }
}
