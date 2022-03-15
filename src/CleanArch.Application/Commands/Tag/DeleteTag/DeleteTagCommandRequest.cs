using CleanArch.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Tag.DeleteTag
{
    public class DeleteTagCommandRequest: IRequest<AppResponse>
    {
        public Guid Id { get; set; }
    }
}
