using ShortLink.Infrastructure.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
    

Bootstrapper.Config(builder.Services,builder.Configuration.GetConnectionString("UrlSchemaContext"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "ManageLink",
        pattern: "{shortUrl}",
        defaults: new { controller = "ShortLink", action = "Index" });


    endpoints.MapRazorPages();
});



app.Run();
