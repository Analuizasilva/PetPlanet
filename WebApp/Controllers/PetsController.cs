using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetBusinessObject _bo;
        private readonly IClientBusinessObject _boClient;

        public PetsController(IPetBusinessObject bo, IClientBusinessObject boClient)
        {
            _bo = bo;
            _boClient = boClient;
        }

        public async Task<IActionResult> Index()
        {
            var dbPets = (await _bo.Read()).Result;

            var pets = dbPets.Select(dp => PetViewModel.Parse(dp));

            return View(pets);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petViewModel = (await _bo.GetById((Guid)id)).Result;

            var petViewModelParse = PetViewModel.Parse(petViewModel);

            if (petViewModel == null)
            {
                return NotFound();
            }

            return View(petViewModelParse);
        }

        public async Task<IActionResult> Create()
        {
            var clients = (await _boClient.Read()).Result;

            ViewBag.Clients = clients.Select(c => new SelectListItem { Text = $"{c.Name} -- {c.Identification}", Value = c.Id.ToString() });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetViewModel petViewModel)
        {
            var model = petViewModel.ToModel();
            if (ModelState.IsValid)
            {
                var createOperation = await _bo.Create(model);

                if (!createOperation.Success) return View("Error", new ErrorViewModel() { RequestId = createOperation.Exception.Message });

                return RedirectToAction(nameof(Index));
            }
            return View(petViewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            var clients = (await _boClient.Read()).Result;

            ViewBag.Clients = clients.Select(c => new SelectListItem { Text = $"{c.Name} -- {c.Identification}", Value = c.Id.ToString() });

            if (id == null) return NotFound();

            var getOperation = await _bo.GetById((Guid)id);
            if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });

            if (getOperation.Result == null) return NotFound();

            var vm = PetViewModel.Parse(getOperation.Result);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PetViewModel petViewModel)
        {
            if (id != petViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var getOperation = await _bo.GetById((Guid)id);
                if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
                if (getOperation.Result == null) return NotFound();

                var result = getOperation.Result;
                if (!petViewModel.CompareToModel(result))
                {
                    result = petViewModel.ToModel();
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
