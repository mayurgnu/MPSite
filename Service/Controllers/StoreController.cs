using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore;
using DomainModels.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [EnableCors("crossdomain")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        IUnitOfWork uow;
        public StoreController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return uow.ProductRepo.GetAll();
        }
        [HttpPost]
        public int SaveCart(Cart model)
        {
            return uow.OrderRepo.SaveCart(model);
        }
    }
}