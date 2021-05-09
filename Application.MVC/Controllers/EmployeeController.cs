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
    public class EmployeeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IMapper mapper, IEmployeeService employeeService)
        {
            this.mapper = mapper;
            this.employeeService = employeeService;
        }

        // GET: EmployeeController
        [HttpGet("employee", Name = "get-employee")]
        public async Task<ActionResult> Employee()
        {
            var result = await employeeService.GetAllAsync();
            return View(mapper.Map<IEnumerable<EmployeeViewModel>>(result));
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await employeeService.GetAsync(id);
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(EmployeeViewModel employeeViewModel)
        {
            try
            {
                await employeeService.AddAsync(mapper.Map<EmployeeDTO>(employeeViewModel));
                return RedirectToAction(nameof(Employee));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await employeeService.GetAsync(id);
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Employee));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var result = await employeeService.DeleteAsync(mapper.Map<EmployeeDTO>(employeeViewModel));
                return RedirectToAction(nameof(Employee));
            }
            catch
            {
                return View();
            }
        }
    }
}
