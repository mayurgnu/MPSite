using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Entities;
using DomainModels.Models;
using BAL.Abstraction;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;

namespace BAL.Implementation
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public CategoryRepository(DbContext db)
        {
            this.db = db;
        }

    }
}
