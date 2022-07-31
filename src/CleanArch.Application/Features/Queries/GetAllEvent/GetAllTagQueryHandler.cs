using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Queries.GetAllEvent
{
    public class GetAllTagQueryRequest : IRequest<List<GetAllTagQueryResponse>> { }

    public class GetAllTagQueryResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQueryRequest, List<GetAllTagQueryResponse>>
    {
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;
        public GetAllTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
        }
        public async Task<List<GetAllTagQueryResponse>> Handle(GetAllTagQueryRequest request, CancellationToken cancellationToken)
        {
            var result = tagRepository.GetAll();
            return mapper.Map<List<GetAllTagQueryResponse>>(result);
        }
    }
}
