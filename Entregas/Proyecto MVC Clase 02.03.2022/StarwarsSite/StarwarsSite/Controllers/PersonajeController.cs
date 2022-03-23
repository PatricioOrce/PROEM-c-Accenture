using Microsoft.AspNetCore.Mvc;
using StarwarsSite.Models;

namespace StarwarsSite.Controllers
{
    public class PersonajeController : Controller
    {
        public StarwarsDB Ctx { get; set; }
        public PersonajeController(StarwarsDB ctx)
        {
            Ctx = ctx;
        }
        public IActionResult Index(string id, string nombre)
        {
            if(int.TryParse(id, out int Id))
            {
                Ctx.Personajes.Add(new Personaje(Id, nombre));
                Ctx.SaveChanges();
            }
            return View();
        }
        public IActionResult Listado()
        {
            var model = new PersonajeListadoModel();
            model.Personajes = Ctx.Personajes.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(Personaje modelo)
        {
            Ctx.Attach(modelo);
            Ctx.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Ctx.SaveChanges();
            return View(modelo);
        }
        public IActionResult Editar(string id)
        {
            Personaje model = new Personaje();
            if (id != null)
            {
                if (int.TryParse(id, out int Id))
                {
                    model = Ctx.Personajes.Find(Id);
                    if (model != null)
                    {
                        return View(model);

                    }
                }
            }
            return RedirectToAction("Index");
        }

    }
}
