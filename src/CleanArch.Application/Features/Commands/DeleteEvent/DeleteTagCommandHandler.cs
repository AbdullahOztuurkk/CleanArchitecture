using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
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
        public int Id { get; set; }
    }
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommandRequest, AppResponse>
    {
        private readonly ITagRepository tagRepository;
        public DeleteTagCommandHandler(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public async Task<AppResponse> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
        {
            tagRepository.Delete(request.Id);
            return new SuccessResponse(ResultMessages.DELETED_NOTE_PERMANENTLY);
        }
    }
}
