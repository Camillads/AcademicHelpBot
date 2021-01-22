using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;

namespace AcademicHelpBot.Infra.Data.Repository
{
  public class CurriculoRepository : ICurriculoRepository
  {
    private readonly INoSqlDataBank _noSqlDataBank;

    public CurriculoRepository(INoSqlDataBank noSqlDataBank)
    {
      _noSqlDataBank = noSqlDataBank;
    }

    public CurriculoEntity ObterCurriculoStorage(string codigoCurriculo)
    {
      return _noSqlDataBank.Obter<CurriculoEntity>(codigoCurriculo);
    }
  }
}
