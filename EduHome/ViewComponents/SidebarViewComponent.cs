using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return (await Task.FromResult(View()));
        }
    }
}
