using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul7_1302194032
{
    internal class CovidConfig
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suf
            fix);
            services.AddPortableObjectLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
{
new CultureInfo("en-US"),
new CultureInfo("en"),
new CultureInfo("fr-FR"),
new CultureInfo("fr")
};

                options.DefaultRequestCulture = new RequestCulture("en-
                US");



                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment
env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseRouting();
        app.UseStaticFiles();
        app.UseRequestLocalization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "default", pattern:
            "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
