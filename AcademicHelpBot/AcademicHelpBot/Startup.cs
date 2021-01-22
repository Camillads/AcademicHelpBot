using System;
using System.Collections.Generic;
using AcademicHelpBot.Infra.Ioc;
using AcademicHelpBot.Shared.Util;
using AcademicHelpBot.Shared.Util.Interfaces;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AcademicHelpBot
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
      Configuration = configuration;
      _webHostEnvironment = webHostEnvironment;
      _configuracaoAplicacao = new ApplicationSettings(Configuration);
    }

    public IConfiguration Configuration { get; }
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ApplicationSettings _configuracaoAplicacao;

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<IApplicationSettings>(_configuracaoAplicacao);

      if (!_webHostEnvironment.IsProduction())
        ConfiguracaoSwagger(services);

      ConfiguracaoValidators(services);
      ConfiguracoesAutoMapper(services);

      IocConfig.ConfigureService(services);

      services.AddControllers()
        .AddNewtonsoftJson();
      services.AddMemoryCache();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (_webHostEnvironment.EnvironmentName == "Development")
      {
        app.UseDeveloperExceptionPage();
      }

      if (!_webHostEnvironment.IsProduction())
            {
        app.UseSwagger();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }

    private static void ConfiguracaoSwagger(IServiceCollection services)
    {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
      });
    }

    private static void ConfiguracaoValidators(IServiceCollection services)
    {
      services.AddMvc()
          .AddFluentValidation(
              fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>()
      );
    }

    private static void ConfiguracoesAutoMapper(IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
  }
}
