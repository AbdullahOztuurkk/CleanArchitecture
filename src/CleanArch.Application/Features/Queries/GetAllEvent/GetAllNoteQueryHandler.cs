using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Queries.GetAllEvent
{
    public class GetAllNoteQueryRequest : IRequest<List<GetAllNoteQueryResponse>> { }
    public class GetAllNoteQueryResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class GetAllNoteQueryHandler : IRequestHandler<GetAllNoteQueryRequest, List<GetAllNoteQueryResponse>>
    {
        private readonly INoteRepository noteRepository;
        private readonly IMapper mapper;
        public GetAllNoteQueryHandler(INoteRepository noteRepository, IMapper mapper)
        {
            this.noteRepository = noteRepository;
            this.mapper = mapper;
        }
        public async Task<List<GetAllNoteQueryResponse>> Handle(GetAllNoteQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await noteRepository.GetAsync();
            return mapper.Map<List<GetAllNoteQueryResponse>>(result);
        }
    }
}
