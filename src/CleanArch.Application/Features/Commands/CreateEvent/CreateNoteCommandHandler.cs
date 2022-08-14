using AutoMapper;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.CreateEvent
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
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommandRequest, AppResponse>
    {
        private readonly IMapper mapper;
        private readonly INoteRepository noteRepository;
        public CreateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            this.mapper = mapper;
            this.noteRepository = noteRepository;
        }

        public async Task<AppResponse> Handle(CreateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var note = mapper.Map<Domain.Entities.Note>(request);
            noteRepository.Add(note);
            return await Task.FromResult<AppResponse>(new SuccessResponse(ResultMessages.CREATED_NOTE_SUCCESSFULLY));
        }
    }
}
