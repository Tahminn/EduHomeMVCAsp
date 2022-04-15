using Domain.Entities.EventModel;
using Service.Utilities.Pagination;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEventService
    {
        Task<Paginate<Event>> GetEvents(int take, int page);
        Task<Event> GetEventById(int id);
    }
}
