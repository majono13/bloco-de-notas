using Api.Data;
using Api.Data.Dtos.Notes;
using Api.Entities.Exceptions;
using Api.Models.Authentication;
using Api.Models.Notes;
using Api.Services.Notes;
using AutoMapper;
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
                return StatusCode(500, "Falha ao salvar nota, tente novamente mais tarde");
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

                return StatusCode(500, "Falha ao recuperar dados");
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
    }

}

