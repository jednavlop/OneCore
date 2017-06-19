using System.Web.Mvc;

namespace OneCore.Web.Controllers
{
    /// <summary>
    /// Controlador de inicio.
    /// </summary>
    public class InicioController : BaseController
    {
        /// <summary>
        /// Página de inicio.
        /// </summary>
        /// <returns>Vista de inicio.</returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}