using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientBusinessObject _bo;

        public ClientsController(IClientBusinessObject bo)
        {
            _bo = bo;
        }

        public async Task<IActionResult> Index()
        {
            var dbClients = (await _bo.Read()).Result;

            var clients = dbClients.Select(dc => ClientViewModel.Parse(dc));

            return View(clients);
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = (await _bo.GetById((Guid)id)).Result;

            var clientViewModelParse = ClientViewModel.Parse(clientViewModel);

            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View(clientViewModelParse);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel clientViewModel)
        {
            var model = clientViewModel.ToModel();
            if (ModelState.IsValid)
            {
                clientViewModel.Id = Guid.NewGuid();
                var createOperation = await _bo.Create(model);

                if (!createOperation.Success) return View("Error", new ErrorViewModel() { RequestId = createOperation.Exception.Message });

                return RedirectToAction(nameof(Index));
            }
            return View(clientViewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var getOperation = await _bo.GetById((Guid)id);
            if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });

            if (getOperation.Result == null) return NotFound();

            var vm = ClientViewModel.Parse(getOperation.Result);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var getOperation = await _bo.GetById((Guid)id);
                if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
                if (getOperation.Result == null) return NotFound();

                var result = getOperation.Result;
                if (!clientViewModel.CompareToModel(result))
                {
                    result = clientViewModel.ToModel();
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
