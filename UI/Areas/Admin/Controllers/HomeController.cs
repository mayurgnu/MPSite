using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork _uow) : base(_uow)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}