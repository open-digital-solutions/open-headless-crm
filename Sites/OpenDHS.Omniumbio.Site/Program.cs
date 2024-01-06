var builder = WebApplication.CreateBuilder(args);
   
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

// Configuración para redirigir a '/Home' al iniciar la aplicación
app.Use(async (context, next) =>
{
    if (!context.Request.Path.HasValue || context.Request.Path == "/")
    {
        context.Response.Redirect("/Index");
    }

    await next();
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
