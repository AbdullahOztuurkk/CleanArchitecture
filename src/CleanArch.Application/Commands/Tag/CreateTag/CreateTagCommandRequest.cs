using CleanArch.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Tag.CreateTag
{
    public class CreateTagCommandRequest:IRequest<AppResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateTagCommandRequest(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
