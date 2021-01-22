using AcademicHelpBot.Domain.Models;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface IConversaService
  {
    Task<Mensagem> EnviarMensagemAoWatsonAsync(Mensagem mensagem);
  }
}
