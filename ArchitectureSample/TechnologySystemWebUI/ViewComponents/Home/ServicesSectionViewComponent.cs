using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents.Home
{
    public class ServicesSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
