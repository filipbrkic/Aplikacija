using Application.Common.Models;
using Application.MVC.Models;
using Application.Service.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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
        //DBO - DATABASE OBJECT
        //DTO - DATA TRANSFER OBJECT
        //DVO - DATA VIEW OBJECT
        //REPOSITORY - DBO I DTO - ovisno o tome gdje objekt ide primjeni mapiranje
        //SERVICE - DTO - nema mapiranja 
        //CONTROLLER - DTO I DVO - ovisno o tome gdje objekt ide primjeni mapiranje
        
        //mapping -> mapper.Map<TDestination>(param)
        //param je objekt ciji tip treba postati TDestination Tip
        //primjer. iz kontrollera ide u servis objekt, 
        //kotroller metoda je primila DVO u treba ga mapirati u DTO jer metoda u servisu treba primiti DTO
        //mapper.Map<xyzDTO>(xyzDVO)

        //controller -> view - DTO -> DVO
        //controller -> service - DVO -> DTO
        //servis -> controller - DTO -> DTO
        //servis -> repository - DTO -> DTO
        //repository -> servis - DBO -> DTO
        //repository -> generic - DTO -> DBO
    }
}
