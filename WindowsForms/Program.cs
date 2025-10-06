using ApplicationClean.DTOs;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using Infrastructure.ApiClient;
using Infrastructure.ApiClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static Domain.Entities.Usuario;

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
                    case TipoUsuario.Alumno:
                        mainForm = ServiceProvider.GetRequiredService<PortalAlumno>();
                        break;
                    case TipoUsuario.Docente:
                        mainForm = ServiceProvider.GetRequiredService<PortalDocente>();
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
            string baseAddress = "https://localhost:7111/"; 

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };
            services.AddSingleton(jsonSerializerOptions);

            services.AddHttpClient<IAPIAuthClients, AuthApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAPIEspecialidadClients, EspecialidadApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAPIPlanClients, PlanApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAPIPersonaClients, PersonaApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAPIUsuarioClients, UsuarioApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAPIMateriaClient, MateriaApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAPIComisionClient, ComisionApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAPICursoClient, CursoApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAPIDocenteCursoClient, DocenteCursoApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });
            services.AddHttpClient<IAlumnoInscripcionClients, AlumnoInscripcionApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(baseAddress + "api/");
            });

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
            services.AddTransient<DocenteCursoLista>();
            services.AddTransient<DocenteCursoDetalle>();
            services.AddTransient<PortalAlumno>();
            services.AddTransient<PortalDocente>();
        }
    }
}