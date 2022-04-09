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
        public EventsController(AppDbContext context,
                                  IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int after, int take = 3, int page = 1)
        {
            var eventCount = await _context.Events.AsNoTracking().CountAsync() + 1;
            if (after == 0) after = eventCount;
            ViewData["EventCount"] = eventCount;
            ViewData["Take"] = take;
            List<Event> events = await _context.Events
                    .Where(e => e.Id < after && !e.IsDeleted)
                    .Take(take)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
            int totalPage = Helper.GetPageCount(eventCount, take);
            Paginate<Event> paginatedEvent = new Paginate<Event>(events, page, totalPage);
            return View(paginatedEvent);
        }

        public async Task<IActionResult> IndexWithSidebar(int after, int take = 3, int page = 1)
        {
            var eventCount = await _context.Events.AsNoTracking().CountAsync() + 1;
            if (after == 0) after = eventCount;
            ViewData["EventCount"] = eventCount;
            ViewData["Take"] = take;
            List<Event> events = await _context.Events
                    .Where(e => e.Id < after && !e.IsDeleted)
                    .Take(take)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
            int totalPage = Helper.GetPageCount(eventCount, take);
            Paginate<Event> paginatedEvent = new Paginate<Event>(events, page, totalPage);
            return View(paginatedEvent);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();
            List<EventSpeaker> eventSpeakers = await _context.EventSpeakers
                .Where(es => es.EventId == id)
                .Include(ts => ts.Event)
                .Include(ts => ts.Speaker)
                .ToListAsync();
            Event eventt = await _context.Events
                .Where(t => t.Id == id)
                .Include(t => t.EventSpeakers)
                .FirstOrDefaultAsync();
            if (eventt == null) return NotFound();
            EventVM eventVM = new EventVM()
            {
                Event = eventt,
                EventSpeakers = eventSpeakers
            };
            return View(eventVM);
        }
    }
}
