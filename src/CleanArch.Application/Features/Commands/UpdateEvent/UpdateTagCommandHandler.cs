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
        //private readonly CreateTagValidator validator;
        public UpdateTagCommandHandler(IMapper mapper, ITagRepository tagRepository/*, CreateTagValidator validator*/)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
            //this.validator = validator;
        }

        public async Task<AppResponse> Handle(UpdateTagCommandRequest request, CancellationToken cancellationToken)
        {
            /*
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
                return new ErrorResponse(Messages.VALIDATION_ERROR);
            */
            var tag = mapper.Map<Domain.Entities.Tag>(request);
            tagRepository.Update(tag);
            return new SuccessResponse(Messages.CREATED_TAG_SUCCESSFULLY);
        }
    }
}
