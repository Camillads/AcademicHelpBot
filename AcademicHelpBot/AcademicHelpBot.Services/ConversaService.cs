using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services
{
  public class ConversaService : IConversaService
  {
    private readonly IWatsonAssistantService _watsonService;
    private readonly IMensagemService _mensagemService;
    private readonly IAvaliacaoService _avaliacaoService;
    public ConversaService(IWatsonAssistantService watsonService, IMensagemService mensagemService, IAvaliacaoService avaliacaoService)
    {
      _watsonService = watsonService;
      _mensagemService = mensagemService;
      _avaliacaoService = avaliacaoService;
    }

    public async Task<Mensagem> EnviarMensagemAoWatsonAsync(Mensagem mensagem)
    {
      var mensagemEntradaWatson = _watsonService.PreencherMensagemWatson(mensagem);

      var mensagemRespostaWatson = await _watsonService.EnviarMensagemAoWatsonAsync(mensagemEntradaWatson);

      var mensagemResposta = new Mensagem(mensagem, mensagemRespostaWatson);

      if (mensagemResposta.Contexto?.AvaliacaoBot != null)
        await _avaliacaoService.InserirOuAtualizarAvaliacao(mensagemResposta);

      _mensagemService.GravarContextoMensagem(mensagemResposta);

      return mensagemResposta;
    }
  }
}
