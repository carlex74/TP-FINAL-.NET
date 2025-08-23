using Application.Interfaces;
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            services.AddScoped<IAPIPlanClients, PlanApiClient>();
            services.AddScoped<IAPIEspecialidadClients, EspecialidadApiClient>();

            services.AddTransient<Menu>();
            services.AddTransient<PlanLista>;

            var provider = services.BuildServiceProvider();

            Application.Run(new Menu());
        }
    }
}