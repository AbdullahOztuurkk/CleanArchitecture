using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.CreateEvent
{
    public class CreateTagCommandRequest : IRequest<AppResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateTagCommandRequest(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, AppResponse>
    {
        private readonly IMapper mapper;
        private readonly ITagRepository tagRepository;
        public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
        }

        public async Task<AppResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            var tag = mapper.Map<Domain.Entities.Tag>(request);
            tagRepository.Add(tag);
            return new SuccessResponse(ResultMessages.CREATED_TAG_SUCCESSFULLY);
        }
    }
}
