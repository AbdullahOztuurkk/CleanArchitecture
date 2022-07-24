using AutoMapper;
using CleanArch.Application.Features.Commands.CreateEvent;
using CleanArch.Application.Features.Commands.DeleteEvent;
using CleanArch.Application.Features.Commands.UpdateEvent;
using CleanArch.Application.Features.Queries.GetAllEvent;
using CleanArch.Application.Features.Queries.GetEvent;
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
            CreateMap<Note, UpdateNoteCommandRequest>()
                .ReverseMap();
            CreateMap<Tag, UpdateTagCommandRequest>()
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
