using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SGE.UI.Data;

using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion;

var builder = WebApplication.CreateBuilder(args);

EntidadesSqlite.Inicializar();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//add Servicios para la app

builder.Services.AddTransient<CasoDeUsoObtenerUsuario>();
builder.Services.AddTransient<CasoDeUsoAgregarUsuario>();
builder.Services.AddTransient<CasoDeUsoListarUsuarios>();
builder.Services.AddTransient<CasoDeUsoModificarUsuario>();
builder.Services.AddTransient<CasoDeUsoEliminarUsuario>();
builder.Services.AddTransient<CasosDeUsoModificarPermisos>();

builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();

builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();

builder.Services.AddSingleton<IUsuarioRepositorio, UsuarioRepositorioSQL>();
builder.Services.AddSingleton<ITramiteRepositorio, TramiteRepositorioSQL>();
builder.Services.AddSingleton<IExpedienteRepositorio, ExpedienteRepositorioSQL>();


builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddTransient<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddTransient<IEspecificacionCambioEstado, EspecificacionCambioEstado>();
builder.Services.AddTransient<ServicioActualizacionEstado>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
