using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;

namespace AcademicHelpBot.Infra.Data.Interfaces
{
  public interface INoSqlDataBank
  {
    void Excluir<T>(INoSqlFilter filtro) where T : TableEntity, new();
    void Excluir<T>(T entity) where T : TableEntity, new();
    void ExcluirEntityPorId<T>(string id) where T : TableEntity, new();
    List<T> Filtrar<T>(INoSqlFilter filtro) where T : TableEntity, new();
    string Inserir(TableEntity entidade, string partitionKey = null);
    void InserirOuAtualizar<T>(string id, T entidade, string partitionKey = null) where T : TableEntity, new();
    T Obter<T>(Guid id) where T : TableEntity, new();
    T Obter<T>(string id, string partitionKey = null) where T : TableEntity, new();
    List<T> Listar<T>() where T : TableEntity, new();
  }
}
