using AcademicHelpBot.Domain.Models.Entities;
using System.Collections.Generic;

namespace AcademicHelpBot.Infra.Data.Repository.Interfaces
{
  public interface IDisciplinaRepository
  {
    DisciplinaEntity ObterDisciplinaStorage(string codigoDisciplina);
    List<DisciplinaEntity> ListarDisciplinasStorage();
    List<RequisitosDisciplinaEntity> ListarRequisitosDisciplinaStorage();
  }
}
