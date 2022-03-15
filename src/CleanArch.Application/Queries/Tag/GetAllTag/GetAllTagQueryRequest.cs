using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries.Tag.GetAllTag
{
    public class GetAllTagQueryRequest:IRequest<List<GetAllTagQueryResponse>>
    {

    }
}
