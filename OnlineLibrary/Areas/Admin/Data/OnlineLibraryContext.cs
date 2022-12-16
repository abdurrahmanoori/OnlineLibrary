using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Models
{
    public class OnlineLibraryContext : DbContext
    {
        public OnlineLibraryContext (DbContextOptions<OnlineLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineLibrary.Models.Category> Category { get; set; }
    }
}
