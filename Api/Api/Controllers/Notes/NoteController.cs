using Api.Data;
using Api.Data.Dtos.Notes;
using Api.Models.Authentication;
using Api.Models.Notes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Notes
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private AppDbContext _appDbContext;
        private IMapper _mapper;

        public NoteController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateNote(CreateNoteDto createDto)
        {
            Note note = _mapper.Map<Note>(createDto);

            _appDbContext.Notes.Add(note);
            _appDbContext.SaveChanges();

            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            Note note = _appDbContext.Notes.FirstOrDefault(note => note.Id == id);

            if (note == null) return Unauthorized();

            return Ok(note);
        }
    }

}

