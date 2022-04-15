using Domain.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
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
        public async Task<IActionResult> Index(int take = 3, int page = 1)
        {
            ViewData["Take"] = take;
            var paginatedEvent = await _eventService.GetEvents(take, page);
            if (paginatedEvent == null) return NotFound();
            return View(paginatedEvent);
        }

        public async Task<IActionResult> IndexWithSidebar(int take = 4, int page = 1)
        {
            ViewData["Take"] = take;
            var paginatedEvent = await _eventService.GetEvents(take, page);
            if (paginatedEvent == null) return NotFound();
            return View(paginatedEvent);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();
            var eventt = await _eventService.GetEventById(id);
            if (eventt is null) return NotFound();
            return View(eventt);
        }
    }
}
