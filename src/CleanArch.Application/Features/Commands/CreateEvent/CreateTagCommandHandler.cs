using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Validations.Tag;
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
        //private readonly CreateTagValidator validator;
        public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository/*, CreateTagValidator validator*/)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
            //this.validator = validator;
        }

        public async Task<AppResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            //var validationResult = validator.Validate(request);
            //if (validationResult.Errors.Count > 0)
            //    return new ErrorResponse(Messages.VALIDATION_ERROR);

            var tag = mapper.Map<Domain.Entities.Tag>(request);
            tagRepository.Add(tag);
            return new SuccessResponse(ResultMessages.CREATED_TAG_SUCCESSFULLY);
        }
    }
}
