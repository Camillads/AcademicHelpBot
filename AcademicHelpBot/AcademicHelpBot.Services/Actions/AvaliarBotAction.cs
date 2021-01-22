using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Service.Services.Actions.Base;
using AcademicHelpBot.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Actions
{
  public class AvaliarBotAction : ActionBase<AvaliarBotAction>, IAction
  {
    private readonly IAvaliacaoService _avaliacaoService;

    public AvaliarBotAction(IAvaliacaoService avaliacaoService)
    {
      _avaliacaoService = avaliacaoService;
    }

    public async Task<Mensagem> ExecutarAsync(Mensagem mensagem)
    {
      return await _avaliacaoService.InserirOuAtualizarAvaliacao(mensagem);
    }
  }
}
