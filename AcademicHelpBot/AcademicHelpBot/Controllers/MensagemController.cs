using System;
using System.Threading.Tasks;
using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademicHelpBot.Controllers
{
  [ApiController]
  [Route("api/Mensagem")]
  public class MensagemController : ControllerBase
  {
    private readonly IMensagemService _mensagemService;
    private readonly IConversaService _conversaService;
    private readonly IActionsService _actionsService;
    public MensagemController(IMensagemService mensagemService, IConversaService conversaService, IActionsService actionsService)
    {
      _mensagemService = mensagemService;
      _conversaService = conversaService;
      _actionsService = actionsService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost]
    public async Task<ActionResult<MensagemSaida>> ProcessarMensagemAsync(MensagemEntrada mensagemEntrada)
    {
      try
      {
        var mensagem = new Mensagem(mensagemEntrada);

        var mensagemProcessada = await _mensagemService.ProcessarMensagemAsync(mensagem);

        var mensagemResposta = await _conversaService.EnviarMensagemAoWatsonAsync(mensagemProcessada);

        mensagemResposta = await _actionsService.ExecutarActionsAsync(mensagemResposta);

        _mensagemService.GravarMensagens(mensagemResposta);
        _mensagemService.GravarContextoMensagem(mensagemResposta);

        return new MensagemSaida(mensagemResposta);
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}
