﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context _context;

        public IndexModel(Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context context)
        {
            _context = context;
        }

        public IList<Language> Language { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Language = await _context.Language.ToListAsync();
        }
    }
}
