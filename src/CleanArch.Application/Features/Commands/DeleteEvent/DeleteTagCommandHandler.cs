using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Application.Validations.Tag;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.DeleteEvent
{
    public class DeleteTagCommandRequest : IRequest<AppResponse>
    {
        public Guid Id { get; set; }

        public DeleteTagCommandRequest(Guid id)
        {
            Id = id;
        }
    }
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommandRequest, AppResponse>
    {
        private readonly ITagRepository tagRepository;
        private readonly DeleteTagValidator validator;
        public DeleteTagCommandHandler(ITagRepository tagRepository, DeleteTagValidator validator)
        {
            this.tagRepository = tagRepository;
            this.validator = validator;
        }

        public async Task<AppResponse> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
                return new ErrorResponse(Messages.VALIDATION_ERROR);

            var result = await tagRepository.RemoveAsync(request.Id);
            return result == null
                ? new ErrorResponse(Messages.ERROR_OCCURRED)
                : new SuccessResponse(Messages.DELETED_NOTE_PERMANENTLY);
        }
    }
}
