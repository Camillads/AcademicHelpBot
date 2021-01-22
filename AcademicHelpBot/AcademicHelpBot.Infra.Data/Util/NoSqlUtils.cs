using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicHelpBot.Infra.Data.Util
{
  public static class NoSqlUtils
  {
    public static string ObterNome(this OperadoresAzureTables operador)
    {
      switch (operador)
      {
        case OperadoresAzureTables.AND:
          return "and";

        case OperadoresAzureTables.OR:
          return "or";

        case OperadoresAzureTables.NOT:
          return "not";

        case OperadoresAzureTables.EQUAL:
          return "eq";

        case OperadoresAzureTables.NOT_EQUAL:
          return "ne";

        case OperadoresAzureTables.GREATER_THAN:
          return "gt";

        case OperadoresAzureTables.GREATER_THAN_OR_EQUAL:
          return "ge";

        case OperadoresAzureTables.LESS_THAN:
          return "lt";

        case OperadoresAzureTables.LESS_THAN_OR_EQUAL:
          return "le";

        default:
          return string.Empty;
      }
    }
  }
}
