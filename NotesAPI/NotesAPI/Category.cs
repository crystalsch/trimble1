﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI
{
    public class Category
    {
        public string Id { get; set; }
        public string Name {get; set;}

        public Category(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}