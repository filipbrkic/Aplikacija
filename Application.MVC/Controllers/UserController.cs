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
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserIdentityService userIdentityService;

        public UserController(IMapper mapper, IUserIdentityService userIdentityService)
        {
            this.mapper = mapper;
            this.userIdentityService = userIdentityService;
        }

        // GET: UserController
        [HttpGet("Users", Name = "get-users")]
        public async Task<ActionResult> Users(string sortOrder, string sortBy, string searchBy, string search, int? pageNumber, int? pageSize)
        {
            var paging = new Paging(pageNumber, pageSize);

            sortOrder = string.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder;
            ViewBag.Sorting = sortOrder;
            ViewBag.SortBy = sortBy;
            ViewBag.Search = !string.IsNullOrEmpty(search) ? search : "";
            ViewBag.SearchBy = !string.IsNullOrEmpty(searchBy) ? searchBy : "Name";
            ViewBag.CurrentPage = paging.PageNumber;
            ViewBag.PageSize = paging.PageSize;

            var result = await userIdentityService.GetAllAsync(new Sorting(sortOrder, sortBy), new Filtering(searchBy, search), paging);

            var pageCount = paging.TotalItemsCount / paging.PageSize;
            ViewBag.TotalPageCount = paging.TotalItemsCount % paging.PageSize == 0 ? pageCount : pageCount + 1;

            return View(mapper.Map<IEnumerable<UserViewModel>>(result));
        }

        // GET: UserIdentityController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await userIdentityService.GetAsync(id);
            return View();
        }

        // GET: UserIdentityController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await userIdentityService.GetAsync(id);
            return View(mapper.Map<UserViewModel>(result));
        }

        // POST: UserIdentityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel userViewModel)
        {
            try
            {
                await userIdentityService.UpdateAsync(mapper.Map<UserIdentityDTO>(userViewModel));
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserIdentityController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(mapper.Map<UserViewModel>(await userIdentityService.GetAsync(id)));
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
