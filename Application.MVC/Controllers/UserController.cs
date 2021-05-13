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
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserIdentityService userIdentityService;

        public UserController(IMapper mapper, IUserIdentityService UserIdentityService)
        {
            this.mapper = mapper;
            userIdentityService = UserIdentityService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            try
            {
                await userIdentityService.AddAsync(mapper.Map<UserIdentityDTO>(userViewModel));
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserIdentityController
        [HttpGet]
        public async Task<ActionResult> Users()
        {
            var result = await userIdentityService.GetAllAsync();
            return View(mapper.Map<IEnumerable<UserViewModel>>(result));
        }

        // GET: UserIdentityController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await userIdentityService.GetAsync(id);
            return View();
        }

        // GET: UserIdentityController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: UserIdentityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(UserViewModel userViewModel)
        {
            try
            {
                await userIdentityService.AddAsync(mapper.Map<UserIdentityDTO>(userViewModel));
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserIdentityController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await userIdentityService.GetAsync(id);
            return View();
        }

        // POST: UserIdentityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserIdentityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserIdentityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(UserViewModel userViewModel)
        {
            try
            {
                var result = await userIdentityService.DeleteAsync(mapper.Map<UserIdentityDTO>(userViewModel));
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }
    }
}
