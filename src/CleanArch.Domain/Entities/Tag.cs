using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationship
        public ICollection<Note> Notes { get; set; }
    }
}
