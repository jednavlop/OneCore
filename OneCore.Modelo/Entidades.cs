using System.Data.Entity;

namespace OneCore.Modelo
{
    /// <summary>
    /// Contexto de entidades.
    /// </summary>
    public class Entidades : DbContext
    {
        /// <summary>
        /// Constructor predeterminado.
        /// </summary>
        public Entidades() : base()
        {
            // Aquí es un buen lugar para realizar ajustes especificos en el
            // comportamiento de EntityFramework, como por ejemplo:
            //
            //  Configuration.LazyLoadingEnabled = false
            //
            // El cual es un ajuste común cuando se busca exponer nuestras entidades mediante
            // una API RESTful (solo en WebAPI2, no necesario en OData :).
        }

        /// <summary>
        /// Usuarios del sistema.
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
