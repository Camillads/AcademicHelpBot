using AcademicHelpBot.Infra.CrossCutting.WatsonAssistant;
using AcademicHelpBot.Infra.CrossCutting.WatsonAssistant.Interfaces;
using AcademicHelpBot.Infra.Data;
using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Repository;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;
using AcademicHelpBot.Service.Services;
using AcademicHelpBot.Service.Services.Actions;
using AcademicHelpBot.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AcademicHelpBot.Infra.Ioc
{
  public static class IocConfig
  {
    public static IServiceProvider ConfigureService(IServiceCollection services)
    {
      ConfigureServices(services);
      ConfigureAgents(services);
      ConfigureTags(services);
      ConfigureActions(services);
      ConfigureNoSql(services);
      ConfigureRepositories(services);

      return services.BuildServiceProvider();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
      services
        .AddSingleton<IConversaService, ConversaService>()
        .AddSingleton<IMensagemService, MensagemService>()
        .AddSingleton<IWatsonAssistantService, WatsonAssistantService>()
        .AddSingleton<IActionsService, ActionsService>()
        .AddSingleton<IActionsFactory, ActionsFactory>()
        .AddSingleton<IDisciplinaService, DisciplinaService>()
        .AddSingleton<ICursoService, CursoService>()
        .AddSingleton<IAvaliacaoService, AvaliacaoService>();
    }

    private static void ConfigureAgents(IServiceCollection services)
    {
      services
        .AddSingleton<IWatsonAssistantAgent, WatsonAssistantAgent>()
        .AddSingleton<IWatsonAssistantTokenAccessAgent, WatsonAssistantTokenAccessAgent>();
    }

    private static void ConfigureTags(IServiceCollection services)
    {

    }

    private static void ConfigureActions(IServiceCollection services)
    {
      services
        .AddSingleton<IAction, ObterEmentaCursoAction>()
        .AddSingleton<IAction, ObterEmentaDisciplinaAction>()
        .AddSingleton<IAction, ObterPeriodoDisciplinaAction>()
        .AddSingleton<IAction, ObterCargaHorariaDisciplinaAction>()
        .AddSingleton<IAction, ObterModalidadeDisciplinaAction>()
        .AddSingleton<IAction, ObterDepartamentoDisciplinaAction>()
        .AddSingleton<IAction, ListarDisciplinasAction>()
        .AddSingleton<IAction, ListarPreRequisitosDisciplinaAction>()
        .AddSingleton<IAction, ListarCoRequisitosDisciplinaAction>()
        .AddSingleton<IAction, AvaliarBotAction>()
        .AddSingleton<IAction, ObterProfessoresDisciplinaAction>()
        .AddSingleton<IAction, ListarDisciplinasPeriodoAction>();
    }

    private static void ConfigureNoSql(IServiceCollection services)
    {
      services
        .AddSingleton<INoSqlDataBank, AzureTablesDataBank>()
        .AddSingleton<INoSqlFilter, AzureTablesFilter>();

    }

    private static void ConfigureRepositories(IServiceCollection services)
    {
      services
        .AddSingleton<IAvaliacaoRepository, AvaliacaoRepository>()
        .AddSingleton<IContextoMensagemRepository, ContextoMensagemRepository>()
        .AddSingleton<ICurriculoRepository, CurriculoRepository>()
        .AddSingleton<ICursoRepository, CursoRepository>()
        .AddSingleton<IDisciplinaRepository, DisciplinaRepository>()
        .AddSingleton<IRequisitosDisciplinaRepository, RequisitosDisciplinaRepository>()
        .AddSingleton<IDepartamentoRepository, DepartamentoRepository>()
        .AddSingleton<IMensagemRepository, MensagemRepository>();
    }
  }
}
