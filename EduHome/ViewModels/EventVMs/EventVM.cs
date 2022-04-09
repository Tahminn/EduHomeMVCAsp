using EduHome.Models.EventRel;
using System.Collections.Generic;

namespace EduHome.ViewModels.EventVMs
{
    public class EventVM
    {
        public Event Event { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}
