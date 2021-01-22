using AcademicHelpBot.Domain.Models.Entities;

namespace AcademicHelpBot.Infra.Data.Repository.Interfaces
{
  public interface ICursoRepository
  {
    CursoEntity ObterCursoStorage(string codigoCurso);
  }
}
