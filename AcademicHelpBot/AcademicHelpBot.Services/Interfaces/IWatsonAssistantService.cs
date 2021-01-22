using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.WatsonAssistant;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface IWatsonAssistantService
  {
    Task<OutputConversaWatson> EnviarMensagemAoWatsonAsync(InputConversaWatson mensagem);
    InputConversaWatson PreencherMensagemWatson(Mensagem mensagem);
  }
}
