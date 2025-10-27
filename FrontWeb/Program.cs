using Application.Interfaces.ApiClients;
using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.ApiClients;
using FrontWeb.Auth;
using Infrastructure.ApiClient;
using Infrastructure.ApiClients;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<FrontWeb.App>("#app");
builder.RootComponents.Add<Microsoft.AspNetCore.Components.Web.HeadOutlet>("head::after");

string baseAddress = builder.Configuration.GetValue<string>("ApiBaseAddress");

builder.Services.AddSingleton(new JsonSerializerOptions
{
    Converters = { new JsonStringEnumConverter() },
    PropertyNameCaseInsensitive = true
});

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("Alumno", policy => policy.RequireRole("Alumno"));
    options.AddPolicy("Docente", policy => policy.RequireRole("Docente"));
    options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador"));
});

builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<ApiAuthenticationStateProvider>());

builder.Services.AddTransient<AuthHeaderHandler>();

builder.Services.AddHttpClient<IAPIAuthClients, AuthApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPIEspecialidadClients, EspecialidadApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPIPlanClients, PlanApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPIPersonaClients, PersonaApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPIUsuarioClients, UsuarioApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPIMateriaClient, MateriaApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPIComisionClient, ComisionApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPICursoClient, CursoApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPIDocenteCursoClient, DocenteCursoApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAlumnoInscripcionClients, AlumnoInscripcionApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddHttpClient<IAPIReportesClient, ReportesApiClient>(client => client.BaseAddress = new Uri(baseAddress + "api/"))
    .AddHttpMessageHandler<AuthHeaderHandler>();

await builder.Build().RunAsync();