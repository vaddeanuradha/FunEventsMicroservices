using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;
        public EventController(IEventService service)=> 
            _service = service;

        public async Task<IActionResult> Index(int? categoryFilterApplied,
            int? locationFilterApplied, int? page)
        {
            var itemsOnPage = 10;
            var catalog = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage, categoryFilterApplied, locationFilterApplied);
            var vm = new EventIndexViewModel
            {
                EventItems = catalog.Data,
                Categories = await _service.GetCategoriesAsync(),
                Locations = await _service.GetLocationsAsync(),
                CategoryFilterApplied = categoryFilterApplied ?? 0,
                LocationFilterApplied = locationFilterApplied ?? 0,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                }
            };

            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages-1) ? "is-disabled" : "";
            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}