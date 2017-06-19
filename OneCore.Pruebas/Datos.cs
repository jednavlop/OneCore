using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneCore.Modelo;

namespace OneCore.Pruebas
{
    /// <summary>
    /// Pruebas unitarias del modelo de datos.
    /// </summary>
    [TestClass]
    public class Datos
    {
        /// <summary>
        /// Prueba destinada a generar la base de datos desde el dominio de clases.
        /// </summary>
        [TestMethod]
        public void Generar()
        {
            try
            {
                using (Entidades entidades = new Entidades())
                {
                    
                    Usuario usuario = new Usuario()
                    {
                        Nombre = "jednavlop",
                        Contraseña = "MambaVerde#1",
                        Correo = "jednavlop@outlook.com",
                        Sexo = "M",
                        Activo = true
                    };
                    entidades.Usuarios.Add(usuario);
                    entidades.SaveChanges();
                }
            }
            catch (Exception err)
            {
                Assert.Fail($"Terminé con una triste excepción: { err.Message }");
            }
        }

        /// <summary>
        /// Prueba de búsqueda de usuario por nombre y contraseña, tal como lo haria una ventana de login.
        /// </summary>
        [TestMethod()]
        public void LeerUsuario()
        {
            try
            {
                using (Entidades entidades = new Entidades())
                {
                    Usuario usuario = null;
                    if ((usuario = entidades.Usuarios.FirstOrDefault(u => u.Nombre.Equals("jednavlop") && u.Contraseña.Equals("MambaVerde#1"))) == null)
                    {
                        Assert.Fail("No se ha encontrado el usuario con el filtro especificado.");
                    }
                    else
                    {
                        Trace.WriteLine($"Usuario encontrado: { usuario.Nombre }, correo: { usuario.Correo }");
                    }
                }
            }
            catch (Exception err)
            {
                Assert.Fail($"Terminé con una triste excepción: { err.Message }");
            }
        }

    }
}
