using Domain.Data;
using Domain.Entities.EventModel;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.Utilities.Helpers;
using Service.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.BaseModels
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;
        public EventService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Paginate<Event>> GetEvents(int take, int page)
        {
            try
            {
                List<int> EventIds = await _context.Events.OrderByDescending(e => e.Id).Select(e => e.Id).ToListAsync();
                int after = EventIds.ElementAtOrDefault(take * (page - 1));
                var count = EventIds.Count();
                List<Event> events = await _context.Events
                      .Where(c => c.Id <= after && !c.IsDeleted)
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

        public async Task<Event> GetEventById(int id)
        {
            try
            {
                Event eventt = await _context.Events
                    .Where(t => t.Id == id)
                    .Include(t => t.EventSpeakers)
                    .ThenInclude(t => t.Speaker)
                    .FirstOrDefaultAsync();
                return eventt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
