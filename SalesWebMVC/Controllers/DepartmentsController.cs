using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            var list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Teste 1" });
            list.Add(new Department { Id = 2, Name = "Teste 2" });

            return View(list);
        }
    }
}
