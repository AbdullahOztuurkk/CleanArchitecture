using AutoMapper;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Tag.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, AppResponse>
    {
        private IUnitOfWork UoW;
        private IMapper mapper;
        public CreateTagCommandHandler(IMapper mapper, IUnitOfWork UoW)
        {
            this.mapper = mapper;
            this.UoW = UoW;
        }

        public async Task<AppResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            var tag = mapper.Map<Domain.Entities.Tag>(request);
            var result = await UoW.TagRepository.AddAsync(tag);
            await UoW.SaveAsync();
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.CREATED_TAG_SUCCESSFULLY);
        }
    }
}
