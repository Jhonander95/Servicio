using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WSServicio
{
    public class Startup
    {
        // Este método se usa para configurar los servicios que la aplicación utilizará.
        public void ConfigureServices(IServiceCollection services)
        {
            // Agrega controladores (controllers) a la aplicación.
            services.AddControllers();
        }

        // Este método se usa para configurar el pipeline de solicitudes HTTP que la aplicación utilizará.
        public void Configure(IApplicationBuilder app)
        {
            // Habilita el enrutamiento en la aplicación.
            app.UseRouting();

            // Configura CORS (Cross-Origin Resource Sharing) para permitir solicitudes de cualquier origen, método y encabezado.
            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // Agrega autorización en la aplicación.
            app.UseAuthorization();

            // Agrega los endpoints (puntos finales) de los controladores a la aplicación.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



//using Microsoft.AspNetCore.Builder;

//namespace WSServicio
//{
//    public class Startup
//    {
//        public void Configure(IApplicationBuilder app)
//        {
//            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
//        }
//    }
//}
