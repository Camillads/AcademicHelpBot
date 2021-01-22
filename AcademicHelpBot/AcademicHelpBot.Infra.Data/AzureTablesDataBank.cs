using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Shared.Util.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicHelpBot.Infra.Data
{
  public class AzureTablesDataBank : INoSqlDataBank
  {
    private readonly IApplicationSettings _config;

    public AzureTablesDataBank(IApplicationSettings config)
    {
      _config = config;
    }

    public void CriarTabela(Type tipo)
    {
      ObterTabelaAzure(tipo);
    }

    public void Excluir<T>(T entity) where T : TableEntity, new()
    {
      var operacao = TableOperation.Delete(entity);
      Task.Factory.StartNew(() => ObterTabelaAzure(typeof(T)).ExecuteAsync(operacao)).Wait();
    }

    public void ExcluirEntityPorId<T>(string id) where T : TableEntity, new()
    {
      var entidade = Obter<T>(id);

      if (entidade != null)
      {
        var operacao = TableOperation.Delete(entidade);
        Task.Factory.StartNew(() => ObterTabelaAzure(entidade).ExecuteAsync(operacao)).Wait();
      }
    }

    public void Excluir<T>(INoSqlFilter filtro) where T : TableEntity, new()
    {
      TableContinuationToken token = null;
      TableQuery<T> query = new TableQuery<T>().Where(filtro.ObterFiltroGerado());

      do
      {
        TableQuerySegment<T> segmento = ObterTabelaAzure(typeof(T)).ExecuteQuerySegmentedAsync(query, token).Result;
        token = segmento.ContinuationToken;
        segmento.Results.ForEach((entrada) =>
        {
          var operacao = TableOperation.Delete(Obter<T>(entrada.RowKey));

          Task.Factory.StartNew(() => ObterTabelaAzure(typeof(T)).ExecuteAsync(operacao)).Wait();
        });
      } while (token != null);
    }

    public List<T> Filtrar<T>(INoSqlFilter filtro) where T : TableEntity, new()
    {
      List<T> resultados = new List<T>();
      TableContinuationToken token = null;
      TableQuery<T> query = new TableQuery<T>().Where(filtro.ObterFiltroGerado());

      do
      {
        TableQuerySegment<T> segmento = ObterTabelaAzure(typeof(T))
            .ExecuteQuerySegmentedAsync(query, token).Result;

        token = segmento.ContinuationToken;
        resultados.AddRange(segmento);
      } while (token != null);

      return resultados;
    }

    public string Inserir(TableEntity entidade, string partitionKey = null)
    {
      var operacao = TableOperation.Insert(entidade);
      var chave = DefinirEntidadeASerGravada(entidade);
      entidade.RowKey = chave;
      entidade.PartitionKey = string.IsNullOrEmpty(partitionKey) ?
          entidade.GetType().Name : partitionKey;

      Task.Factory.StartNew(() => ObterTabelaAzure(entidade).ExecuteAsync(operacao)).Wait();
      return chave;
    }

    public void InserirOuAtualizar<T>(string id, T entidade, string partitionkey = null) where T : TableEntity, new()
    {
      entidade.PartitionKey = !string.IsNullOrEmpty(partitionkey) ?
          partitionkey : entidade.GetType().Name;

      var entidadeAnterior = Obter<T>(id, partitionkey);
      TableOperation operacao;

      if (entidadeAnterior != null)
      {
        entidade.ETag = entidadeAnterior.ETag;
        operacao = TableOperation.Replace(entidade);
      }
      else
      {
        operacao = TableOperation.Insert(entidade);
        entidade.RowKey = DefinirEntidadeASerGravada(entidade);
      }

      Task.Factory.StartNew(() => ObterTabelaAzure(entidade).ExecuteAsync(operacao)).Wait();
    }

    public List<T> Listar<T>() where T : TableEntity, new()
    {
      var resultados = new List<T>();
      var token = default(TableContinuationToken);
      var query = new TableQuery<T>().Where(string.Empty);

      do
      {
        TableQuerySegment<T> segmento = ObterTabelaAzure(typeof(T)).ExecuteQuerySegmentedAsync(query, token).Result;
        token = segmento.ContinuationToken;
        resultados.AddRange(segmento);

      } while (token != null);

      return resultados;
    }

    public T Obter<T>(Guid id) where T : TableEntity, new()
    {
      return Obter<T>(id.ToString());
    }

    public T Obter<T>(string id, string partitionKey = null) where T : TableEntity, new()
    {
      var operacao = !string.IsNullOrEmpty(partitionKey) ?
          TableOperation.Retrieve<T>(partitionKey, id) : TableOperation.Retrieve<T>(typeof(T).Name, id);
      var resultado = ObterTabelaAzure(typeof(T)).ExecuteAsync(operacao).Result;

      return resultado != null ? (T)resultado.Result : default(T);
    }

    private CloudTable ObterTabelaAzure(Type tipo)
    {
      var storageAccount = CloudStorageAccount.Parse(_config.ConexaoStorage);

      var tableClient = storageAccount.CreateCloudTableClient();
      var table = tableClient.GetTableReference(tipo.Name);
      table.CreateIfNotExistsAsync().Wait();

      return table;
    }

    private CloudTable ObterTabelaAzure<T>(T entidade)
    {
      return ObterTabelaAzure(entidade.GetType());
    }

    private string DefinirEntidadeASerGravada(TableEntity entidade)
    {
      if (String.IsNullOrEmpty(entidade.RowKey))
        entidade.RowKey = Guid.NewGuid().ToString();

      if (String.IsNullOrEmpty(entidade.PartitionKey))
        entidade.PartitionKey = entidade.GetType().Name;

      return entidade.RowKey;
    }
  }
}
