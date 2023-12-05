using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents
{
    public class HeroSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
