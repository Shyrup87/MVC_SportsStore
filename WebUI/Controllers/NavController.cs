using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;
        public NavController(IProductRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;    
            IEnumerable<string> categories = repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c);
            return PartialView(categories);
        }
    }
}