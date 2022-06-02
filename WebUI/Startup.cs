using Business.Security;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            #region Core.CookieAuthOptions
            var cookieAuthOptions = Configuration.GetSection("CookieAuthOptions").Get<CookieAuthOptions>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = cookieAuthOptions.Name;
                options.LoginPath = cookieAuthOptions.LoginPath;
                options.LogoutPath = cookieAuthOptions.LogOutPath;
                options.AccessDeniedPath = cookieAuthOptions.AccessDeniedPath;
                options.SlidingExpiration = cookieAuthOptions.SlidingExpiration;
                options.ExpireTimeSpan = TimeSpan.FromSeconds(cookieAuthOptions.TimeOut);

            });

            #endregion

            services.AddControllersWithViews();

            services.AddMemoryCache();

            services.AddHttpContextAccessor();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Auth/Err");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseCors(builder => builder.WithOrigins("Http://localhost:3000").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
