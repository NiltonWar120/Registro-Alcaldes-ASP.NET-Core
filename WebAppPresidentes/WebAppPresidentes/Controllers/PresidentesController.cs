using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppPresidentes.Data.AccesoDatos;
using WebAppPresidentes.Models.Entidades;

namespace WebAppPresidentes.Controllers
{
    [Authorize]
    public class PresidentesController : Controller
    {
        private ServiceReference1.ServicePresidentesClient service = new
            ServiceReference1.ServicePresidentesClient();
        public IActionResult ServiceIndexWCF()
        {
            ViewBag.Servicio = service.GetPresidenteAsync().Result;
            return View();
        }
        public IActionResult ListadoPresidentes()
        {
            var InfDetalle = new DAPresidentes();
            var model = InfDetalle.GetPresidentes();
            return View(model);
        }
        public IActionResult Create()
        {
            var LConyugue = new DAConyuge();
            ViewBag.LConyugue = LConyugue.GetConyuge();

            var LPaises = new DAPaises();
            ViewBag.LPaises = LPaises.GetPaises();

            var LProfesion = new DAProfesion();
            ViewBag.LProfesion = LProfesion.GetProfesion();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Presidentes presidentes)
        {
            presidentes.IdPresidente = 0;
            var UsuarioInst = new DAPresidentes();
            var resultado = UsuarioInst.InsertPresidente(presidentes);
            if (resultado > 0)
            {
                return RedirectToAction("ListadoPresidentes");
            }
            else
            {
                return View(presidentes);
            }

        }

        public IActionResult Details(int id)
        {
            var model = new DAPresidentes();
            var resultado = model.GetIdPresidentes(id);
            return View(resultado);
        }

        public IActionResult Edit(int id)
        {
            var LConyugue = new DAConyuge();
            ViewBag.LConyugue = LConyugue.GetConyuge();

            var LPaises = new DAPaises();
            ViewBag.LPaises = LPaises.GetPaises();

            var LProfesion = new DAProfesion();
            ViewBag.LProfesion = LProfesion.GetProfesion();

            var EPresi = new DAPresidentes();
            var model = EPresi.GetIdPresidentes(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Presidentes presidentes)
        {
            var EditPresidentes = new DAPresidentes();
            var model = EditPresidentes.UpdatePresidente(presidentes);
            if (model)
            {
                return RedirectToAction("ListadoPresidentes");
            }
            else
            {
                return View(presidentes);
            }
        }

        public IActionResult Delete(int id)
        {
            var model = new DAPresidentes();
            var resultado = model.GetIdPresidentes(id);
            return View(resultado);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmeDelete(int id)
        {
            var DelUsuarios = new DAPresidentes();
            var model = DelUsuarios.DeletePresidente(id);
            return RedirectToAction("ListadoPresidentes");
        }
    }
}
