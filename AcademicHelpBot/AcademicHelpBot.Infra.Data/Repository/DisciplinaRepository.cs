using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;
using System.Collections.Generic;

namespace AcademicHelpBot.Infra.Data.Repository
{
  public class DisciplinaRepository : IDisciplinaRepository
  {
    private readonly INoSqlDataBank _noSqlDataBank;

    public DisciplinaRepository(INoSqlDataBank noSqlDataBank)
    {
      _noSqlDataBank = noSqlDataBank;
    }

    public DisciplinaEntity ObterDisciplinaStorage(string codigoDisciplina)
    {
      return _noSqlDataBank.Obter<DisciplinaEntity>(codigoDisciplina);
    }

    public List<DisciplinaEntity> ListarDisciplinasStorage()
    {
      return _noSqlDataBank.Listar<DisciplinaEntity>();
    }

    public List<RequisitosDisciplinaEntity> ListarRequisitosDisciplinaStorage()
    {
      return _noSqlDataBank.Listar<RequisitosDisciplinaEntity>();
    }
  }
}
