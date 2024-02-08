using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Area51.Data;
using Area51.Models;

namespace Area51.Pages.Aliens
{
    public class DeleteModel : PageModel
    {
        private readonly Area51.Data.Area51Context _context;

        public DeleteModel(Area51.Data.Area51Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Alien Alien { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alien = await _context.Alien.FirstOrDefaultAsync(m => m.ID == id);

            if (alien == null)
            {
                return NotFound();
            }
            else
            {
                Alien = alien;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alien = await _context.Alien.FindAsync(id);
            if (alien != null)
            {
                Alien = alien;
                _context.Alien.Remove(Alien);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
