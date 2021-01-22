using AcademicHelpBot.Domain.Models.Enum;
using Microsoft.WindowsAzure.Storage.Table;

namespace AcademicHelpBot.Domain.Models.Entities
{
  public class DisciplinaEntity : TableEntity
  {
    public string CodigoCurriculo { get; set; }
    public string CodigoCurso { get; set; }
    public string CodigoDepartamento { get; set; }
    public string NomeDisciplina { get; set; }
    public string Ementa { get; set; }
    public int Periodo { get; set; }
    public int Modalidade { get; set; }
    public int HorasCargaHorariaPresencial { get; set; }
    public int HorasCargaHorariaVirtual { get; set; }
    public string ProfessorCoreu { get; set; }
    public string ProfessorPraca { get; set; }
  }
}
