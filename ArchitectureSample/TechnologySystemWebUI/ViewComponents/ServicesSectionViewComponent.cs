using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents
{
    public class ServicesSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
