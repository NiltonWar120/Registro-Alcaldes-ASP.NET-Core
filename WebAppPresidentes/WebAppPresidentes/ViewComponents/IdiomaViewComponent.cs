using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebAppPresidentes.ViewComponents
{
    public class IdiomaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult>
            InvokeAsync()

        {
            var idiomas = new List<SelectListItem>();
            idiomas.Add(new SelectListItem()
            {
                Value = "en-US",
                Text = "Ingles"
            });
            idiomas.Add(new SelectListItem()
            {
                Value = "es-PE",
                Text = "Spanish"
            });
            idiomas.Add(new SelectListItem()
            {
                Value = "fr-FR",
                Text = "French"
            });
            var currentCulture = HttpContext.Features.Get
                <IRequestCultureFeature>();
            ViewBag.IdiomaSel = currentCulture.RequestCulture.UICulture.Name;
            return View(idiomas);
        }
    }
}
