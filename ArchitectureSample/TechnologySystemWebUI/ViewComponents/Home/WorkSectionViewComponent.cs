using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents.Home
{
    public class WorkSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
