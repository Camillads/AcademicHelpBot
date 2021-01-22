using Newtonsoft.Json;
using System.Collections.Generic;

namespace OrquestradorAcademicHelpBot.Model
{
  public class Message
  {
    [JsonProperty("message_id")]
    public int MessageId { get; set; }

    [JsonProperty("from")]
    public From From { get; set; }

    [JsonProperty("chat")]
    public Chat Chat { get; set; }

    [JsonProperty("date")]
    public int Date { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("entities")]
    public List<Entity> Entities { get; set; }
  }
}
