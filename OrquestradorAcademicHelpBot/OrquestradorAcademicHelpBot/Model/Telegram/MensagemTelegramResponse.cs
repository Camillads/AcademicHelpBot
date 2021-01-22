using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrquestradorAcademicHelpBot.Model
{
  public class MensagemTelegramResponse
  {
    [JsonProperty("ok")]
    public bool Ok { get; set; }

    [JsonProperty("result")]
    public List<Result> Result { get; set; }
  }
}
