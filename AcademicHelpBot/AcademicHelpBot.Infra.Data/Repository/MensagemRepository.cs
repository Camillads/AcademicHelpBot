using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Infra.Data.Interfaces;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;
using System;

namespace AcademicHelpBot.Infra.Data.Repository
{
  public class MensagemRepository : IMensagemRepository
  {
    private readonly INoSqlDataBank _noSqlDataBank;

    public MensagemRepository(INoSqlDataBank noSqlDataBank)
    {
      _noSqlDataBank = noSqlDataBank;
    }

    public HistoricoMensagemEntity ObterMensagemStorage(string idMensagem)
    {
      return _noSqlDataBank.Obter<HistoricoMensagemEntity>(idMensagem);
    }

    public string GravarNovaMensagemStorage(Mensagem mensagem)
    {
      var mensagemEntity = new HistoricoMensagemEntity()
      {
        RowKey = mensagem.IdMensagem,
        IdConversa = mensagem.Contexto?.IdConversa,
        IdUsuario = mensagem.Contexto?.IdUsuario,
        NomeUsuario = mensagem.Contexto?.NomeUsuario,
        TextoPergunta = mensagem.TextoPergunta,
        Data = DateTime.Now
      };

      mensagemEntity.SetTextosRespostaBot(mensagem.TextosResposta);

     return  _noSqlDataBank.Inserir(mensagemEntity);
    }

    public void AtualizarMensagemStorage(Mensagem mensagem)
    {
      var mensagemEntity = new HistoricoMensagemEntity()
      {
        RowKey = mensagem.IdMensagem,
        IdConversa = mensagem.Contexto?.IdConversa,
        IdUsuario = mensagem.Contexto?.IdUsuario,
        NomeUsuario = mensagem.Contexto?.NomeUsuario,
        TextoPergunta = mensagem.TextoPergunta,
        Data = DateTime.Now
      };

      mensagemEntity.SetTextosRespostaBot(mensagem.TextosResposta);

      _noSqlDataBank.InserirOuAtualizar(mensagemEntity?.RowKey, mensagemEntity);
    }
  }
}
