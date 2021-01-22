using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;

namespace AcademicHelpBot.Infra.Data.Repository
{
  public class AvaliacaoRepository : IAvaliacaoRepository
  {
    private readonly INoSqlDataBank _noSqlDataBank;

    public AvaliacaoRepository(INoSqlDataBank noSqlDataBank)
    {
      _noSqlDataBank = noSqlDataBank;
    }

    public AvaliacaoEntity ObterAvaliacaoStorage(string idAvaliacao)
    {
      return _noSqlDataBank.Obter<AvaliacaoEntity>(idAvaliacao);
    }

    public string InserirAvaliacaoStorage(Mensagem mensagem)
    {
      var avaliacaoEntity = new AvaliacaoEntity()
      {
        RowKey = mensagem.Contexto?.AvaliacaoBot?.IdAvaliacao,
        IdAvaliacao = mensagem.Contexto?.AvaliacaoBot?.IdAvaliacao,
        IdUsuario = mensagem.Contexto?.AvaliacaoBot?.IdUsuario,
        IdConversa = mensagem.Contexto?.AvaliacaoBot?.IdConversa,
        UsariaNovamente = mensagem.Contexto?.AvaliacaoBot?.UsariaNovamente,
        Satisfacao = mensagem.Contexto?.AvaliacaoBot?.Satisfacao,
        FacilidadeUso = mensagem.Contexto?.AvaliacaoBot?.FacilidadeUso,
        ObjetivoAlcancado = mensagem.Contexto?.AvaliacaoBot?.ObjetivoAlcancado,
        Comentario = mensagem.Contexto?.AvaliacaoBot?.Comentario
      };

      return _noSqlDataBank.Inserir(avaliacaoEntity);
    }

    public void AtualizarAvaliacaoStorage(Mensagem mensagem)
    {
      var avaliacaoEntity = new AvaliacaoEntity()
      {
        RowKey = mensagem.Contexto?.AvaliacaoBot?.IdAvaliacao,
        IdAvaliacao = mensagem.Contexto?.AvaliacaoBot?.IdAvaliacao,
        IdUsuario = mensagem.Contexto?.AvaliacaoBot?.IdUsuario,
        IdConversa = mensagem.Contexto?.AvaliacaoBot?.IdConversa,
        UsariaNovamente = mensagem.Contexto?.AvaliacaoBot?.UsariaNovamente,
        Satisfacao = mensagem.Contexto?.AvaliacaoBot?.Satisfacao,
        FacilidadeUso = mensagem.Contexto?.AvaliacaoBot?.FacilidadeUso,
        ObjetivoAlcancado = mensagem.Contexto?.AvaliacaoBot?.ObjetivoAlcancado,
        Comentario = mensagem.Contexto?.AvaliacaoBot?.Comentario
      };
      
      _noSqlDataBank.InserirOuAtualizar(avaliacaoEntity?.RowKey, avaliacaoEntity);
    }
  }
}
