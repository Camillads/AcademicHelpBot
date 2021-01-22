using AcademicHelpBot.Domain.Models.WatsonAssistant;
using AcademicHelpBot.Infra.CrossCutting.WatsonAssistant.Interfaces;
using AcademicHelpBot.Shared.Util.Interfaces;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace AcademicHelpBot.Infra.CrossCutting.WatsonAssistant
{
  public class WatsonAssistantTokenAccessAgent : IWatsonAssistantTokenAccessAgent
  {
    private readonly IApplicationSettings _config;
    private readonly static object _cacheLock = new object();
    private static AutenticacaoWatsonAssistant _cacheAutenticacao;

    public WatsonAssistantTokenAccessAgent(IApplicationSettings config)
    {
      _config = config;
    }

    public Task<string> ObterToken()
    {
      if (_cacheAutenticacao != null
          && !string.IsNullOrEmpty(_cacheAutenticacao?.TokenDeAcesso)
          && _cacheAutenticacao.Expiracao >= DateTimeOffset.Now.ToUnixTimeSeconds())
        return Task.FromResult(_cacheAutenticacao.TokenDeAcesso);

      GerarToken();
      return Task.FromResult(_cacheAutenticacao.TokenDeAcesso);
    }

    private void GerarToken()
    {
      var response =
          _config.UrlApiKeyWatsonAssistant
          .WithHeader("Accept", "application/json")
          .PostUrlEncodedAsync(new
          {
            grant_type = "urn:ibm:params:oauth:grant-type:apikey",
            apikey = _config.ApiKeyWatsonAssistant
          })
          .ReceiveJson<AutenticacaoWatsonAssistant>()
          .Result;

      lock (_cacheLock)
        _cacheAutenticacao = response;
    }
  }
}
