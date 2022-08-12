using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using CleanArch.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.UpdateEvent
{
    public class UpdateNoteCommandRequest: IRequest<AppResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsStarred { get; set; }
    }

    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommandRequest, AppResponse>
    {
        private readonly IMapper mapper;
        private readonly INoteRepository noteRepository;

        public UpdateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
            this.mapper = mapper;
        }

        public async Task<AppResponse> Handle(UpdateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Note>(request);
            noteRepository.Update(entity);
            return new SuccessResponse(ResultMessages.CREATED_TAG_SUCCESSFULLY);
        }
    }
}
