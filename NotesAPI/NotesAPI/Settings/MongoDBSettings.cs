using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Settings
{
    public class MongoDBSettings: IMongoDBSettings
    {
        string IMongoDBSettings.NoteCollectionName { get; set; }
        string IMongoDBSettings.ConnectionString { get; set; }
        string IMongoDBSettings.DatabaseName { get; set; }
    }
}
