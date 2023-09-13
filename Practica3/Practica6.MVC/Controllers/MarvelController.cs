using Practica3.Logic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class MarvelController : Controller
    {
        private readonly MarvelLogic logic = new MarvelLogic();

        // GET: Marvel
        public async Task<ActionResult> Index()
        {
            var response = await logic.GetCharactersAsync();
            var marvelApiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Practica3.Entities.DTO.MarvelDTO.MarvelApiResponse>(response);
            return View(marvelApiResponse);
        }
    }
}
