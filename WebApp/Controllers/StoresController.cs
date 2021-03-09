using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreBusinessObject _bo;
        private readonly IEmployeeBusinessObject _boEmployee;

        public StoresController(IStoreBusinessObject bo, IEmployeeBusinessObject boEmployee)
        {
            _bo = bo;
            _boEmployee = boEmployee;
        }

        public async Task<IActionResult> Index()
        {
            var dbStores = (await _bo.Read()).Result;

            var stores = dbStores.Select(ds => StoreViewModel.Parse(ds));

            return View(stores);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeViewModel = (await _bo.GetById((Guid)id)).Result;

            var storeViewModelParse = StoreViewModel.Parse(storeViewModel);

            if (storeViewModel == null)
            {
                return NotFound();
            }

            return View(storeViewModelParse);
        }

        public async Task<IActionResult> Create()
        {
            var employee = (await _boEmployee.Read()).Result;

            ViewBag.Employee = employee.Select(c => new SelectListItem { Text = $"{c.Name} -- {c.Identification} -- {c.Position}", Value = c.Id.ToString() });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StoreViewModel storeViewModel)
        {
            var model = storeViewModel.ToModel();
            if (ModelState.IsValid)
            {
                var createOperation = await _bo.Create(model);

                if (!createOperation.Success) return View("Error", new ErrorViewModel() { RequestId = createOperation.Exception.Message });

                return RedirectToAction(nameof(Index));
            }
            return View(storeViewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            var employees = (await _boEmployee.Read()).Result;

            ViewBag.Employees = employees.Select(c => new SelectListItem { Text = $"{c.Name} -- {c.Identification}", Value = c.Id.ToString() });

            if (id == null) return NotFound();

            var getOperation = await _bo.GetById((Guid)id);
            if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });

            if (getOperation.Result == null) return NotFound();

            var vm = StoreViewModel.Parse(getOperation.Result);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StoreViewModel storeViewModel)
        {
            if (id != storeViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var getOperation = await _bo.GetById((Guid)id);
                if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
                if (getOperation.Result == null) return NotFound();

                var result = getOperation.Result;
                if (!storeViewModel.CompareToModel(result))
                {
                    result = storeViewModel.ToModel();
                    var updateOperation = await _bo.Update(result);
                    if (!updateOperation.Success) return View("Error", new ErrorViewModel() { RequestId = updateOperation.Exception.Message });
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var deleteOperation = await _bo.Delete((Guid)id);

            if (!deleteOperation.Success) return View("Error", new ErrorViewModel() { RequestId = deleteOperation.Exception.Message });

            return RedirectToAction(nameof(Index));
        }
    }
}
