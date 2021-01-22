using AcademicHelpBot.Domain.Models.WatsonAssistant;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcademicHelpBot.Infra.CrossCutting.WatsonAssistant.Interfaces
{
  public interface IWatsonAssistantAgent
  {
    Task<OutputConversaWatson> EnviarMensagemAoWatsonAsync(InputConversaWatson mensagem);
  }
}
