using AcademicHelpBot.Domain.Models.WatsonAssistant;
using AcademicHelpBot.Infra.CrossCutting.WatsonAssistant.Interfaces;
using AcademicHelpBot.Shared.Util.Constants;
using AcademicHelpBot.Shared.Util.Interfaces;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace AcademicHelpBot.Infra.CrossCutting.WatsonAssistant
{
  public class WatsonAssistantAgent : IWatsonAssistantAgent
  {
    private readonly IWatsonAssistantTokenAccessAgent _watsonAssistantTokenAccessAgent;
    private readonly IApplicationSettings _config;

    public WatsonAssistantAgent(IWatsonAssistantTokenAccessAgent watsonAssistantTokenAccessAgent, IApplicationSettings config)
    {
      _watsonAssistantTokenAccessAgent = watsonAssistantTokenAccessAgent;
      _config = config;
    }

    public async Task<OutputConversaWatson> EnviarMensagemAoWatsonAsync(InputConversaWatson mensagem)
    {
      var token = await _watsonAssistantTokenAccessAgent.ObterToken();

      return await _config.UrlBaseWatsonAssistant
          .AppendPathSegment(ObterPath())
          .SetQueryParam("version", _config.VersaoWatsonAssistant)
          .WithOAuthBearerToken(token)
          .PostJsonAsync(mensagem)
          .ReceiveJson<OutputConversaWatson>();
    }

    private string ObterPath()
    {
      return string.Format(
          Rotas.WatsonAgent.ENVIAR_MENSAGEM,
          _config.IdWatsonAssistant
      );
    }
  }
}
