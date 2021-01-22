using Microsoft.WindowsAzure.Storage.Table;

namespace AcademicHelpBot.Domain.Models.Entities
{
  public class DepartamentoEntity : TableEntity
  {
    public string NomeDepartamento { get; set; }
  }
}
