using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;
using AcademicHelpBot.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services
{
  public class CursoService : ICursoService
  {
    private readonly ICursoRepository _cursoRepository;
    public CursoService(ICursoRepository cursoRepository)
    {
      _cursoRepository = cursoRepository;
    }

    public async Task<Mensagem> ObterEmentaCurso(Mensagem mensagem)
    {
      var curso = _cursoRepository.ObterCursoStorage(mensagem.Contexto.CodigoCurso);

      mensagem.Contexto.CodigoCurso = curso.RowKey;
      mensagem.Contexto.NomeCurso = curso.NomeCurso;
      mensagem.Contexto.EmentaCurso = curso.Ementa;

      return await Task.FromResult(mensagem);
    }
  }
}
