using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents
{
    public class CallToActionSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
