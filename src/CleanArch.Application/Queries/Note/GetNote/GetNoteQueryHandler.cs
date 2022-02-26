using CleanArch.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Note.GetNote
{
    public class GetNoteQueryHandler : IRequestHandler<GetNoteQueryRequest, GetNoteQueryResponse>
    {
        private readonly INoteRepository noteRepository;
        public GetNoteQueryHandler(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }
        public Task<GetNoteQueryResponse> Handle(GetNoteQueryRequest request, CancellationToken cancellationToken)
        {
            //TODO: Must be refactor after created concrete repository class
            return null;
        }
    }
}
