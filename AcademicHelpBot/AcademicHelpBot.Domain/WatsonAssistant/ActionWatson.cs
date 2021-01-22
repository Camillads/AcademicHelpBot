using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicHelpBot.Domain.Models.WatsonAssistant
{
  public class ActionWatson
  {
    [JsonProperty("name", NullValueHandling = NullValueHandling.Include)]
    public string Nome { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Include)]
    public string Tipo { get; set; }

  }
}
