using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Service.Services.Actions.Base;
using AcademicHelpBot.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services.Actions
{
  public class ListarDisciplinasPeriodoAction : ActionBase<ListarDisciplinasPeriodoAction>, IAction
  {
    private readonly IDisciplinaService _disciplinaService;

    public ListarDisciplinasPeriodoAction(IDisciplinaService disciplinaService)
    {
      _disciplinaService = disciplinaService;
    }

    public async Task<Mensagem> ExecutarAsync(Mensagem mensagem)
    {
      return await _disciplinaService.ListarDisciplinasPeriodoAsync(mensagem);
    }
  }
}
