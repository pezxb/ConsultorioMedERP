using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ConsultorioMedERP.UsuarioMicroService.Api;
using ConsultorioMedERP.UsuarioMicroService.Entity.UnitofWork;
using ConsultorioMedERP.UsuarioMicroService.Entity.Context;
using ConsultorioMedERP.UsuarioMicroService.Entity.Repository;
using AutoMapper;
using ConsultorioMedERP.UsuarioMicroService.Domain.Mapping;
using ConsultorioMedERP.UsuarioMicroService.Domain.Service;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;


/// <summary>
/// Designed by AnaSoft Inc. 2019
/// http://www.anasoft.net/apincore 
/// 
/// Download full version from http://www.anasoft.net/apincore with these added features:
/// -XUnit integration tests project (update the connection string and run tests)
/// -API Postman tests as json file
/// -JWT and IS4 authentication tests
/// -T4 for smart code generation for new entities views, services, controlers and tests 
///  
/// VSIX version with:
/// -Dapper ORM implemented instead of Entity Framework and for migration
/// -FluentMigrator.Runner 
/// 
/// NOTE:
/// Must update database connection in appsettings.json - "ConsultorioMedERP.UsuarioMicroService.ApiDB"
///
/// Select authentication type JWT or IS4 in appsettings.json; IS4 default
/// Get client settings and tests for IS4 connectivity in http://www.anasoft.net/apincore
/// </summary>

namespace ConsultorioMedERP.UsuarioMicroService.Api
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
            //db service
            if (Configuration["ConnectionStrings:UseInMemoryDatabase"] == "True")
                services.AddDbContext<ConsultorioMedERP.UsuarioMicroServiceContext>(opt => opt.UseInMemoryDatabase("TestDB-" + Guid.NewGuid().ToString()));
            else
                services.AddDbContext<ConsultorioMedERP.UsuarioMicroServiceContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ConsultorioMedERP.UsuarioMicroServiceDB"]));

            #region "Authentication"

            if (Configuration["Authentication:UseIndentityServer4"] == "False")
            {
                //JWT API authentication service
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                }
                 );
            }
            else
            {
                //Indentity Server 4 API authentication service
                services.AddAuthorization();
                //.AddJsonFormatters();
                services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(option =>
                {
                    option.Authority = Configuration["Authentication:IndentityServer4IP"];
                    option.RequireHttpsMetadata = false;
                    //option.ApiSecret = "secret";
                    option.ApiName = "ConsultorioMedERP.UsuarioMicroService";  //This is the resourceAPI that we defined in the Config.cs in the AuthServ project (apiresouces.json and clients.json). They have to be named equal.
                });

            }

            #endregion

            // include support for CORS
            // More often than not, we will want to specify that our API accepts requests coming from other origins (other domains). When issuing AJAX requests, browsers make preflights to check if a server accepts requests from the domain hosting the web app. If the response for these preflights don't contain at least the Access-Control-Allow-Origin header specifying that accepts requests from the original domain, browsers won't proceed with the real requests (to improve security).
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy-public",
                    builder => builder.AllowAnyOrigin()   //WithOrigins and define a specific origin to be allowed (e.g. https://mydomain.com)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                .Build());
            });

            //mvc service
            services.AddMvc();

            #region "DI code"

            //general unitofwork injections
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services injections
            services.AddTransient(typeof(AccountService<,>), typeof(AccountService<,>));
            services.AddTransient(typeof(UserService<,>), typeof(UserService<,>));
            services.AddTransient(typeof(AccountServiceAsync<,>), typeof(AccountServiceAsync<,>));
            services.AddTransient(typeof(UserServiceAsync<,>), typeof(UserServiceAsync<,>));
            //...add other services
            //
            services.AddTransient(typeof(IService<,>), typeof(GenericService<,>));
            services.AddTransient(typeof(IServiceAsync<,>), typeof(GenericServiceAsync<,>));

            #endregion

            //data mapper profiler setting
            Mapper.Initialize((config) =>
            {
                config.AddProfile<MappingProfile>();
            });


            //Swagger API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ConsultorioMedERP.UsuarioMicroService API", Version = "v1" });

                //In Test project find attached swagger.auth.pdf file with instructions how to run Swagger authentication 
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });

                //c.DocumentFilter<api.infrastructure.filters.SwaggerSecurityRequirementsDocumentFilter>();
            });

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseMiddleware<ExceptionHandler>();

            app.UseAuthentication(); //needs to be up in the pipeline, before MVC
            app.UseCors("CorsPolicy-public");  //apply to every request
            app.UseMvc();


            //Swagger API documentation
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsultorioMedERP.UsuarioMicroService API V1");
            });

            //migrations and seeds from json files
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (Configuration["ConnectionStrings:UseInMemoryDatabase"] == "False" && !serviceScope.ServiceProvider.GetService<ConsultorioMedERP.UsuarioMicroServiceContext>().AllMigrationsApplied())
                {
                    if (Configuration["ConnectionStrings:UseMigrationService"] == "True")
                        serviceScope.ServiceProvider.GetService<ConsultorioMedERP.UsuarioMicroServiceContext>().Database.Migrate();
                }
                //it will seed tables on aservice run from json files if tables empty
                if (Configuration["ConnectionStrings:UseSeedService"] == "True")
                    serviceScope.ServiceProvider.GetService<ConsultorioMedERP.UsuarioMicroServiceContext>().EnsureSeeded();
            }
        }


    }
}


namespace api.infrastructure.filters
{
    public class SwaggerSecurityRequirementsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument document, DocumentFilterContext context)
        {
            document.Security = new List<IDictionary<string, IEnumerable<string>>>()
            {
                new Dictionary<string, IEnumerable<string>>()
                {
                    { "Bearer", new string[]{ } },
                    { "Basic", new string[]{ } },
                }
            };
        }
    }
}



