using Application.Common.Models;
using Application.MVC.Models;
using Application.Service.Common;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        // GET: RegistrationController
        [HttpGet("Registration", Name = "get-registration")]
        public async Task<ActionResult> Registration(string sortOrder, string sortBy, string searchBy, string search, int? pageNumber, int? pageSize)
        {
            var paging = new Paging(pageNumber, pageSize);

            sortOrder = string.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder;
            ViewBag.Sorting = sortOrder;
            ViewBag.SortBy = sortBy;
            ViewBag.Search = !string.IsNullOrEmpty(search) ? search : "";
            ViewBag.SearchBy = !string.IsNullOrEmpty(searchBy) ? searchBy : "Name";
            ViewBag.CurrentPage = paging.PageNumber;
            ViewBag.PageSize = paging.PageSize;

            var result = await registrationService.GetAllAsync(new Sorting(sortOrder, sortBy), new Filtering(searchBy, search), paging);

            var pageCount = paging.TotalItemsCount / paging.PageSize;
            ViewBag.TotalPageCount = paging.TotalItemsCount % paging.PageSize == 0 ? pageCount : pageCount + 1;

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
                await registrationService.AddAsync(mapper.Map<RegistrationDTO>(registrationViewModel));
                return RedirectToAction(nameof(Registration));
            }
            catch(Exception ex)
            {
                var test = ex;
                return RedirectToAction(nameof(Registration));
            }
        }

        [Authorize]
        // GET: RegistrationController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await registrationService.GetAsync(id);
            return View(mapper.Map<RegistrationViewModel>(result));
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RegistrationViewModel registrationViewModel)
        {
            try
            {
                await registrationService.UpdateAsync(mapper.Map<RegistrationDTO>(registrationViewModel));
                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: RegistrationController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(mapper.Map<RegistrationViewModel>(await registrationService.GetAsync(id)));
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
