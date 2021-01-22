using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Service.Services.Actions.Base;
using AcademicHelpBot.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Actions
{
  public class ObterEmentaCursoAction : ActionBase<ObterEmentaCursoAction>, IAction
  {
    private readonly ICursoService _cursoService;

    public ObterEmentaCursoAction(ICursoService cursoService)
    {
      _cursoService = cursoService;
    }

    public async Task<Mensagem> ExecutarAsync(Mensagem mensagem)
    {
      return await _cursoService.ObterEmentaCurso(mensagem);
    }
  }
}
