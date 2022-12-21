using Api.Data.Dtos.Notes;
using Api.Models.Notes;
using AutoMapper;

namespace Api.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<CreateNoteDto, Note>();
            CreateMap<Note, ReadNoteDto>();
        }
    }
}
