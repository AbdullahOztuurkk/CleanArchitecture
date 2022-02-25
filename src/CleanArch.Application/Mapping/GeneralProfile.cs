using AutoMapper;
using CleanArch.Application.Commands.Note.CreateNote;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mapping
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<Note, CreateNoteCommandRequest>()
                .ReverseMap();
        }
    }
}
