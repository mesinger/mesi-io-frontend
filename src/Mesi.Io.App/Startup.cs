using System;
using System.IdentityModel.Tokens.Jwt;
using Mesi.Io.Application.Clipboard;
using Mesi.Io.Application.Contract.Clipboard;
using Mesi.Io.Infrastructure.Clipboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Mesi.Io.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

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
                    options.ResponseType = "code";

                    options.ClientSecret = Configuration.GetValue<string>("IdentityServer:Secret");
                    options.SaveTokens = true;

                    options.SignedOutCallbackPath = "/logout-redirect";

                    if (Environment.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = false;
                    }

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("clipboard.user.read");
                    options.Scope.Add("clipboard.user.write");
                    options.GetClaimsFromUserInfoEndpoint = true;
                });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            services.AddRazorPages(options => { options.Conventions.AuthorizePage("/Clipboard"); });

            services.AddHttpClient<IClipboardApiClient, ClipboardApiClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["ClipboardApi:BaseUrl"]);
            });

            services.AddScoped<IClipboardRepository, ClipboardRepository>();
            services.AddScoped<IGetClipboardEntriesForUser, ClipboardApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("------- Settings --------");
            logger.LogInformation(
                $"IS4: auth: {Configuration.GetValue<string>("IdentityServer:Authority")}, client: {Configuration.GetValue<string>("IdentityServer:ClientId")}");
            logger.LogInformation($"Clibboard API: {Configuration.GetValue<string>("ClipboardApi:BaseUrl")}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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