using Database.Context;
using FinalProjectTimetable.Controllers;
using FinalProjectTimetable.FrontEndData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Services.Configuration;

namespace FinalProjectTimetable
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTelerikBlazor();

            services.AddTransient<ILoginManager,LoginManager>();
            services.AddTransient<ITimetableManager, TimetableManager>();
            services.AddTransient<ITimetableItemContext, TimetableItemContext>();
            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<LoginController>();
            services.AddTransient<TimetableService>();
            services.AddTransient<AppSettingsRoot>();


            var configSection = Configuration.GetSection("TimetableConfiguration");

            services.Configure<AppSettingsRoot>(configSection);

            var applicationSettings = configSection.Get<AppSettingsRoot>();

            services.AddDbContext<TimetableContext>(options
                => options.UseSqlServer(applicationSettings.ConnectionStrings.Timetable));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
