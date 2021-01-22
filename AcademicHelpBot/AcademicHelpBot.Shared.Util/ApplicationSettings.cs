using AcademicHelpBot.Shared.Util.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AcademicHelpBot.Shared.Util
{
  public class ApplicationSettings : IApplicationSettings
  {
    private readonly IConfigurationSection _configuracoesApp;
    private readonly IConfigurationSection _chavesDeConexao;
    private readonly IConfigurationSection _chavesResolver;
    private readonly IConfiguration _configApp;

    public ApplicationSettings(IConfiguration configuracoes)
    {
      _configuracoesApp = configuracoes.GetSection("AppConfiguration");
      _chavesDeConexao = configuracoes.GetSection("ConnectionStrings");
      _chavesResolver = configuracoes.GetSection("ResolverConfig");
      _configApp = configuracoes;
    }

    #region Storage
    public string ConexaoStorage => _chavesDeConexao.GetValue<string>("ConexaoStorage"); // mudar para configApp salvando em uma chave no azure
    #endregion

    #region WatsonAssistant

    public string ApiKeyWatsonAssistant => _configuracoesApp.GetValue<string>("ApiKeyWatsonAssistant"); // mudar para configApp salvando em uma chave no azure
    public string IdWatsonAssistant => _configuracoesApp.GetValue<string>("IdWatsonAssistant");
    public string UrlApiKeyWatsonAssistant => _configuracoesApp.GetValue<string>("UrlApiKeyWatsonAssistant");
    public string UrlBaseWatsonAssistant => _configuracoesApp.GetValue<string>("UrlBaseWatsonAssistant");
    public string VersaoWatsonAssistant => _configuracoesApp.GetValue<string>("VersaoWatsonAssistant");

    #endregion
  }
}
