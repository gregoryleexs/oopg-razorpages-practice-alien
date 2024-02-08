using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Area51.Data;
using Area51.Models;

namespace Area51.Pages.Aliens
{
    public class FindAlienModel : PageModel
    {
        private readonly Area51.Data.Area51Context _Context;

        public FindAlienModel(Area51.Data.Area51Context Context)
        {
            _Context = Context;
        }

        public List<Alien> Alien { get; set; } = new List<Alien>(); //list for table display, instantiate to prevent null runtime error

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public float HeightMin { get; set; }

        [BindProperty]
        public float HeightMax { get; set; }

        [BindProperty]
        public string colour { get; set; }


        public async Task OnGetAsync()
        {
            var aliens = from a in _Context.Alien select a;
            Alien = await aliens.ToListAsync();
        }

        public async Task OnPostFindByNickNameAsync()
        {
            var aliens = from a in _Context.Alien where a.NickName.Contains(Name) select a;
            Alien = await aliens.ToListAsync();
        }

        public async Task OnPostFindByNickNameAndColourAsync()
        {
            var aliens = from a in _Context.Alien where a.NickName.Contains(Name) && a.colour.Contains(colour) select a;
            Alien = await aliens.ToListAsync();
        }

        public async Task OnPostFindByHeightAsync()
        {
            var aliens = from a in _Context.Alien where a.Height >= HeightMin && a.Height <= HeightMax select a;
            Alien = await aliens.ToListAsync();
        }



    }
}
