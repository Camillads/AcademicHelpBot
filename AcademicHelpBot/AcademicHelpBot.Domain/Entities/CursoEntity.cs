using Microsoft.WindowsAzure.Storage.Table;

namespace AcademicHelpBot.Domain.Models.Entities
{
  public class CursoEntity : TableEntity
  {
    public string NomeCurso { get; set; }
    public string Ementa { get; set; }
  }
}
