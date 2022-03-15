using AutoMapper;
using CleanArch.Application.Commands.Note.CreateNote;
using CleanArch.Application.Commands.Note.DeleteNote;
using CleanArch.Application.Commands.Tag.CreateTag;
using CleanArch.Application.Commands.Tag.DeleteTag;
using CleanArch.Application.Queries.Note.GetAllNote;
using CleanArch.Application.Queries.Note.GetNote;
using CleanArch.Application.Queries.Tag.GetAllTag;
using CleanArch.Application.Queries.Tag.GetTag;
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
            CreateMap<Tag, CreateTagCommandRequest>()
                .ReverseMap();
            CreateMap<Tag, DeleteTagCommandRequest>()
                .ReverseMap();

            //Queries
            CreateMap<Note, GetAllNoteQueryResponse>()
                .ReverseMap();
            CreateMap<Note, GetNoteQueryResponse>()
                .ReverseMap();
            CreateMap<Tag, GetAllTagQueryResponse>()
                .ReverseMap();
            CreateMap<Tag, GetTagQueryResponse>()
                .ReverseMap();
        }
    }
}
