using Application.Common.Models;
using Application.MVC.Models;
using Application.Service.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Application.MVC.Controllers
{
    public class SeminarController : Controller
    {
        private readonly IMapper mapper;
        private readonly ISeminarService seminarService;

        public SeminarController(IMapper mapper, ISeminarService seminarService)
        {
            this.mapper = mapper;
            this.seminarService = seminarService;
        }

        // GET: SeminarController
        [HttpGet("Seminar", Name = "get-seminars")]
        public async Task<ActionResult> Seminar(string sortOrder, string sortBy, string searchBy, string search, int? pageNumber, int? pageSize)
        {
            var paging = new Paging(pageNumber, pageSize);

            sortOrder = string.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder;
            ViewBag.Sorting = sortOrder;
            ViewBag.SortBy = sortBy;
            ViewBag.Search = !string.IsNullOrEmpty(search) ? search : "";
            ViewBag.SearchBy = !string.IsNullOrEmpty(searchBy) ? searchBy : "Name";
            ViewBag.CurrentPage = paging.PageNumber;
            ViewBag.PageSize = paging.PageSize;

            var result = await seminarService.GetAllAsync(new Sorting(sortOrder, sortBy), new Filtering(searchBy, search), paging);

            var pageCount = paging.TotalItemsCount / paging.PageSize;
            ViewBag.TotalPageCount = paging.TotalItemsCount % paging.PageSize == 0 ? pageCount : pageCount + 1;

            return View(mapper.Map<IEnumerable<SeminarViewModel>>(result));
        }

        // GET: SeminarController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await seminarService.GetAsync(id);
            return View();
        }

        // GET: Seminar/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: SeminarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(SeminarViewModel seminarViewModel)
        {
            try
            {
                await seminarService.AddAsync(mapper.Map<SeminarDTO>(seminarViewModel));
                return RedirectToAction(nameof(Seminar));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeminarController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await seminarService.GetAsync(id);
            return View(mapper.Map<SeminarViewModel>(result));
        }

        // POST: SeminarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SeminarViewModel seminarViewModel)
        {
            try
            {
                await seminarService.UpdateAsync(mapper.Map<SeminarDTO>(seminarViewModel));
                return RedirectToAction(nameof(Seminar));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeminarController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(mapper.Map<SeminarViewModel>(await seminarService.GetAsync(id)));
        }

        // POST: SeminarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(SeminarViewModel seminarViewModel)
        {
            try
            {
                var result = await seminarService.DeleteAsync(mapper.Map<SeminarDTO>(seminarViewModel));
                return RedirectToAction(nameof(Seminar));
            }
            catch
            {
                return View();
            }
        }
    }
}
