using Application.Common.Models;
using Application.MVC.Models;
using Application.Service;
using Application.Service.Common;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.MVC.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRegistrationService registrationService;

        public RegistrationController(IMapper mapper, IRegistrationService registrationService)
        {
            this.mapper = mapper;
            this.registrationService = registrationService;
        }

        // GET: RegistrationController
        [HttpGet("registration", Name = "get-registration")]
        public async Task<ActionResult> Registration()
        {
            var result = await registrationService.GetAllAsync();
            return View(mapper.Map<IEnumerable<RegistrationViewModel>>(result));
        }

        // GET: RegistrationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await registrationService.GetAsync(id);
            return View();
        }

        // GET: RegistrationController/Create
        public async Task<ActionResult> Create(RegistrationViewModel registrationViewModel)
        {
            var result = await registrationService.AddAsync(mapper.Map<RegistrationDTO>(registrationViewModel));
            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await registrationService.GetAsync(id);
            return View();
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await registrationService.DeleteAsync(id);
            return View();
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }
    }
}
