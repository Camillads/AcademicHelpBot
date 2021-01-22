using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;

namespace AcademicHelpBot.Infra.Data.Repository
{
  public class ContextoMensagemRepository : IContextoMensagemRepository
  {
    private readonly INoSqlDataBank _noSqlDataBank;

    public ContextoMensagemRepository(INoSqlDataBank noSqlDataBank)
    {
      _noSqlDataBank = noSqlDataBank;
    }

    public ContextoMensagemEntity ObterContextoMensagemStorage(string idUsuario)
    {
      return _noSqlDataBank.Obter<ContextoMensagemEntity>(idUsuario);
    }

    public ContextoMensagemEntity GravarNovoContextoMensagemStorage(Mensagem mensagem, string idUsuario)
    {
      var contextoMensagemEntity = new ContextoMensagemEntity()
      {
        RowKey = idUsuario
      };

      _noSqlDataBank.Inserir(contextoMensagemEntity);

      return contextoMensagemEntity;
    }

    public void AtualizarContextoMensagemStorage(Mensagem mensagem, string idUsuario)
    {
      var contextoMensagemEntity = new ContextoMensagemEntity()
      {
        RowKey = idUsuario,
        DataLogin = mensagem.Contexto.DataLogin,
        NomeUsuario = mensagem.Contexto.NomeUsuario,
        System = mensagem.Contexto.System,
        IdConversa = mensagem.Contexto.IdConversa,
        IdAvaliacao = mensagem.Contexto.AvaliacaoBot?.IdAvaliacao
      };

      _noSqlDataBank.InserirOuAtualizar(contextoMensagemEntity?.RowKey, contextoMensagemEntity);
    }

    public void ExcluirContextoMensagemStorage(string idUsuario)
    {
      _noSqlDataBank.ExcluirEntityPorId<ContextoMensagemEntity>(idUsuario);
    }
  }
}
