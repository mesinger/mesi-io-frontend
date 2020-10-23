using System;
using System.IdentityModel.Tokens.Jwt;
using Mesi.Io.Web.Clipboard.Clients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mesi.Io.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = Configuration.GetValue<string>("IdentityServer:Authority");
                    options.ClientId = Configuration.GetValue<string>("IdentityServer:ClientId");

                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;
                    
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("clipboard.user.read");
                    options.Scope.Add("clipboard.user.write");
                    options.GetClaimsFromUserInfoEndpoint = true;
                });

            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddControllers();

            services.AddRazorPages(options =>
            {
                // options.Conventions.AuthorizePage("/Clipboard");
            });

            services.AddHttpClient<IClipboardApiClient, ClipboardApiClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["ClipboardApi:BaseUrl"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}