using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Application.Validations.Note;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.CreateEvent
{
    public class CreateNoteCommandRequest : IRequest<AppResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public CreateNoteCommandRequest(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommandRequest, AppResponse>
    {
        private readonly IMapper mapper;
        private readonly INoteRepository noteRepository;
        private readonly CreateNoteValidator validator;
        public CreateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository, CreateNoteValidator validator)
        {
            this.mapper = mapper;
            this.noteRepository = noteRepository;
            this.validator = validator;
        }

        public async Task<AppResponse> Handle(CreateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
                return new ErrorResponse(Messages.VALIDATION_ERROR);

            var note = mapper.Map<Domain.Entities.Note>(request);
            var result = await noteRepository.AddAsync(note);
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.CREATED_NOTE_SUCCESSFULLY);
        }
    }
}
