using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Area51.Data;
using Area51.Models;

namespace Area51.Pages.Aliens
{
    public class CreateModel : PageModel
    {
        private readonly Area51.Data.Area51Context _context;

        public CreateModel(Area51.Data.Area51Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Alien Alien { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Alien.Add(Alien);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
