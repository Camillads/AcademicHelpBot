using Newtonsoft.Json;

namespace AcademicHelpBot.Domain.Models.WatsonAssistant
{
  public class InputConversaWatson
  {
    [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
    public UserInput Input { get; set; }

    [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
    public ContextoWatson Contexto { get; set; }

    [JsonProperty("alternate_intents", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AlternateIntents { get; set; }
  }
}
