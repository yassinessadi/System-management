using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_system_management_crm.Data.Services;
using school_system_management_crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Controllers
{
    public class DepartementsController : Controller
    {
        private readonly IDepartementService _Service;

        public DepartementsController(IDepartementService Service)
        {
            _Service = Service;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _Service.GetAllAsync());
        }

        //Details
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _Service.GetByIdAsync(id);
            if (result ==null)
            {
                return View("NotFound");
            }
            return View(result);
        }

        //Get : Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }


        //Post : Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            _Service.AddAsync(department);
            return RedirectToAction(nameof(Index));
        }

        //Get : Delete
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Service.GetByIdAsync(id);
            if (result ==null)
            {
                return View("NotFound");
            }
            return View(result);
        }

        //Post : Delete
        [Authorize(Roles = "Admin")]
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var result = await _Service.GetByIdAsync(id);
            if (result == null)
            {
                return View("NotFound");
            }
            await _Service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Edit
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _Service.GetByIdAsync(id);
            if (result ==null)
            {
                return View("NotFound");
            }
            return View(result);
        }

        //Post Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Name")]Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            await _Service.UpdateAsync(id, department);
            return RedirectToAction(nameof(Index));
        }
    }
}
