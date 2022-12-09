using Api.Data;
using Api.Data.Dtos.Notes;
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
    }

}

