using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcademicHelpBot.Domain.Models.WatsonAssistant
{
  public class OutputWatson
  {
    [JsonProperty("text", NullValueHandling = NullValueHandling.Include)]
    public List<string> TextosResposta { get; set; }
  }
}
