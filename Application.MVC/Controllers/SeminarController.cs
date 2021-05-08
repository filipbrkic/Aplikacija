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
        [HttpGet("seminar", Name = "get-seminars")]
        public async Task<ActionResult> Seminar()
        {
            var result = await seminarService.GetAllAsync();
            return View(mapper.Map<IEnumerable<SeminarViewModel>>(result));
        }

        // GET: SeminarController/Details/5
        public async Task<ActionResult> Details(int id)
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
        public async Task<ActionResult> Edit(int id)
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
        public async Task<ActionResult> Delete(int id)
        {
            var result = await seminarService.DeleteAsync(id);
            return RedirectToAction(nameof(Seminar));
        }
    }
}
