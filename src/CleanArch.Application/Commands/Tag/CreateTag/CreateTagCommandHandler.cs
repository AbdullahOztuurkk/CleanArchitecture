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

namespace CleanArch.Application.Commands.Tag.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, AppResponse>
    {
        private ITagRepository tagRepository;
        private IMapper mapper;
        public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
        }

        public async Task<AppResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            var tag = mapper.Map<Domain.Entities.Tag>(request);
            var result = await tagRepository.AddAsync(tag);
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.CREATED_TAG_SUCCESSFULLY);
        }
    }
}
