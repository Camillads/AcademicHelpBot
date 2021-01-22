using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;

namespace AcademicHelpBot.Infra.Data.Repository
{
  public class DepartamentoRepository : IDepartamentoRepository
  {
    private readonly INoSqlDataBank _noSqlDataBank;

    public DepartamentoRepository(INoSqlDataBank noSqlDataBank)
    {
      _noSqlDataBank = noSqlDataBank;
    }

    public DepartamentoEntity ObterDepartamentoDisciplinaStorage(string codigoDepartamento)
    {
      return _noSqlDataBank.Obter<DepartamentoEntity>(codigoDepartamento);
    }
  }
}
