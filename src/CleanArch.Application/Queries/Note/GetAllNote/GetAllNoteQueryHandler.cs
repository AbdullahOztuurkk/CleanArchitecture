using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Queries.Note.GetAllNote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Note.GetAllNote
{
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
