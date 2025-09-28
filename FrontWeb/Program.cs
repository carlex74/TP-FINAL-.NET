using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using FrontWeb;
using Infrastructure.ApiClient;
using Infrastructure.ApiClients;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");


// En wwwroot/appsettings.json:
// { "ApiBaseAddress": "https://localhost:7111/" }
string baseAddress = builder.Configuration.GetValue<string>("ApiBaseAddress");

ConfigureServices(builder.Services, baseAddress);

await builder.Build().RunAsync();

static void ConfigureServices(IServiceCollection services, string baseAddress)
{

    var jsonSerializerOptions = new JsonSerializerOptions
    {
        Converters = { new JsonStringEnumConverter() },
        PropertyNameCaseInsensitive = true
    };
    services.AddSingleton(jsonSerializerOptions); 

    services.AddHttpClient<IAPIAuthClients, AuthApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAPIEspecialidadClients, EspecialidadApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAPIPlanClients, PlanApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAPIPersonaClients, PersonaApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAPIUsuarioClients, UsuarioApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAPIMateriaClient, MateriaApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAPIComisionClient, ComisionApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAPICursoClient, CursoApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAPIDocenteCursoClient, DocenteCursoApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));
    services.AddHttpClient<IAlumnoInscripcionClients, AlumnoInscripcionApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"));

}