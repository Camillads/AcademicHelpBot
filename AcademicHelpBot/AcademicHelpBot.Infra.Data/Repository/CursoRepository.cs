using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;

namespace AcademicHelpBot.Infra.Data.Repository
{
  public class CursoRepository : ICursoRepository
  {
    private readonly INoSqlDataBank _noSqlDataBank;

    public CursoRepository(INoSqlDataBank noSqlDataBank)
    {
      _noSqlDataBank = noSqlDataBank;
    }

    public CursoEntity ObterCursoStorage(string codigoCurso)
    {
      return _noSqlDataBank.Obter<CursoEntity>(codigoCurso);
    }
  }
}
