using System.Collections.Generic;

namespace ConnectedLevelP1Homework.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> Authors { get; set; }
        public bool Status { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name}, статус: {Status}";
        }
    }
}
