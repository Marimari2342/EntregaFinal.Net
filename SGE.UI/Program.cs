using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();

//Casos de uso de administrador
//agregamos estos servicios al contenedor DI
//builder.Services.AddTransient<CasoDeUsoModificarUsuario>();
//builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
//builder.Services.AddTransient<CasoDeUsoListarUsuarios>();

//Casos de uso de usario
//builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
//builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
//builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
//builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
//builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
//builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
//Faltan agregar los otros?

var app = builder.Build();

/*
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
*/