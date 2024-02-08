using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Area51.Data;
using Area51.Models;

namespace Area51.Pages.Aliens
{
    public class AddAlienModel : PageModel
    {
        private readonly Area51.Data.Area51Context _Context;

        public AddAlienModel(Area51.Data.Area51Context Context)
        {
            _Context = Context;
        }

        public Alien Alien { get; set; } = new Alien(); //INSTANTIATE to prevent null runtime error

        [BindProperty]
        public string NickName { get; set; }

        [BindProperty]
        public DateTime DateFound { get; set; } = DateTime.Now;

        [BindProperty]
        public float Height { get; set; }

        [BindProperty]
        public float Weight { get; set; }

        [BindProperty]
        public string colour { get; set; }

        [BindProperty]
        public string description { get; set; }

        public string Errors { get; set; } = "";

        public void OnGet()
        {
        }

        public IActionResult OnPostValidate()
        {
            if(!ModelState.IsValid)
            {
                Errors = "Validation Error!";
                return Page();
            }
            else
            {
                Errors = "Good to submit!";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostSubmitAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                Alien.NickName = NickName;
                Alien.DateFound = DateFound;
                Alien.Height = Height;
                Alien.Weight = Weight;
                Alien.colour = colour;
                Alien.description = description;
                _Context.Alien.Add(Alien);
                await _Context.SaveChangesAsync();
                return Page();
            }
        }
    }
}
