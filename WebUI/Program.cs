using WebUI.DataAccess.EFRepository.DalLayer;
using WebUI.DataAccess.EFRepository.DalLayer.OracleDb;
using WebUI.DataAccess.EFRepository.DalLayer.SQLServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
