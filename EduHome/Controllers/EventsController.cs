using EduHome.Data;
using EduHome.Models.EventRel;
using EduHome.Services.Interfaces;
using EduHome.Utilities.Helpers;
using EduHome.Utilities.Pagination;
using EduHome.ViewModels.EventVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IEventService _eventService;
        public EventsController(AppDbContext context,
                                IWebHostEnvironment env,
                                IEventService eventService)
        {
            _context = context;
            _env = env;
            _eventService = eventService;  
        }
        public async Task<IActionResult> Index(int after, int take = 3, int page = 1)
        {
            var lastBlog = _context.Events.OrderByDescending(t => t.Id).First();
            int lastId = lastBlog.Id;
            if (after == 0) after = lastId + 1;
            var count = await _context.Events.Where(b => !b.IsDeleted).AsNoTracking().CountAsync();
            ViewData["EventCount"] = count +1;
            ViewData["Take"] = take;
            var paginatedEvent = await _eventService.GetEvents(take, after, count, page);
            return View(paginatedEvent);
        }

        public async Task<IActionResult> IndexWithSidebar(int after, int take = 4, int page = 1)
        {
            var lastBlog = _context.Events.OrderByDescending(t => t.Id).First();
            int lastId = lastBlog.Id;
            if (after == 0) after = lastId + 1;
            var count = await _context.Events.Where(b => !b.IsDeleted).AsNoTracking().CountAsync();
            ViewData["EventCount"] = count + 1;
            ViewData["Take"] = take;
            var paginatedEvent = await _eventService.GetEvents(take, after, count, page);
            return View(paginatedEvent);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();
            var eventSpeakers = await _eventService.GetEventById(id);
            if(eventSpeakers is null) return NotFound();
            return View(eventSpeakers);
        }
    }
}
