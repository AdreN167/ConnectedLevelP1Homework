﻿using System.Collections.Generic;

namespace ConnectedLevelP1Homework.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> Books { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}