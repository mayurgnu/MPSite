﻿using ApplicationCore;
using BAL.Abstraction;
using DomainModels.Entities;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace BAL.Implementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public ProductRepository(DbContext db)
        {
            this.db = db;
        }
    }
}
