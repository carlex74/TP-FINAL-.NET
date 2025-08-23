using System.Net.Http.Headers;
using ApplicationClean.Interfaces;
using Infrastructure.ApiClients;
using Microsoft.Extensions.DependencyInjection;
using WindowsForms.Vistas;

namespace WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Configuración de DI
            var services = new ServiceCollection();

            // Registrar clientes de la capa Infrastructure
            services.AddHttpClient<IAPIEspecialidadClients, EspecialidadApiClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5183/api/"); // Cambia la URL según tu API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<IAPIPlanClients, PlanApiClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5183/api/"); // Cambia la URL según tu API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            // Registrar formularios
            services.AddTransient<Menu>();
            services.AddTransient<PlanLista>();
            services.AddTransient<EspecialidadLista>();

            // Construir el proveedor de servicios
            using var provider = services.BuildServiceProvider();

            // Resolver el formulario principal desde el contenedor
            var mainForm = provider.GetRequiredService<Menu>();

            // Iniciar la aplicación con DI habilitado
            Application.Run(mainForm);
        }
    }
}