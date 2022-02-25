using CleanArch.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands.Note.CreateNote
{
    public class CreateNoteCommandRequest : IRequest<AppResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public CreateNoteCommandRequest(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
