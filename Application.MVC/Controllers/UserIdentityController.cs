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
    public class UserIdentityController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserIdentityService userIdentityService;

        public UserIdentityController(IMapper mapper, IUserIdentityService UserIdentityService)
        {
            this.mapper = mapper;
            this.userIdentityService = UserIdentityService;
        }

        // GET: UserIdentityController
        [HttpGet("useridentity", Name = "get-useridentity")]
        public async Task<ActionResult> UserIdentity()
        {
            var result = await userIdentityService.GetAllAsync();
            return View(mapper.Map<IEnumerable<UserIdentityViewModel>>(result));
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
        public async Task<ActionResult> Add(UserIdentityViewModel userIdentityViewModel)
        {
            try
            {
                await userIdentityService.AddAsync(mapper.Map<UserIdentityDTO>(userIdentityViewModel));
                return RedirectToAction(nameof(UserIdentity));
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
                return RedirectToAction(nameof(UserIdentity));
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
        public async Task<ActionResult> Delete(UserIdentityViewModel userIdentityViewModel)
        {
            try
            {
                var result = await userIdentityService.DeleteAsync(mapper.Map<UserIdentityDTO>(userIdentityViewModel));
                return RedirectToAction(nameof(UserIdentity));
            }
            catch
            {
                return View();
            }
        }
    }
}
