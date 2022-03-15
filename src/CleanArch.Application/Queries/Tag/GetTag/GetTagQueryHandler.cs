using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Tag.GetTag
{
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
