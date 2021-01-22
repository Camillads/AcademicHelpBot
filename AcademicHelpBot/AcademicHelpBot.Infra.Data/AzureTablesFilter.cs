using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Util;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademicHelpBot.Infra.Data
{
  public class AzureTablesFilter : INoSqlFilter
  {
    private readonly Stack<string> _listaFiltros;

    public AzureTablesFilter()
    {
      _listaFiltros = new Stack<string>();
    }

    public void AdicionarFiltro(string coluna, OperadoresAzureTables operador, object valor)
    {
      if (valor is DateTimeOffset)
      {
        _listaFiltros.Push(TableQuery.GenerateFilterConditionForDate(coluna, operador.ObterNome(), (DateTimeOffset)valor));
      }
      else
      {
        _listaFiltros.Push(TableQuery.GenerateFilterCondition(coluna, operador.ObterNome(), valor.ToString()));
      }
    }

    public string ObterFiltroGerado()
    {
      var filtroFinal = string.Empty;

      foreach (var filtro in _listaFiltros.Reverse())
      {
        if (String.IsNullOrEmpty(filtroFinal))
        {
          filtroFinal = filtro;
        }
        else
        {
          filtroFinal = TableQuery.CombineFilters(filtroFinal, OperadoresAzureTables.AND.ObterNome(), filtro);
        }
      }

      Limpar();

      return filtroFinal;
    }

    public void Limpar()
    {
      _listaFiltros.Clear();
    }
  }
}
