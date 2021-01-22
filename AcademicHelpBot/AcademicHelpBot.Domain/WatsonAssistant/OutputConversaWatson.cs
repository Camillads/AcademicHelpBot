using Newtonsoft.Json;

namespace AcademicHelpBot.Domain.Models.WatsonAssistant
{
  public class OutputConversaWatson
  {
    [JsonProperty("output", NullValueHandling = NullValueHandling.Include)]
    public OutputWatson Output { get; set; }

    [JsonProperty("context", NullValueHandling = NullValueHandling.Include)]
    public ContextoWatson Contexto { get; set; }
  }
}
