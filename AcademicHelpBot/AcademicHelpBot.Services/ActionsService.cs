using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services
{
  public class ActionsService : IActionsService
  {
    private readonly IActionsFactory _actionsFactory;
    private readonly IConversaService _conversaService;

    private readonly int numeroMaximoExecucoesSeguidas = 5;

    public ActionsService(IActionsFactory actionsFactory, IConversaService conversaService)
    {
      _actionsFactory = actionsFactory;
      _conversaService = conversaService;
    }

    public async Task<Mensagem> ExecutarActionsAsync(Mensagem mensagem)
    {
      IAction action;

      for (int execucoes = 0; (action = _actionsFactory.Obter(mensagem.Contexto.Action)) != null && execucoes < numeroMaximoExecucoesSeguidas; execucoes++)
      {
        mensagem = await action.ExecutarAsync(mensagem);

        mensagem = await _conversaService.EnviarMensagemAoWatsonAsync(mensagem);
      }

      return mensagem;
    }
  }
}
