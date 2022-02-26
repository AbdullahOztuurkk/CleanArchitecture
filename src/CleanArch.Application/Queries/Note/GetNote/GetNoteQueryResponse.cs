using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Note.GetNote
{
    public class GetNoteQueryResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string TagName { get; set; }
    }
}
