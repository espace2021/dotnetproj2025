using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCrud.Entity;
using MovieCrud.Models;
using System.Linq.Expressions;

namespace MovieCrud.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IRepository<Movie> repository;
        public SearchModel(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Movie movie { get; set; }

        public List<Movie> movieList { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Expression<Func<Movie, bool>> filter = m => m.Name == movie.Name;
            movieList = await repository.ReadAllAsync(filter);
            return Page();
        }
    }
}
