using AcademicHelpBot.Infra.Data.Util;

namespace AcademicHelpBot.Infra.Data.Interfaces
{
  public interface INoSqlFilter
  {
    void AdicionarFiltro(string coluna, OperadoresAzureTables operador, object valor);
    string ObterFiltroGerado();
    void Limpar();
  }
}
