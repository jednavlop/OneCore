using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace OneCore.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Definición de bundles.
            // La descarga de contenido por parte de los navegadores suele ralentizarse debido a la cantidad pequeña
            // de descargas simultáneas que éstos pueden realizar (~4 hilos para Chrome).

            // La creación de Bundles ayuda a resolver este problema mediante la compresión de archivos, es decir,
            // con bundles los navegadores descargaran "paquetes" ligeros que contienen los archivos que componen una página.

            // Bundle de scripts.
            BundleTable.Bundles.Add(new ScriptBundle("~/Codigos")
                .Include("~/Scripts/jquery-3.1.1.min.js")
                .Include("~/Scripts/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include("~/Scripts/modernizr-2.6.2.js")
                .Include("~/Scripts/acceso.js"));

            // Bundle de styles.
            BundleTable.Bundles.Add(new StyleBundle("~/Estilos")
                .Include("~/Content/*.css"));

            // Esto activa el uso del bundle. Indispensable para producción.
            BundleTable.EnableOptimizations = true;
        }
    }
}
