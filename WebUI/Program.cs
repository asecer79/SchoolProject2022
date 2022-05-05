using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using WebUI.Caching;
using WebUI.DataAccess.EFRepository.DalLayer;
using WebUI.DataAccess.EFRepository.DalLayer.SQLServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(context =>
{
    //context.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddMemoryCache();



builder.Services.AddSingleton<ICacheService, MemoryCacheService>();

builder.Services.AddSingleton<IDepartmentDal, DepartmentSQLDal>();

builder.Services.AddSingleton<IStudentDal, StudentDal>();

var app = builder.Build();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.UseExceptionHandler(async (context) =>
//{ 

//});

//app.Use(async (context, next) =>
//{

//    await context.Response.WriteAsync("M1 req\n");

//    await next();

//    await context.Response.WriteAsync("M1 res\n");
//});

//app.Use(async (context, next) =>
//{

//    await context.Response.WriteAsync("M2 req\n");

//    await next();

//    await context.Response.WriteAsync("M2 res\n");
//});

//app.Use(async (context, next) =>
//{

//    await context.Response.WriteAsync("M3 req\n");

//    await next();

//    await context.Response.WriteAsync("M3 res\n");
//});


//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Last\n");
//});

app.Run();