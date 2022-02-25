using CleanArch.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Note.DeleteNote
{
    public class DeleteNoteCommandRequest: IRequest<AppResponse>
    {
        public Guid Id { get; set; }

        public DeleteNoteCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
