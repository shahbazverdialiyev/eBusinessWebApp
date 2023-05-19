using eBusinessWebApp.DAL;
using eBusinessWebApp.ViewModels.TeamVM;
using Microsoft.AspNetCore.Mvc;

namespace eBusinessWebApp.ViewComponents
{
    public class TeamViewComponent:ViewComponent
    {
        private readonly eBusinessDbContext _eBusinessDbContext;

        public TeamViewComponent(eBusinessDbContext eBusinessDbContext)
        {
            _eBusinessDbContext = eBusinessDbContext;
        }

        public IViewComponentResult Invoke()
        {
            return View(_eBusinessDbContext.Members.ToList());
        }
    }
}
