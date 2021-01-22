using AcademicHelpBot.Domain.Models;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface IAvaliacaoService
  {
    Task<Mensagem> InserirOuAtualizarAvaliacao(Mensagem mensagem);
  }
}
