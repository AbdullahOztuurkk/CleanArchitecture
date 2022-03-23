using AutoMapper;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Tag.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommandRequest, AppResponse>
    {
        private readonly IUnitOfWork UoW;
        private readonly IMapper mapper;
        public DeleteTagCommandHandler(IMapper mapper, IUnitOfWork UoW)
        {
            this.UoW = UoW;
            this.mapper = mapper;
        }

        public async Task<AppResponse> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await UoW.TagRepository.RemoveAsync(request.Id);
            await UoW.SaveAsync();
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.DELETED_NOTE_PERMANENTLY);
        }
    }
}
