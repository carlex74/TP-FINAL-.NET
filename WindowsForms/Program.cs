using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using Infrastructure.ApiClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static Domain.Entities.Usuario;
using WindowsForms.Vistas.Comision;
using WindowsForms.Vistas.Materia;
using WindowsForms.Vistas.Curso;

namespace WindowsForms
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Bucle principal de la aplicación para Login/Logout
            while (true)
            {
                var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    break;
                }

                var loggedInUser = UserSession.GetCurrentUser();
                if (loggedInUser == null)
                {
                    MessageBox.Show("Error al recuperar la sesión.", "Error");
                    break;
                }

                Form mainForm = null;
                switch (loggedInUser.Tipo)
                {
                    case TipoUsuario.Administrador:
                        mainForm = ServiceProvider.GetRequiredService<Home>();
                        break;
                    case TipoUsuario.Docente:
                    case TipoUsuario.Alumno:
                        mainForm = ServiceProvider.GetRequiredService<EnConstruccionForm>();
                        break;
                }

                if (mainForm != null)
                {
                    Application.Run(mainForm);
                }

                UserSession.Logout();
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            string baseAddress = "https://localhost:7111/api/";

            // --- LA SOLUCIÓN DEFINITIVA: Creamos un objeto de opciones de serialización ---
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                // Le dice al serializador que convierta los strings del JSON a enums de C#.
                Converters = { new JsonStringEnumConverter() },
                // Ignora si el JSON usa "nombre" y tu DTO usa "Nombre".
                PropertyNameCaseInsensitive = true
            };

            // Registramos estas opciones como un Singleton para que todos los clientes las puedan usar.
            services.AddSingleton(jsonSerializerOptions);

            // --- REGISTRO DE CLIENTES DE API ---
            // AddHttpClient es la forma correcta de registrar clientes que usan HttpClient.
            // Gestiona el ciclo de vida de HttpClient de forma eficiente.
            services.AddHttpClient<IAPIAuthClients, AuthApiClient>(client => client.BaseAddress = new Uri(baseAddress));
            services.AddHttpClient<IAPIEspecialidadClients, EspecialidadApiClient>(client => client.BaseAddress = new Uri(baseAddress));
            services.AddHttpClient<IAPIPlanClients, PlanApiClient>(client => client.BaseAddress = new Uri(baseAddress));
            services.AddHttpClient<IAPIPersonaClients, PersonaApiClient>(client => client.BaseAddress = new Uri(baseAddress));
            services.AddHttpClient<IAPIUsuarioClients, UsuarioApiClient>(client => client.BaseAddress = new Uri(baseAddress));
            services.AddHttpClient<IAPIMateriaClient, MateriaApiClient>(client => client.BaseAddress = new Uri(baseAddress));
            services.AddHttpClient<IAPIComisionClient, ComisionApiClient>(client => client.BaseAddress = new Uri(baseAddress));
            services.AddHttpClient<IAPICursoClient, CursoApiClient>(client => client.BaseAddress = new Uri(baseAddress));

            // --- REGISTRO DE FORMULARIOS ---
            // Usamos AddTransient para que se cree una nueva instancia cada vez que se pide.
            services.AddTransient<LoginForm>();
            services.AddTransient<EnConstruccionForm>();
            services.AddTransient<Home>();
            services.AddTransient<EspecialidadLista>();
            services.AddTransient<EspecialidadDetalle>();
            services.AddTransient<PlanLista>();
            services.AddTransient<PlanDetalle>();
            services.AddTransient<PersonaLista>();
            services.AddTransient<PersonaDetalle>();
            services.AddTransient<UsuarioLista>();
            services.AddTransient<UsuarioDetalle>();
            services.AddTransient<MateriaLista>();
            services.AddTransient<MateriaDetalle>();
            services.AddTransient<ComisionLista>();
            services.AddTransient<ComisionDetalle>();
            services.AddTransient<CursoLista>();
            services.AddTransient<CursoDetalle>();
        }
    }
}