using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;
using WebApplication8.Models.Data;

namespace WebApplication8.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public CompanyController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            _dbcontext.Companies.AddRange(
            new Company { Name = "XYZ Corporation", Employees = 80000},
            new Company { Name = "Tech Innovators", Employees = 120000},
            new Company { Name = "GlobalTech Solutions", Employees = 75000},
            new Company { Name = "Future Enterprises", Employees = 105000},
            new Company { Name = "InnovateTech Inc.", Employees = 95000}

        );
            _dbcontext.SaveChanges();
            var companies = _dbcontext.Companies.ToList();
            return View(companies);
        }
    }
}
