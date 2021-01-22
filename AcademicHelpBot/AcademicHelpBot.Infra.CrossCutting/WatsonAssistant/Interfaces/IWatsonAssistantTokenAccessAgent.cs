using System.Threading.Tasks;

namespace AcademicHelpBot.Infra.CrossCutting.WatsonAssistant.Interfaces
{
  public interface IWatsonAssistantTokenAccessAgent
  {
    Task<string> ObterToken();
  }
}
