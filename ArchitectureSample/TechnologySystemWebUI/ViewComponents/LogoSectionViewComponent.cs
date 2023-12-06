using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents
{
    public class LogoSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
