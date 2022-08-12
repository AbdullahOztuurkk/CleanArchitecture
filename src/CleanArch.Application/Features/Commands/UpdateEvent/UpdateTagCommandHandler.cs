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

namespace CleanArch.Application.Features.Commands.UpdateEvent
{
    public class UpdateTagCommandRequest : IRequest<AppResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UpdateTagCommandRequest(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommandRequest, AppResponse>
    {
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;
        public UpdateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
        }

        public async Task<AppResponse> Handle(UpdateTagCommandRequest request, CancellationToken cancellationToken)
        {

            var tag = mapper.Map<Domain.Entities.Tag>(request);
            tagRepository.Update(tag);
            return new SuccessResponse(ResultMessages.CREATED_TAG_SUCCESSFULLY);
        }
    }
}
