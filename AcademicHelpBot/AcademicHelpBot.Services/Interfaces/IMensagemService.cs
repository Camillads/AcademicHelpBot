using AcademicHelpBot.Domain.Models;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface IMensagemService
  {
    Task<Mensagem> ProcessarMensagemAsync(Mensagem mensagem);
    void GravarContextoMensagem(Mensagem mensagem);
    void GravarMensagens(Mensagem mensagem);
  }
}
