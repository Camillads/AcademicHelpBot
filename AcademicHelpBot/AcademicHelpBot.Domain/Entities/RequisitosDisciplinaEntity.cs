using Microsoft.WindowsAzure.Storage.Table;

namespace AcademicHelpBot.Domain.Models.Entities
{
  public class RequisitosDisciplinaEntity : TableEntity
  {
    public string CodigoDisciplina { get; set; }
    public string CodigoDisciplinaPreRequisito { get; set; }
    public string CodigoDisciplinaCoRequisito { get; set; }
  }
}
