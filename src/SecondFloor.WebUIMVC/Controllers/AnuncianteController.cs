using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondFloor.WebUIMVC.Models;

namespace SecondFloor.WebUIMVC.Controllers
{
    public class AnuncianteController : Controller
    {
        // GET: Anunciante
        public ActionResult Index()
        {
            var anunciante = new AnuncianteViewModels();

            //anunciante.Enderecos = new List<EnderecoViewModels>();

            return View(anunciante);
        }

        [HttpPost]
        public ActionResult Index ([Bind(Exclude = "Id")] AnuncianteViewModels anunciante)
        {
            if (! ModelState.IsValid )
            {
                //anunciante.Enderecos = new LinkedList<EnderecoViewModels>();

                return View(anunciante);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}