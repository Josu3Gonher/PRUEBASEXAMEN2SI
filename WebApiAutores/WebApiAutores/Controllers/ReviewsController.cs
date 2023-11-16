using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetReviews()
        {
            var reviews = _context.Reviews.Include(r => r.Usuario).Include(r => r.Book).ToList();
            return Ok(reviews);
        }

        [HttpGet("{id:int}")] //api/reviews/5
        public IActionResult GetReview(int id)
        {
            var review = _context.Reviews.Include(r => r.Usuario).Include(r => r.Book).FirstOrDefault(r => r.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            // Validar lenguaje ofensivo aquí (implementación depende de tu lógica)

            _context.Reviews.Add(review);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        [HttpPut("{id:int}")] //api/reviews/5
        public IActionResult UpdateReview(int id, Review updatedReview)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            // Validar lenguaje ofensivo aquí (implementación depende de tu lógica)

            // Actualizar propiedades relevantes
            review.DescripcionReview = updatedReview.DescripcionReview;
            review.Calificacion = updatedReview.Calificacion;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/reviews/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
