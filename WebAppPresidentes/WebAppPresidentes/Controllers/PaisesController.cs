using Microsoft.AspNetCore.Mvc;
using WebAppPresidentes.Data.AccesoDatos;
using WebAppPresidentes.Models.Entidades;

namespace WebAppPresidentes.Controllers
{
    public class PaisesController : Controller
    {
        public IActionResult ListadoPaises()
        {
            var InfPaises = new DAPaises();
            var model = InfPaises.GetPaises();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paises paises)
        {
            paises.IdPais = 0;
            var PaiseInst = new DAPaises();
            var resultado = PaiseInst.InsertPais(paises);
            if (resultado > 0)
            {
                return RedirectToAction("ListadoPaises");
            }
            else
            {
                return View(paises);
            }

        }

        public IActionResult Details(int id)
        {
            var model = new DAPaises();
            var resultado = model.GetIdPais(id);
            return View(resultado);
        }

        public IActionResult Edit(int id)
        {

            var EPaise = new DAPaises();
            var model = EPaise.GetIdPais(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Paises paises)
        {
            var EditPaise = new DAPaises();
            var model = EditPaise.UpdatePais(paises);
            if (model)
            {
                return RedirectToAction("ListadoPaises");
            }
            else
            {
                return View(paises);
            }
        }

        public IActionResult Delete(int id)
        {
            var model = new DAPaises();
            var resultado = model.GetIdPais(id);
            return View(resultado);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmeDelete(int id)
        {
            var DelPaises = new DAPaises();
            var model = DelPaises.DeletePais(id);
            return RedirectToAction("ListadoPaises");
        }
    }
}
