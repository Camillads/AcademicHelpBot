using AcademicHelpBot.Domain.Models.Entities;

namespace AcademicHelpBot.Infra.Data.Repository.Interfaces
{
  public interface ICurriculoRepository
  {
    CurriculoEntity ObterCurriculoStorage(string codigoCurriculo);
  }
}
