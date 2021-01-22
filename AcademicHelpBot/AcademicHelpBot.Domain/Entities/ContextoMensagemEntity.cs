using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace AcademicHelpBot.Domain.Models.Entities
{
  public class ContextoMensagemEntity : TableEntity
  {
    public string NomeUsuario { get; set; }
    public DateTimeOffset? DataLogin { get; set; }
    public string System { get; set; }
    public string IdConversa { get; set; }
    public string IdAvaliacao { get; set; }
  }
}
