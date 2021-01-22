namespace AcademicHelpBot.Domain.Models
{
  public class Disciplina
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
  }
}
