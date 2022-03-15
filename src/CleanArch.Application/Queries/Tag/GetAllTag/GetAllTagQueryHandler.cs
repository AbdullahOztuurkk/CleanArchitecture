using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Tag.GetAllTag
{
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
            var result = await tagRepository.GetAsync();
            return mapper.Map<List<GetAllTagQueryResponse>>(result);
        }
    }
}
