using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Application.Validations.Note;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.DeleteEvent
{
    public class DeleteNoteCommandRequest : IRequest<AppResponse>
    {
        public Guid Id { get; set; }

        public DeleteNoteCommandRequest(Guid id)
        {
            Id = id;
        }
    }
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommandRequest, AppResponse>
    {
        private readonly IUnitOfWork UoW;
        private readonly DeleteNoteValidator validator;
        public DeleteNoteCommandHandler(IUnitOfWork uoW, DeleteNoteValidator validator)
        {
            UoW = uoW;
            this.validator = validator;
        }
        public async Task<AppResponse> Handle(DeleteNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
                return new ErrorResponse(Messages.VALIDATION_ERROR);

            var result = await UoW.NoteRepository.RemoveAsync(request.Id);
            await UoW.SaveAsync();
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.DELETED_NOTE_PERMANENTLY);
        }
    }
}
