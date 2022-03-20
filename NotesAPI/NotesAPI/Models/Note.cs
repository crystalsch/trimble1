using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models
{
    public class Note
    {
        string Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string CategoryId { get; set; }
    }
}
