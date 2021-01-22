using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrquestradorAcademicHelpBot.Model
{
  public class Result
  {
    [JsonProperty("update_id")]
    public int UpdateId { get; set; }

    [JsonProperty("message")]
    public Message Message { get; set; }
  }
}
