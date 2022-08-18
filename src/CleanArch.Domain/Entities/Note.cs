using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsStarred { get; set; }

        //Relationship
        public Tag Tag { get; set; }

        public Note(string title, string content, bool isStarred)
        {
            Title = title;
            Content = content;
            IsStarred = isStarred;
        }
    }
}
