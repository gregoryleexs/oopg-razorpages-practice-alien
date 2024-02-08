using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Area51.Data;
using Area51.Models;

namespace Area51.Pages.Aliens
{
    public class EditModel : PageModel
    {
        private readonly Area51.Data.Area51Context _context;

        public EditModel(Area51.Data.Area51Context context)
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

            var alien =  await _context.Alien.FirstOrDefaultAsync(m => m.ID == id);
            if (alien == null)
            {
                return NotFound();
            }
            Alien = alien;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Alien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlienExists(Alien.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AlienExists(int id)
        {
            return _context.Alien.Any(e => e.ID == id);
        }
    }
}
