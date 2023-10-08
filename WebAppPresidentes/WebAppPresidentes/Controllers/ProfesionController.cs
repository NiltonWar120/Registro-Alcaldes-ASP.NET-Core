using Microsoft.AspNetCore.Mvc;
using WebAppPresidentes.Data.AccesoDatos;
using WebAppPresidentes.Models.Entidades;

namespace WebAppPresidentes.Controllers
{
    public class ProfesionController : Controller
    {
        public IActionResult ListadoProfesion()
        {
            var InfProfesion = new DAProfesion();
            var model = InfProfesion.GetProfesion();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Profesion Profesion)
        {
            Profesion.IdProfesion = 0;
            var ProfesioneInst = new DAProfesion();
            var resultado = ProfesioneInst.InsertProfesion(Profesion);
            if (resultado > 0)
            {
                return RedirectToAction("ListadoProfesion");
            }
            else
            {
                return View(Profesion);
            }

        }

        public IActionResult Details(int id)
        {
            var model = new DAProfesion();
            var resultado = model.GetIdProfesion(id);
            return View(resultado);
        }

        public IActionResult Edit(int id)
        {

            var EProfesione = new DAProfesion();
            var model = EProfesione.GetIdProfesion(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Profesion Profesion)
        {
            var EditProfesione = new DAProfesion();
            var model = EditProfesione.UpdateProfesion(Profesion);
            if (model)
            {
                return RedirectToAction("ListadoProfesion");
            }
            else
            {
                return View(Profesion);
            }
        }

        public IActionResult Delete(int id)
        {
            var model = new DAProfesion();
            var resultado = model.GetIdProfesion(id);
            return View(resultado);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmeDelete(int id)
        {
            var DelProfesion = new DAProfesion();
            var model = DelProfesion.DeleteProfesion(id);
            return RedirectToAction("ListadoProfesion");
        }
    }
}
