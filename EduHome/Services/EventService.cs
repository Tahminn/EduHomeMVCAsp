using EduHome.Data;
using EduHome.Models.EventRel;
using EduHome.Services.Interfaces;
using EduHome.Utilities.Helpers;
using EduHome.Utilities.Pagination;
using EduHome.ViewModels.EventVMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;
        public EventService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Paginate<Event>> GetEvents(int take, int after, int count, int page)
        {
            try
            {
                List<Event> events = await _context.Events
                      .Where(c => c.Id < after && !c.IsDeleted)
                      .OrderByDescending(t => t.Id)
                      .ToListAsync();
                if (take > 0) events = events.Take(take).ToList();
                int totalPage = Helper.GetPageCount(count, take);
                Paginate<Event> paginatedEvent = new Paginate<Event>(events, page, totalPage);
                return paginatedEvent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventVM> GetEventById(int id)
        {
            try
            {
                List<EventSpeaker> eventSpeakers = await _context.EventSpeakers
                .Where(es => es.EventId == id)
                .Include(ts => ts.Event)
                .Include(ts => ts.Speaker)
                .ToListAsync();
                Event eventt = await _context.Events
                    .Where(t => t.Id == id)
                    .Include(t => t.EventSpeakers)
                    .FirstOrDefaultAsync();
                EventVM eventVM = new EventVM()
                {
                    Event = eventt,
                    EventSpeakers = eventSpeakers
                };
                return eventVM;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
