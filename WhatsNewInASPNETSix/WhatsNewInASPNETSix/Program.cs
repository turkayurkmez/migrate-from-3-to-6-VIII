
//var anotherBuilder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    ApplicationName = "testApp",
//    ContentRootPath = Directory.GetCurrentDirectory(),
//    EnvironmentName = Environments.Development,
//    WebRootPath = "yyyroot"
//});
using Autofac;
using Autofac.Extensions.DependencyInjection;
using WhatsNewInASPNETSix.Services;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();


//yeni bir konfigürasyon dosyası (ve sağlayıcısı) eklemek:
//builder.Configuration.AddIniFile("appsettings.ini");

//loglama için sağlayıcı ekleme ve değiştirme:
//builder.Logging.AddJsonConsole();


//.net 6.0'da IHostBuilder ve IWebHostBuilder nesnelerini özelleştirmek:
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));

//Http sunucusunun implementastonunu, sadece Windows İşletim Sisteminde, Http.sys ile yapılandırabilirsiniz:
//bu durumda .net 6.0 IWebHostBuilder özelleşmesi:
//builder.WebHost.UseHttpSys();

//.net 6.0'da IoC yapılanmasını özelleştirmek isterseniz (Autofac gibi paketlerle):
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(null));


//aps.net 6.0' ef ve db kaynaklı hataları nasıl yönetiriz.
//paket: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSingleton<IProductService, AlternateProductService>();

var app = builder.Build();


//amaç: uygulama başladığında IoC'ye kaydedeilen IProductService instance'i hakkında bilgi versin.
app.Lifetime.ApplicationStarted.Register(() =>
{
    var productService = app.Services.GetRequiredService<IProductService>();
    app.Logger.LogInformation($"{app.Environment.ApplicationName} isimli uygulaması, {productService} instance'ini IoC'ye kaydetti");


});

app.Logger.LogInformation($"Uygulama adı: {builder.Environment.ApplicationName}");
app.Logger.LogInformation($"Web kök dizin: {builder.Environment.WebRootPath}");
app.Logger.LogInformation($"Kod kök dizin: {builder.Environment.ContentRootPath}");
app.Logger.LogInformation($"Ortam Adı: {builder.Environment.EnvironmentName}");




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//eski page Routing:
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/test", () => "Burası test sayfası");
});
//yeni page routing:
app.MapGet("/yeni", () => { return "Yeni routing..."; });






app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
