using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Note.GetNote
{
    public class GetNoteQueryRequest:IRequest<GetNoteQueryResponse>
    {
        public Guid Id { get; set; }
        public GetNoteQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
