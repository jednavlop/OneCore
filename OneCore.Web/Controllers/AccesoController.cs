using OneCore.Modelo;
using System.Linq;
using System.Web.Mvc;

namespace OneCore.Web.Controllers
{
    /// <summary>
    /// Controlador de inicio de sesión.
    /// </summary>
    public class AccesoController : BaseController
    {
        /// <summary>
        /// Página de inicio de sesión.
        /// </summary>
        /// <returns>Formulario de acceso.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Intento de inicio de sesión.
        /// </summary>
        /// <returns>Redirección al controlador de inicio en caso de éxito.</returns>
        [HttpPost]
        public ActionResult Entrar(string usuario, string contraseña)
        {
            // Validamos formulario incompleto y llamadas de terceros.
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                return Json(false);
            }
            else
            {
                // Instanciamos el contexto de entidades de nuestra aplicación, es decir, nuestra capa de datos.
                using (Entidades entidades = new Entidades())
                {
                    // Buscamos el usuario con el nombre y contraseña especificados, si no se encuentra, FirstOrDefault devuelve nulo.
                    Usuario acceso = entidades.Usuarios.FirstOrDefault(u => u.Nombre.Equals(usuario) && u.Contraseña.Equals(contraseña));
                    // Siendo nulo o no, es conveniente almacenarlo en la sesión; claramente sobreescribirá una sesión previa, si la hubiera.
                    EstablecerUsuario(acceso);
                    // Devolvemos simplemente un valor booleano, si hemos autenticado el usuario o no.
                    return Json(acceso != null);
                }
            }
        }

        /// <summary>
        /// Cierra la sesión de usuario.
        /// </summary>
        /// <returns>Vista de adiós.</returns>
        public ActionResult Salir()
        {
            // Eliminamos el objeto de usuario de sesión.
            EstablecerUsuario(null);
            // Retornamo una vista de despedida.
            return View();
        }

    }
}