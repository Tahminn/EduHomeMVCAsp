using EduHome.Models.EventRel;
using EduHome.Utilities.Pagination;
using EduHome.ViewModels.EventVMs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.Services.Interfaces
{
    public interface IEventService
    {
        Task<Paginate<Event>> GetEvents(int take, int after, int count, int page);
        Task<EventVM> GetEventById(int id)
    }
}
