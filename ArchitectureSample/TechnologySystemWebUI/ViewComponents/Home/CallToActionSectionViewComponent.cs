using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents.Home
{
    public class CallToActionSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
