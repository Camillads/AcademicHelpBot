using Newtonsoft.Json;

namespace AcademicHelpBot.Domain.Models.WatsonAssistant
{
  public class UserInput
  {
    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    public string TextoPergunta { get; set; }
  }
}
