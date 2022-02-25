using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Note.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommandRequest,AppResponse>
    {
        private INoteRepository noteRepository;
        private IMapper mapper;
        public CreateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            this.mapper = mapper;
            this.noteRepository = noteRepository;
        }

        public async Task<AppResponse> Handle(CreateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var note = mapper.Map<Domain.Entities.Note>(request);
            var result = await noteRepository.AddAsync(note);
            return result == null 
                ? new ErrorResponse("omas") 
                : new SuccessResponse("olur");
        }
    }
}
