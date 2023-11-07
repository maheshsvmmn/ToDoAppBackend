using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NoetesAPI.Context;
using NoetesAPI.Models;
using NoetesAPI.Models.Dtos;
using System.Security.Claims;

namespace NoetesAPI.Controllers
{
    [Route("api/notes/")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NotesDbContext _db;
        public NoteController(NotesDbContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpPost("addnote")]
        public IActionResult AddNote([FromBody] NoteDto noteDetails)
        {
            HttpContext context = HttpContext;
            var userId = int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = _db.Users.FirstOrDefault(u => u.Id == Convert.ToInt32(userId));

            if (user == null)
            {
                return BadRequest(new {message = "user not authorized"});
            }

            Note newNote = new Note()
            {
                Title = noteDetails.Title,
                Description = noteDetails.Description
            };

            newNote.CreatedDate = DateTime.Now;
            newNote.UpdatedDate = DateTime.Now;
            newNote.UserId = userId;

            _db.Notes.Add(newNote);
            _db.SaveChanges();

            return Ok(newNote);
        }

        [Authorize]
        [HttpGet("fetchAllNotes")]
        public IActionResult GetAllNotes()
        {
            HttpContext context = HttpContext;
            var userId = int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            
            var notes = _db.Notes.Where(n => n.UserId == userId).ToList();

            return Ok(notes);
        }

        [Authorize]
        [HttpDelete("delete/{noteId}")]
        public IActionResult Delete(int noteId)
        {

            HttpContext context = HttpContext;
            var userId = int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var note = _db.Notes.Find(noteId);

            if(note == null)
            {
                return NotFound();
            }

            if(note.UserId != userId)
            {
                return Unauthorized();
            }

            _db.Remove(note);

            _db.SaveChanges();

            return Ok(new {message = "Succesfully deleted the note"});

        }

        [Authorize]
        [HttpPut("update/{noteId}")]
        public IActionResult UpdateNote(int noteId, NoteDto noteDetails)
        {
            HttpContext context = HttpContext;
            var userId = int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var note = _db.Notes.Find(noteId);

            if(note == null)
            {
                return NotFound();
            }

            if(note.UserId != userId)
            {
                return Unauthorized();
            }

            note.Title = noteDetails.Title;
            note.Description  = noteDetails.Description;
            _db.Update(note);
            _db.SaveChanges();
            return Ok(note);
        }
    }
}
