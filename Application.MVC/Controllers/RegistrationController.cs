using Application.Common.Models;
using Application.MVC.Models;
using Application.Service.Common;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await registrationService.GetAsync(id);
            return View();
        }

        // GET: RegistrationController/Create
        public ActionResult Add(Guid seminarId)
        {
            ViewBag.SeminarId = seminarId;
            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(RegistrationViewModel registrationViewModel)
        {
            try
            {
                //registrationViewModel.SeminarId = (Guid)ViewBag.SeminarId;
                await registrationService.AddAsync(mapper.Map<RegistrationDTO>(registrationViewModel));
                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(RegistrationViewModel registrationViewModel)
        {
            try
            {
                var result = await registrationService.DeleteAsync(mapper.Map<RegistrationDTO>(registrationViewModel));
                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }
    }
}
