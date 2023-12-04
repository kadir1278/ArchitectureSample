using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents.Home
{
    public class HeroSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
