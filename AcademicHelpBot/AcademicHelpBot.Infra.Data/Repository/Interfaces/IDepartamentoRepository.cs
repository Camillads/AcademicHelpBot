using AcademicHelpBot.Domain.Models.Entities;

namespace AcademicHelpBot.Infra.Data.Repository.Interfaces
{
  public interface IDepartamentoRepository
  {
    DepartamentoEntity ObterDepartamentoDisciplinaStorage(string codigoDepartamento);
  }
}
