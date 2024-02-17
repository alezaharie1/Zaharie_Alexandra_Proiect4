using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zaharie_Alexandra_Proiect4.Models;

namespace Zaharie_Alexandra_Proiect4.Data
{
    public class Zaharie_Alexandra_Proiect4Context : DbContext
    {
        public Zaharie_Alexandra_Proiect4Context (DbContextOptions<Zaharie_Alexandra_Proiect4Context> options)
            : base(options)
        {
        }

        public DbSet<Zaharie_Alexandra_Proiect4.Models.Course> Course { get; set; } = default!;
        public DbSet<Zaharie_Alexandra_Proiect4.Models.Mentor> Mentor { get; set; } = default!;
    }
}
