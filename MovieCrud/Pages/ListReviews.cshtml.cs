using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCrud.Models;
using Microsoft.EntityFrameworkCore;

public class ListReviewsModel : PageModel
{
    private readonly MovieContext _context;

    public ListReviewsModel(MovieContext context)
    {
        _context = context;
    }

    // Vous pouvez utiliser Include pour charger le film associé
    public List<Review> Reviews { get; set; } = new();

    public void OnGet()
    {
        Reviews = _context.Review
            .Include(r => r.Movie)
            .ToList();
    }
}
