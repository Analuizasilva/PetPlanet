using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeBusinessObject _bo;
        private readonly IStoreBusinessObject _boStore;

        public EmployeesController(IEmployeeBusinessObject bo, IStoreBusinessObject boStore)
        {
            _bo = bo;
            _boStore = boStore;
        }

        public async Task<IActionResult> Index()
        {
            var dbEmployees = (await _bo.Read()).Result;

            var employees = dbEmployees.Select(de => EmployeeViewModel.Parse(de));

            return View(employees);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeViewModel = (await _bo.GetById((Guid)id)).Result;

            var employeeViewModelParse = EmployeeViewModel.Parse(employeeViewModel);

            if (employeeViewModel == null)
            {
                return NotFound();
            }

            return View(employeeViewModelParse);
        }

        public async Task<IActionResult> Create()
        {
            var stores = (await _boStore.Read()).Result;

            ViewBag.Stores = stores.Select(c => new SelectListItem { Text = $"{c.Name} -- {c.Address}", Value = c.Id.ToString() });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            var model = employeeViewModel.ToModel();
            if (ModelState.IsValid)
            {
                employeeViewModel.Id = Guid.NewGuid();
                var createOperation = await _bo.Create(model);

                if (!createOperation.Success) return View("Error", new ErrorViewModel() { RequestId = createOperation.Exception.Message });

                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {

            var stores = (await _boStore.Read()).Result;

            ViewBag.Stores = stores.Select(c => new SelectListItem { Text = $"{c.Name} -- {c.Address}", Value = c.Id.ToString() }); 

            if (id == null) return NotFound();

            var getOperation = await _bo.GetById((Guid)id);
            if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });

            if (getOperation.Result == null) return NotFound();

            var vm = EmployeeViewModel.Parse(getOperation.Result);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var getOperation = await _bo.GetById((Guid)id);
                if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
                if (getOperation.Result == null) return NotFound();

                var result = getOperation.Result;
                if (!employeeViewModel.CompareToModel(result))
                {
                    result = employeeViewModel.ToModel();
                    var updateOperation = await _bo.Update(result);
                    if (!updateOperation.Success) return View("Error", new ErrorViewModel() { RequestId = updateOperation.Exception.Message });
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var deleteOperation = await _bo.Delete((Guid)id);

            if (!deleteOperation.Success) return View("Error", new ErrorViewModel() { RequestId = deleteOperation.Exception.Message });

            return RedirectToAction(nameof(Index));
        }
    }
}