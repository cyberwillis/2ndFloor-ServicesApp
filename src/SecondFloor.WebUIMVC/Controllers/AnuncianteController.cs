using System.Web.Mvc;
using SecondFloor.DataContracts.Messages;
using SecondFloor.ServiceContracts;
using SecondFloor.WebUIMVC.Models;
using SecondFloor.WebUIMVC.Services;

namespace SecondFloor.WebUIMVC.Controllers
{
    public class AnuncianteController : Controller
    {
        private IAnuncianteService _anuncianteService;

        public AnuncianteController(IAnuncianteService anuncianteService)
        {
            _anuncianteService = anuncianteService;
        }

        // GET: Anunciante
        public ActionResult Index()
        {
            var anunciante = new AnuncianteViewModels()
            {
                RazaoSocial = "Oficina de entretenimento adulto do tio careca",
                NomeResponsavel = "Fulano de Tal",
                Email = "careca@careca.com.br",
                Cnpj = "40.123.456.0001-63",
            };

            //anunciante.Enderecos = new List<EnderecoViewModels>();

            return View(anunciante);
        }

        [HttpPost]
        public ActionResult Index ([Bind(Exclude = "Id")] AnuncianteViewModels anunciante)
        {
            if (! ModelState.IsValid )
            {
                return View(anunciante);
            }

            var request = new CadastroAnuncianteRequest(){ Anunciante = anunciante.ConvertToAnuncianteDto() };
            var response = _anuncianteService.CadastrarAnunciante(request);
            if (response.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(anunciante);
            }
        }
    }
}