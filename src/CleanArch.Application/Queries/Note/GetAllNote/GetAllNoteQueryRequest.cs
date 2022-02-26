using CleanArch.Application.Queries.Note.GetAllNote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Note.GetNote
{
    public class GetAllNoteQueryRequest : IRequest<List<GetAllNoteQueryResponse>>
    {
    }
}
