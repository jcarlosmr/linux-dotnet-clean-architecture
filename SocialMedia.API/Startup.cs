using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using SocialMedia.Infraestructure.Repositories;

namespace SocialMedia.API {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      services.AddControllers().AddNewtonsoftJson();
      // Si se encuentra con un error de referencia circular a la hora de generar la salida json, existen
      // dos formas de evitarlo, ua es instalando el paquete Microsoft.AspNetCore.Mvc.NewtonsoftJson, comentar la linea anterior y 
      // agregando el siguiente código;
      // services.AddControllers().AddNewtonsoftJson(options => {
      //   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      // });
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialMedia.API", Version = "v1" });
      });
      // Inyectando la cadena de conexión SolcialMedia definida en el archivo appsettins.jcon 
      // al Contexto SocialMediaContext
      services.AddDbContext<SocialMediaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SocialMedia")));
      // Inyección de  dependencias rel repositorio de datos
      services.AddTransient<IPostRepository, PostRepository>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialMedia.API v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
