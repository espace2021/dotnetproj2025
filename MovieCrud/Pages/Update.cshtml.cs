using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCrud.Entity;
using MovieCrud.Models;

namespace MovieCrud.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly IRepository<Movie> repository;
        public UpdateModel(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Movie movie { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            movie = await repository.ReadAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                await repository.UpdateAsync(movie);

                return RedirectToPage("Read", new { id = 1 });
            }
            else
                return Page();
        }
    }
}
