namespace AcademicHelpBot.Shared.Util.Interfaces
{
  public interface IApplicationSettings
  {
    string ApiKeyWatsonAssistant { get; }
    string ConexaoStorage { get; }
    string IdWatsonAssistant { get; }
    string UrlApiKeyWatsonAssistant { get; }
    string UrlBaseWatsonAssistant { get; }
    string VersaoWatsonAssistant { get; }
  }
}
