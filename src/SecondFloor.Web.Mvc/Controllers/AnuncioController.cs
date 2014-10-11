using SecondFloor.ServiceContracts;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class AnuncioController
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }
    }
}