using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Validations.Note;
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
        //private readonly DeleteNoteValidator validator;
        public DeleteNoteCommandHandler(INoteRepository noteRepository/*, DeleteNoteValidator validator*/)
        {
            this.noteRepository = noteRepository;
            //this.validator = validator;
        }
        public async Task<AppResponse> Handle(DeleteNoteCommandRequest request, CancellationToken cancellationToken)
        {
            //var validationResult = validator.Validate(request);
            //if (validationResult.Errors.Count > 0)
            //    return new ErrorResponse(Messages.VALIDATION_ERROR);

            noteRepository.Delete(request.Id);
            return new SuccessResponse(Messages.DELETED_NOTE_PERMANENTLY);
        }
    }
}
