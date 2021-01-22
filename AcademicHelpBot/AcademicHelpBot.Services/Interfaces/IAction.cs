using AcademicHelpBot.Domain.Models;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface IAction
  {
    string Nome { get; }
    Task<Mensagem> ExecutarAsync(Mensagem mensagem);
  }
}
