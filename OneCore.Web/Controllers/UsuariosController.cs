using OneCore.Modelo;
using System.Linq;
using System.Web.Mvc;

namespace OneCore.Web.Controllers
{
    /// <summary>
    /// Gestión de usuarios mediante este controlador CRUD.
    /// </summary>
    public class UsuariosController : BaseController
    {
        /// <summary>
        /// Devuelve una lista sencilla de los usuarios registrados.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public ActionResult Index()
        {
            return View(entidades.Usuarios);
        }

        /// <summary>
        /// Devuelve una vista con el detalle de un usuario.
        /// </summary>
        /// <param name="id">ID del usuario a visualizar.</param>
        /// <returns>Vista de detalle.</returns>
        public ActionResult Details(int id)
        {
            Usuario usuario = entidades.Usuarios.FirstOrDefault(u => u.UsuarioID.Equals(id));
            if (usuario == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }

        /// <summary>
        /// Devuelve el formulario para crear un usuario.
        /// </summary>
        /// <returns>Formulario de creación.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Procesa la petición de creación de un usuario.
        /// </summary>
        /// <param name="usuario">Modelo de usuario.</param>
        /// <remarks>
        /// La acción lleva el mismo nombre que la acción de arriba. Estas comparten la misma vista.
        /// La validación del modelo se realiza del lado del servidor, mediante Unobtrusive.
        /// </remarks>
        /// <returns>Redirección a Index si el registro fue exitoso, el formulario con errores en caso contrario.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // Preguntamos si el modelo es válido.
                // Sus decoradores en la clase del modelo son tomados como reglas de validación.
                if (!ModelState.IsValid)
                    return View(usuario);

                // Registro de los datos del modelo.
                entidades.Usuarios.Add(usuario);
                entidades.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Devuelve el formulario para editar un usuario con los datos respectivos del usuario especificado.
        /// </summary>
        /// <param name="id">ID del usuario a crear.</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Usuario usuario = entidades.Usuarios.FirstOrDefault(u => u.UsuarioID.Equals(id));
            if (usuario == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// La acción lleva el mismo nombre que la acción de arriba. Estas comparten la misma vista.
        /// La validación del modelo se realiza del lado del servidor, mediante Unobtrusive.
        /// </remarks>
        /// <param name="id">ID del usuario a editar.</param>
        /// <param name="usuario">Modelo con los datos actualizados por el usuario.</param>
        /// <returns>Redirección a Index si la actualización fue exitosa, el formulario con errores en caso contrario.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                // Validaciones previas.
                if (!ModelState.IsValid || !usuario.UsuarioID.Equals(id))
                {
                    return View(usuario);
                }
                // Marcamos la entidad como modificada.
                entidades.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                // Invocamos el proceso de actualización.
                entidades.SaveChanges();
                // En este punto la actualización se llevó a cabo. Retornamos la lista de usuarios.
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        /// <summary>
        /// Devuelve el formulario de eliminación con los datos del usuario a eliminar.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar.</param>
        /// <returns>Formulario de ¿Está seguro?</returns>
        public ActionResult Delete(int id)
        {
            Usuario usuario = entidades.Usuarios.FirstOrDefault(u => u.UsuarioID.Equals(id));
            if (usuario == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }

        /// <summary>
        /// Elimina el registro del usuario indicado.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar.</param>
        /// <param name="usuario">Modelo con los datos actualizados por el usuario.</param>
        /// <returns>Redirección a Index si la actualización fue exitosa, el formulario con errores en caso contrario.</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Buscamos la entidad que se desea eliminar.
                Usuario usuario = entidades.Usuarios.FirstOrDefault(u => u.UsuarioID.Equals(id));
                // Marcamos la entidad como eliminada.
                entidades.Entry(usuario).State = System.Data.Entity.EntityState.Deleted;
                // Invocamos el proceso de actualización.
                entidades.SaveChanges();
                // En este punto la actualización se llevó a cabo. Retornamos la lista de usuarios.
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
