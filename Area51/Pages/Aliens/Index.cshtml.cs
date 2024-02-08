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
    public class IndexModel : PageModel
    {
        private readonly Area51.Data.Area51Context _context;

        public IndexModel(Area51.Data.Area51Context context)
        {
            _context = context;
        }

        public IList<Alien> Alien { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Alien = await _context.Alien.ToListAsync();
        }
    }
}
