using OneCore.Modelo;
using System.Web.Mvc;
using System.Web.Routing;

namespace OneCore.Web.Controllers
{
    /// <summary>
    /// Autenticación muy básica.
    /// </summary>
    /// <remarks>
    /// Verifica un objeto en sesión para determinar si se ha iniciado sesión.
    /// En caso de que no se haya iniciado sesión, se redirecciona automáticamente al controlador de Acceso.
    /// Este esquema requiere que todos los controladores hereden de este controlador.
    /// Por supuesto, esto jamás será tan seguro como OAuth, pero servirá para la prueba.
    /// </remarks>
    public class BaseController : Controller
    {

        /// <summary>
        /// Variable en la sesión que contendrá el usuario que ha accesado al sistema.
        /// </summary>
        private const string USUARIO_ACCESO = "";

        /// <summary>
        /// Contexto de entidades.
        /// </summary>
        protected Entidades entidades;

        /// <summary>
        /// Constructor predeterminado.
        /// </summary>
        public BaseController() : base()
        {
            entidades = new Entidades();
        }

        /// <summary>
        /// Liberación de recursos.
        /// </summary>
        /// <param name="disposing">Indica si la llamada viene de Dispose o de Finalize.</param>
        protected override void Dispose(bool disposing)
        {
            // Cuando se manda a Dispose(), entonces liberamos recursos.
            if (disposing)
            {
                entidades.Dispose();
                entidades = null;
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método invocado previo a la ejecución de una acción.
        /// </summary>
        /// <param name="filterContext">Contiene el controlador invocado, la petición HTTP y sus datos de sesión.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // No aplicaremos nuestra validación para el controlador de Acceso, por obvias razones.
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Acceso")
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            // Verificamos entonces si existe en la sesión un objeto llamado usuario, y si es de tipo Usuario.
            var usuario = filterContext.HttpContext.Session[USUARIO_ACCESO];
            if (usuario == null || !(usuario is Usuario))
            {
                ViewBag.Usuario = null;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Acceso" }, { "action", "Index" } });
            }
            else
            {
                // Ponemos a la disposición general el usuario que ha accesado.
                // Todas las vistas podrán consultar sus datos.
                ViewBag.Usuario = usuario;
                // Todo seguro, continuamos con la ejecución normal.
                base.OnActionExecuting(filterContext);
            }
        }

        /// <summary>
        /// Guarda en sesión el usuario que ha accesado.
        /// </summary>
        /// <param name="usuario">Usuario con privilegios.</param>
        protected void EstablecerUsuario(Usuario usuario)
        {
            Session[USUARIO_ACCESO] = usuario;
        }

    }
}