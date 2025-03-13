using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCrud.Entity;
using MovieCrud.Models;

namespace MovieCrud.Pages
{
    public class ListReviewsModel : PageModel
    {
        private readonly IRepository<Review> repository;
        public ListReviewsModel(IRepository<Review> repository)
        {
            this.repository = repository;
        }

        public List<Review> ReviewList { get; set; }

        public async Task OnGet()
        {
            ReviewList = await repository.ReadAllIncludeAsync(r => r.Movie);

        }

    }
}
