using Api.Data.Dtos.Notes;
using Api.Entities.Exceptions;
using Api.Models.Authentication;
using Api.Models.Notes;
using Api.Services.Notes;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Notes
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private NotesService _notesService;

        public NoteController(NotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateNote(CreateNoteDto createDto)
        {

            try
            {
                _notesService.CreateNote(createDto);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Falha ao salvar nota");
            }
          
        }

        [HttpPost("/get-notes")]
        [Authorize]
        public IActionResult GetNotes(Token token)
        {


            try
            {
                IEnumerable<Note> notes = _notesService.GetNotes(token);

                if (notes != null) return Ok(notes);

               throw new Exception();
            }
            catch (UnauthorizedIdRequest e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Falha ao recuperar dados");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetNoteById(string id)
        {
           try
            {
                ReadNoteDto note = _notesService.GetNoteById(int.Parse(id));

                if (note != null) return Ok(note);
                return StatusCode(404);

            }
            catch
            {

                return StatusCode(500, "Falha ao recuperar dados");
            }

        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteNote(string id)
        {
            try
            {
                Result res = _notesService.DeleteNote(int.Parse(id));

                if (res.IsFailed) return StatusCode(400, res.Reasons[0].Message);
                return Ok();
            }
            catch
            {

                return StatusCode(500, "Falha ao excluir nota");
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult ArchiveNote(ReadNoteDto note)
        {


                Result res = _notesService.ArchiveNote(note);
                if (res.IsFailed) return StatusCode(400, res.Reasons[0].Message);
               return Ok();
            

                return StatusCode(500, "Falha ao arquivar nota");
            
        }
    }

}

