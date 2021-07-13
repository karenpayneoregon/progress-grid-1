using GridExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridExample.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProduceDataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Produce.Any())
            {
                return;   // DB has been seeded
            }

            var produce = new Produce[]
            {
            new Produce{ Apples = 1, Oranges = 1, TotalAmount = 1},
            new Produce{ Apples = 2, Oranges = 2, TotalAmount = 4},
            new Produce{ Apples = 3, Oranges = 3, TotalAmount = 9},
            new Produce{ Apples = 4, Oranges = 4, TotalAmount = 16},
            };

            foreach (Produce p in produce)
            {
                context.Produce.Add(p);
            }
            context.SaveChanges();
        }
    }
}
