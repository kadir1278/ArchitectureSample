using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents
{
    public class BreadcrumbSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string pageName)
        {
            return View(model: pageName);
        }
    }
}
