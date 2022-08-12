using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.DeleteEvent
{
    public class DeleteNoteCommandRequest : IRequest<AppResponse>
    {
        public int Id { get; set; }

        public DeleteNoteCommandRequest(int id)
        {
            Id = id;
        }
    }
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommandRequest, AppResponse>
    {
        private readonly INoteRepository noteRepository;
        public DeleteNoteCommandHandler(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }
        public async Task<AppResponse> Handle(DeleteNoteCommandRequest request, CancellationToken cancellationToken)
        {
            noteRepository.Delete(request.Id);
            return new SuccessResponse(ResultMessages.DELETED_NOTE_PERMANENTLY);
        }
    }
}
