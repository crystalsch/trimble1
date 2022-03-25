using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {

        //static List<Owner> _owner = new List<Owner> { new Owner { Id = Guid.NewGuid(), Name = "Ioane" },
        //new Owner { Id = Guid.NewGuid(), Name = "Ana" },
        //new Owner { Id = Guid.NewGuid(), Name = "Ioana" },
        //new Owner { Id = Guid.NewGuid(), Name = "Sarina" },
        //new Owner { Id = Guid.NewGuid(), Name = "Alex" }
        //};
        private readonly IMongoCollection<Owner> _owner;

        public OwnerCollectionService(IMongoDBSettings mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.DatabaseName);

            _owner = database.GetCollection<Owner>(mongoDBSettings.OwnerCollectionName);
        }

        public async Task<bool> Create(Owner owner)
        {
            await _owner.InsertOneAsync(owner);
            return true;
        }


        public async Task<bool> Delete(Guid id)
        {
            var result = await _owner.DeleteOneAsync(owner => owner.Id == id);
            if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }


        public async Task<Owner> Get(Guid id)
        {

            return (await _owner.FindAsync(owner => owner.Id == id)).FirstOrDefault();
        }

        public async Task<List<Owner>> GetAll()
        {
            var result = await _owner.FindAsync(owner => true);
            return result.ToList();

        }

        public async Task<bool> Update(Guid id, Owner owner)
        {
            owner.Id = id;
            var result = await _owner.ReplaceOneAsync(owner => owner.Id == id, owner);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _owner.InsertOneAsync(owner);
                return false;
            }

            return true;
        }

    }
}
