using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Note.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommandRequest, AppResponse>
    {
        private IUnitOfWork UoW;
        public DeleteNoteCommandHandler(IUnitOfWork uoW)
        {
            UoW = uoW;
        }
        public async Task<AppResponse> Handle(DeleteNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await UoW.NoteRepository.RemoveAsync(request.Id);
            await UoW.SaveAsync();
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.DELETED_NOTE_PERMANENTLY);
        }
    }
}
