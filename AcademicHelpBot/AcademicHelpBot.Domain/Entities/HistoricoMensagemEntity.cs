using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcademicHelpBot.Domain.Models.Entities
{
  public class HistoricoMensagemEntity : TableEntity
  {
    public string IdUsuario { get; set; }
    public string IdConversa { get; set; }
    public string TextoPergunta { get; set; }
    public string TextosResposta { get; set; }
    public string NomeUsuario { get; set; }
    public DateTime Data { get; set; }

    public void SetTextosRespostaBot(List<string> value)
    {
      TextosResposta = JsonConvert.SerializeObject(value);
    }
  }
}
