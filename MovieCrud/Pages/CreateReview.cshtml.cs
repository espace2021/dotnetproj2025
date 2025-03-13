using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCrud.Entity;
using MovieCrud.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CreateReviewModel : PageModel
{
    private readonly IRepository<Movie> _movieRepository;
    private readonly IRepository<Review> _reviewRepository;

    public CreateReviewModel(IRepository<Movie> movieRepository, IRepository<Review> reviewRepository)
    {
        _movieRepository = movieRepository;
        _reviewRepository = reviewRepository;
    }

    [BindProperty]
    public Review NewReview { get; set; } = new();

    public List<SelectListItem> Movies { get; set; } = new();

    public async Task OnGet()
    {
        var movies = await _movieRepository.ReadAllAsync();
        Movies = movies
            .Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            })
            .ToList();

        NewReview = new Review();
    }

    public async Task<IActionResult> OnPost()
    {
        Console.WriteLine("MovieId received: " + NewReview.MovieId);

        if (!ModelState.IsValid)
        {
            var movies = await _movieRepository.ReadAllAsync();
            Movies = movies
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                })
                .ToList();

            return Page();
        }

        await _reviewRepository.CreateAsync(NewReview);
        return RedirectToPage("ListReviews", new { id = 1 });
    }
}
