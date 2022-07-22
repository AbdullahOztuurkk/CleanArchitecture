using AutoMapper;
using CleanArch.Application.Interfaces.UnitOfWork;
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
        private readonly IUnitOfWork UoW;
        private readonly IMapper mapper;
        private readonly CreateTagValidator validator;
        public CreateTagCommandHandler(IMapper mapper, IUnitOfWork UoW, CreateTagValidator validator)
        {
            this.mapper = mapper;
            this.UoW = UoW;
            this.validator = validator;
        }

        public async Task<AppResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
                return new ErrorResponse(Messages.VALIDATION_ERROR);

            var tag = mapper.Map<Domain.Entities.Tag>(request);
            var result = await UoW.TagRepository.AddAsync(tag);
            await UoW.SaveAsync();
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.CREATED_TAG_SUCCESSFULLY);
        }
    }
}
