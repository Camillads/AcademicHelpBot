using AcademicHelpBot.Domain.Models;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface IActionsService
  {
    Task<Mensagem> ExecutarActionsAsync(Mensagem mensagem);
  }
}
