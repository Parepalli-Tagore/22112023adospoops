using _22112023adospoops.Models;
using Azure.Core;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _22112023adospoops.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericRepository _repo;
        public EmployeeController(IGenericRepository repo) {
            _repo = repo;
        }
        static List<DataAccessLayer.Employee> data;
        
        static string? groupbyvalue;
        static string? orderbyvalue;
        static string? collectionType;



        [HttpGet]
        public IActionResult Index()
        {
            data = _repo.GellAllEmployess();
            return RedirectToAction("Main");
        }
        [HttpGet]
        public IActionResult Main()
        {
            switch (collectionType)
            {
                case "List":
                    if (orderbyvalue == "Order By" && groupbyvalue == "Group By")
                    {
                        data = _repo.GellAllEmployess().OrderBy(e => e.Salary).ToList();
                        var groupData = data.GroupBy(e => e.DeptName).SelectMany(x => x);

                        return View("Main", groupData);
                    }
                    else if (orderbyvalue == "Order By")
                    {
                        data = _repo.GellAllEmployess().OrderBy(e => e.Salary).ToList();
                        return View("Main", data);
                    }
                    else if (groupbyvalue == "Group By")
                    {
                        var groupData = _repo.GellAllEmployess().GroupBy(e => e.DeptName).SelectMany(x => x);
                        return View("Main", groupData);
                    }
                    break;
                case "Array":
                    if (orderbyvalue == "Order By" && groupbyvalue == "Group By")
                    {
                        Employee[] arrayData = _repo.GellAllEmployess().OrderBy(e => e.Salary).ToArray();
                        var groupArrayData = data.GroupBy(e => e.DeptName).SelectMany(x => x);

                        return View("Main", groupArrayData);
                    }
                    else if (orderbyvalue == "Order By")
                    {
                        Employee[] arrayData = _repo.GellAllEmployess().OrderBy(e => e.Salary).ToArray();
                        return View("Main", arrayData);
                    }
                    else if (groupbyvalue == "Group By")
                    {
                        var groupArrayData = _repo.GellAllEmployess().GroupBy(e => e.DeptName).SelectMany(x => x).ToArray();
                        return View("Main", groupArrayData);
                    }
                    break;
                case "ArrayList":
                    ArrayList arrayList = new ArrayList();
                    var completeData = _repo.GellAllEmployess();

                    foreach(var i in completeData)
                    {
                        arrayList.Add(i);
                    }

                    if (orderbyvalue == "Order By" && groupbyvalue == "Group By")
                    {
                        data = _repo.GellAllEmployess().OrderBy(e => e.Salary).ToList();
                        arrayList = (ArrayList)data.GroupBy(e => e.DeptName).SelectMany(x => x);

                        return View("Main", arrayList);
                    }
                    else if (orderbyvalue == "Order By")
                    {
                        arrayList = (ArrayList)_repo.GellAllEmployess().OrderBy(e => e.Salary);

                        return View("Main", arrayList);
                    }
                    else if (groupbyvalue == "Group By")
                    {
                        arrayList = (ArrayList)_repo.GellAllEmployess().GroupBy(e => e.DeptName).SelectMany(x => x);
                        return View("Main", arrayList);
                    }
                    break;
                default:
                    break;
            }


            return View("Main",data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DataAccessLayer.Employee emp)
        {
            int result = _repo.InsertEmployee(emp);
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult GroupOrder(IFormCollection formdata)
        {
            groupbyvalue = formdata["groupValue"];
            orderbyvalue = formdata["orderValue"];
            collectionType = formdata["collectionType"]; 
            string url = "/Employee/Main";

            return Json(new {status= "success" , redirectUrl= url });
        }
    }
}
