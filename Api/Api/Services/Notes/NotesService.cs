using Api.Data.Daos;
using Api.Data.Dtos.Notes;
using Api.Models.Authentication;
using Api.Models.Notes;
using Api.Services.Authentication;
using AutoMapper;
using FluentResults;

namespace Api.Services.Notes
{
    public class NotesService
    {

        private IMapper _mapper;
        private NotesDao _notesDao;
        private TokenService _tokenService;

        public NotesService(IMapper mapper, NotesDao notesDao, TokenService tokenService)
        {
            _mapper = mapper;
            _notesDao = notesDao;
            _tokenService = tokenService;
        }

        public void CreateNote(CreateNoteDto createDto)
        {
          _notesDao.CreateNote(_mapper.Map<Note>(createDto));

        }

        public IEnumerable<Note> GetNotes(Token token)
        {
            User user = _tokenService.GetUserByToken(token);

            if(user != null )
            {
             return   _notesDao.GetNotesByUserId(user.Id);
            }

            return null;
            
        }

        public ReadNoteDto GetNoteById(int id)
        {
            Note note = _notesDao.GetNoteById(id);

            return _mapper.Map<ReadNoteDto>(note);
        }

        public Result DeleteNote(int id)
        {

            bool res = _notesDao.DeleteNote(id);
            if (res) return Result.Ok();
            return Result.Fail("Falha ao excluir nota");
        }

        public Result ArchiveNote(ReadNoteDto note)
        {
            bool res = _notesDao.EditNote(_mapper.Map<Note>(note));

           if(res) return Result.Ok();
            return Result.Fail("Falha ao arquivar nota");
        }
    }
}
