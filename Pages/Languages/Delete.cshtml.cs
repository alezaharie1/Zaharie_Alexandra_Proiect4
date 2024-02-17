using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zaharie_Alexandra_Proiect4.Data;
using Zaharie_Alexandra_Proiect4.Models;

namespace Zaharie_Alexandra_Proiect4.Pages.Languages
{
    public class DeleteModel : PageModel
    {
        private readonly Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context _context;

        public DeleteModel(Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Language Language { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language.FirstOrDefaultAsync(m => m.ID == id);

            if (language == null)
            {
                return NotFound();
            }
            else
            {
                Language = language;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language.FindAsync(id);
            if (language != null)
            {
                Language = language;
                _context.Language.Remove(Language);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
