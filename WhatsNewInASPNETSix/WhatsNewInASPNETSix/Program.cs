var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
