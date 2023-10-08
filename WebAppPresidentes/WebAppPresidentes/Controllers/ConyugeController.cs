using Microsoft.AspNetCore.Mvc;
using WebAppPresidentes.Data.AccesoDatos;
using WebAppPresidentes.Models.Entidades;

namespace WebAppPresidentes.Controllers
{
    public class ConyugeController : Controller
    {
        public IActionResult ListadoConyuge()
        {
            var InfConyuge = new DAConyuge();
            var model = InfConyuge.GetConyuge();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Conyuge Conyuge)
        {
            Conyuge.IdConyuge = 0;
            var ConyugeeInst = new DAConyuge();
            var resultado = ConyugeeInst.InsertConyuge(Conyuge);
            if (resultado > 0)
            {
                return RedirectToAction("ListadoConyuge");
            }
            else
            {
                return View(Conyuge);
            }

        }

        public IActionResult Details(int id)
        {
            var model = new DAConyuge();
            var resultado = model.GetIdConyuge(id);
            return View(resultado);
        }

        public IActionResult Edit(int id)
        {

            var EConyugee = new DAConyuge();
            var model = EConyugee.GetIdConyuge(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Conyuge Conyuge)
        {
            var EditConyugee = new DAConyuge();
            var model = EditConyugee.UpdateConyuge(Conyuge);
            if (model)
            {
                return RedirectToAction("ListadoConyuge");
            }
            else
            {
                return View(Conyuge);
            }
        }

        public IActionResult Delete(int id)
        {
            var model = new DAConyuge();
            var resultado = model.GetIdConyuge(id);
            return View(resultado);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmeDelete(int id)
        {
            var DelConyuge = new DAConyuge();
            var model = DelConyuge.DeleteConyuge(id);
            return RedirectToAction("ListadoConyuge");
        }
    }
}
