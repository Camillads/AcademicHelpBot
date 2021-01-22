using Microsoft.WindowsAzure.Storage.Table;

namespace AcademicHelpBot.Domain.Models.Entities
{
  public class CurriculoEntity : TableEntity
  {
    public string NomeCurriculo { get; set; }
  }
}
