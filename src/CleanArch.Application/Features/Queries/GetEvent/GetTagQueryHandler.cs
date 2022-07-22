using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Queries.GetEvent
{
    public class GetTagQueryRequest : IRequest<GetTagQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetTagQueryResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class GetTagQueryHandler : IRequestHandler<GetTagQueryRequest, GetTagQueryResponse>
    {
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;
        public GetTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
        }
        public async Task<GetTagQueryResponse> Handle(GetTagQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await tagRepository.GetByIdAsync(request.Id);
            return mapper.Map<GetTagQueryResponse>(result);
        }
    }
}
