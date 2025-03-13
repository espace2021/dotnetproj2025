using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCrud.Models;
using System.Collections.Generic;
using System.Linq;

public class CreateReviewModel : PageModel
{
    private readonly MovieContext _context;

    public CreateReviewModel(MovieContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Review NewReview { get; set; } = new();  

    public List<SelectListItem> Movies { get; set; } = new();

    public void OnGet()
    {
        Movies = _context.Movie
            .Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            })
            .ToList();

        NewReview = new Review();
    }

    public IActionResult OnPost()
    {
        Console.WriteLine("MovieId received: " + NewReview.MovieId); // Debug

        if (!ModelState.IsValid)
        {
            // Recharge la liste des films
            Movies = _context.Movie
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                })
                .ToList();

            return Page();
        }

        _context.Review.Add(NewReview);
        _context.SaveChanges();
        return RedirectToPage("ListReviews", new { id = 1 });
    }

}

