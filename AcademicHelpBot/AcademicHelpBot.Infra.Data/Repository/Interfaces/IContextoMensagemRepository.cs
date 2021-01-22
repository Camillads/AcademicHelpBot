using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;

namespace AcademicHelpBot.Infra.Data.Repository.Interfaces
{
  public interface IContextoMensagemRepository
  {
    ContextoMensagemEntity ObterContextoMensagemStorage(string idUsuario);
    ContextoMensagemEntity GravarNovoContextoMensagemStorage(Mensagem mensagem, string idUsuario);
    void AtualizarContextoMensagemStorage(Mensagem mensagem, string idUsuario);
    void ExcluirContextoMensagemStorage(string idUsuario);
  }
}
