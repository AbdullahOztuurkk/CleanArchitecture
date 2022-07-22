using CleanArch.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Queries.GetEvent
{
    public class GetNoteQueryRequest : IRequest<GetNoteQueryResponse>
    {
        public Guid Id { get; set; }
    }
    public class GetNoteQueryResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string TagName { get; set; }
    }

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
