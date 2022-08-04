using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using school_system_management_crm.Data;
using school_system_management_crm.Data.Services;
using school_system_management_crm.Data.ViewModel;
using school_system_management_crm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmpoleeService _Service;
        public HomeController(IEmpoleeService Service)
        {
            _Service = Service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _Service.GetAllAsync(E => E.Department);
            return View(result);
        }

        //Filter
        [Authorize]
        public async Task<IActionResult> Filter(string SearchString)
        {
            var result = await _Service.GetAllAsync(E => E.Department);

            if (!string.IsNullOrEmpty(SearchString))
            {
                var FilterResult = result.Where(c => c.Name.ToUpper().Contains(SearchString.ToUpper()) || c.Address.Contains(SearchString)).ToList();
                return View("Index", FilterResult);
            }
            return View("Index", result);
        }

        //Get : Create
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var dropdown = await _Service.GetItemDropDown();
            ViewBag.DepartementId = new SelectList(dropdown.Departments, "Id", "Name");
            return View();
        }

        //Post : Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(EmpolyeeVM empolyee)
        {
            if (!ModelState.IsValid)
            {
                var dropdown = await _Service.GetItemDropDown();
                ViewBag.DepartementId = new SelectList(dropdown.Departments, "Id", "Name");
                return View(empolyee);
            }
            await _Service.AddEmployeeAsync(empolyee);
            return RedirectToAction(nameof(Index));
        }

        //Get : Edit
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _Service.GetByIdAsync(id);

            if (result == null) return View("NotFound");
            var Employeedata = new EmpolyeeVM()
            {
                Name = result.Name,
                Address = result.Address,
                StartDate = result.StartDate,
                EndDate = result.EndDate,
                Salary = result.Salary,
                DepartmentId = result.DepartmentId
            };
            var dropdown = await _Service.GetItemDropDown();
            ViewBag.DepartementId = new SelectList(dropdown.Departments, "Id", "Name");
            return View(Employeedata);
        }

        //Post Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, EmpolyeeVM empolyee)
        {
            if (id != empolyee.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var dropdown = await _Service.GetItemDropDown();
                ViewBag.DepartementId = new SelectList(dropdown.Departments, "Id", "Name");
                View(empolyee);
            }
            await _Service.UpdateEmployeeAsync(empolyee);
            return RedirectToAction(nameof(Index));
        }
    }
}
