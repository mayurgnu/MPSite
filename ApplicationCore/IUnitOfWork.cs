using BAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
    public interface IUnitOfWork
    {
        IAuthenticateRepository AuthenticateRepo { get; }
        ICategoryRepository CategoryRepo { get; }
        IProductRepository ProductRepo { get; }
        IOrderRepository OrderRepo { get; }

        int SaveChanges();
    }
}
