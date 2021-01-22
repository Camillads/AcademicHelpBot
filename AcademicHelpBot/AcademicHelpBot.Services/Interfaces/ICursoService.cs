using AcademicHelpBot.Domain.Models;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface ICursoService
  {
    Task<Mensagem> ObterEmentaCurso(Mensagem mensagem);
  }
}
