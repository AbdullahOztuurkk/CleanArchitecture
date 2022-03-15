using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Tag.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommandRequest, AppResponse>
    {
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;
        public DeleteTagCommandHandler(ITagRepository tagRepository, IMapper mapper)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
        }

        public async Task<AppResponse> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await tagRepository.RemoveAsync(request.Id);
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.DELETED_NOTE_PERMANENTLY);
        }
    }
}
