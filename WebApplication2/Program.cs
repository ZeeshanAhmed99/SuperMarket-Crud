var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");
app.Run();


app.Run();
