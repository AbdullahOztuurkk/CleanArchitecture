using AutoMapper;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Note.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommandRequest, AppResponse>
    {
        private IMapper mapper;
        private IUnitOfWork UoW;
        public CreateNoteCommandHandler(IMapper mapper, IUnitOfWork uoW)
        {
            this.mapper = mapper;
            UoW = uoW;
        }

        public async Task<AppResponse> Handle(CreateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var note = mapper.Map<Domain.Entities.Note>(request);
            var result = await UoW.NoteRepository.AddAsync(note);
            await UoW.SaveAsync();
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.CREATED_NOTE_SUCCESSFULLY);
        }
    }
}
