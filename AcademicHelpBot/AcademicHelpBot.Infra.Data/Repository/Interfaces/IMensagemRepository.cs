using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;

namespace AcademicHelpBot.Infra.Data.Repository.Interfaces
{
  public interface IMensagemRepository
  {
    HistoricoMensagemEntity ObterMensagemStorage(string idUsuario);
    string GravarNovaMensagemStorage(Mensagem mensagem);
    void AtualizarMensagemStorage(Mensagem mensagem);
  }
}
