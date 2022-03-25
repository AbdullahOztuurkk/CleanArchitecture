using AutoMapper;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Application.Validations.Note;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Note.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommandRequest, AppResponse>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork UoW;
        private readonly CreateNoteValidator validator;
        public CreateNoteCommandHandler(IMapper mapper, IUnitOfWork uoW, CreateNoteValidator validator)
        {
            this.mapper = mapper;
            UoW = uoW;
            this.validator = validator;
        }

        public async Task<AppResponse> Handle(CreateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
                return new ErrorResponse(Messages.VALIDATION_ERROR);

            var note = mapper.Map<Domain.Entities.Note>(request);
            var result = await UoW.NoteRepository.AddAsync(note);
            await UoW.SaveAsync();
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.CREATED_NOTE_SUCCESSFULLY);
        }
    }
}
