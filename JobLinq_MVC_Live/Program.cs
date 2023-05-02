using JobLinq_MVC_Live.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DB ba�lant�s� i�in - appsettings.json dosyas� alt�ndaki Connection tan�m� i�in
builder.Services.AddDbContext<DBJobLinqContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build(); //Uygulaman�n yarat�ld��� k�s�m

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
