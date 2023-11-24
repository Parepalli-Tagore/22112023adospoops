using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace _22112023adospoops.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository _repo;
        public DepartmentController(IGenericRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetAllDepartments());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DataAccessLayer.Department d)
        {
            int result = _repo.InsertDepartment(d);
            return RedirectToAction("Index");
        }
    }
}
