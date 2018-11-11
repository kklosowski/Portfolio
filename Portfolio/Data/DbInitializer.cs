using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Projects.Any())
            {
                applicationDbContext.AddRange
                (
                    
                    
                );
            }
        }
    }
}
