using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.ViewComponents.Home
{
    public class CounterSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
