using AutoMapper;
using CleanArch.Application.Commands.Note.CreateNote;
using CleanArch.Application.Commands.Note.DeleteNote;
using CleanArch.Application.Queries.Note.GetAllNote;
using CleanArch.Application.Queries.Note.GetNote;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mapping
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            //Commands
            CreateMap<Note, CreateNoteCommandRequest>()
                .ReverseMap();
            CreateMap<Note, DeleteNoteCommandRequest>()
                .ReverseMap();

            //Queries
            CreateMap<Note, GetAllNoteQueryResponse>()
                .ReverseMap();
            CreateMap<Note, GetNoteQueryResponse>()
                .ReverseMap();
        }
    }
}
