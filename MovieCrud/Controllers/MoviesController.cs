using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCrud.Entity;
using MovieCrud.Models;


namespace MovieCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;

        public MoviesController(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Movies = await _repository.ReadAllAsync();
            return Ok(Movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Movie = await _repository.ReadAsync(id);
            if (Movie == null) return NotFound();
            return Ok(Movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie Movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _repository.CreateAsync(Movie);
            return CreatedAtAction(nameof(GetById), new { id = Movie.Id }, Movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Movie Movie)
        {
            if (id <= 0) return BadRequest("Invalid ID");
            Movie.Id = id; // Assigner l'ID fourni dans l'URL
            await _repository.UpdateAsync(Movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
