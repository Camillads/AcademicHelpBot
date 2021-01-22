using Newtonsoft.Json;

namespace AcademicHelpBot.Domain.Models.WatsonAssistant
{
  public class AutenticacaoWatsonAssistant
  {
    [JsonProperty("access_token")]
    public string TokenDeAcesso { get; set; }

    [JsonProperty("refresh_token")]
    public string TokenAtualizado { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiraEm { get; set; }

    [JsonProperty("expiration")]
    public long Expiracao { get; set; }
  }
}
