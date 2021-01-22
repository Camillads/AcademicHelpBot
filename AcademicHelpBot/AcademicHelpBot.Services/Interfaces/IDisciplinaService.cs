using AcademicHelpBot.Domain.Models;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface IDisciplinaService
  {
    Task<Mensagem> ObterEmentaDisciplinaAsync(Mensagem mensagem);
    Task<Mensagem> ObterPeriodoDisciplinaAsync(Mensagem mensagem);
    Task<Mensagem> ObterCargaHorariaDisciplinaAsync(Mensagem mensagem);
    Task<Mensagem> ObterModalidadeDisciplinaAsync(Mensagem mensagem);
    Task<Mensagem> ObterDepartamentoDisciplinaAsync(Mensagem mensagem);
    Task<Mensagem> ListarDisciplinasAsync(Mensagem mensagem);
    Task<Mensagem> ListarPreRequisitosDisciplinaAsync(Mensagem mensagem);
    Task<Mensagem> ListarCoRequisitosDisciplinaAsync(Mensagem mensagem);
    Task<Mensagem> ListarDisciplinasPeriodoAsync(Mensagem mensagem);
    Task<Mensagem> ListarProfessoresDisciplinaAsync(Mensagem mensagem);
  }
}
