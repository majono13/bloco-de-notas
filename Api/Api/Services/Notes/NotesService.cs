using Api.Data;
using Api.Data.Daos;
using Api.Data.Dtos.Notes;
using Api.Models.Notes;
using AutoMapper;
using FluentResults;

namespace Api.Services.Notes
{
    public class NotesService
    {

        private IMapper _mapper;
        private NotesDao _notesDao;

        public NotesService(IMapper mapper, NotesDao notesDao)
        {
            _mapper = mapper;
            _notesDao = notesDao;
        }

        public void CreateNote(CreateNoteDto createDto)
        {
          _notesDao.CreateNote(_mapper.Map<Note>(createDto));

        }
    }
}
