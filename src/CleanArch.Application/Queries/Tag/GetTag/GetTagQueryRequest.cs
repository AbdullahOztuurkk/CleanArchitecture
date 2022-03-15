using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Tag.GetTag
{
    public class GetTagQueryRequest: IRequest<GetTagQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
