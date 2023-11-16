using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Dtos;
using WebApiAutores.Dtos.Reviews;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [Route("api/comentarios")]
    [ApiController]
    [Authorize]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetComentarios()
        {
            var comments = _context.Comentarios.Include(c => c.Usuario).Include(c => c.Review).ToList();
            return Ok(comments);
        }

        [HttpGet("{id:int}")] // api/comentarios/5
        public IActionResult GetComentarioById(int id)
        {
            var comment = _context.Comentarios.Include(c => c.Usuario).Include(c => c.Review).FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPost]
        public IActionResult CreateComentario( Comentario comment)
        {
            // Validar lenguaje ofensivo aquí (implementación depende de tu lógica)

            _context.Comentarios.Add(comment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetComentarioById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id:int}")] //api/comentarios/5
        public IActionResult UpdateComment(int id, [FromBody] Comentario updatedComment)
        {
            var comment = _context.Comentarios.FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            // Validar lenguaje ofensivo aquí (implementación depende de tu lógica)

            // Actualizar propiedades relevantes
            comment.DescripcionComentario = updatedComment.DescripcionComentario;
            comment.Respuesta = updatedComment.Respuesta;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")] //  api/cometarios/5
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.Comentarios.FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comment);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<ReviewDto>>> AddComment(Comentario comment)
        {
            // Lógica para agregar un comentario
            return null;
        }
    }
}
