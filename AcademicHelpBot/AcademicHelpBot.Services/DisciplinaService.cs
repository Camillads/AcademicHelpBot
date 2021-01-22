using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Enum;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;
using AcademicHelpBot.Service.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services
{
  public class DisciplinaService : IDisciplinaService
  {
    private readonly IDisciplinaRepository _disciplinaRepository;
    private readonly IDepartamentoRepository _departamentoRepository;
    private readonly IMapper _mapper;

    public DisciplinaService(IMapper mapper, IDisciplinaRepository disciplinaRepository, IDepartamentoRepository departamentoRepository) 
    {
      _mapper = mapper;
      _disciplinaRepository = disciplinaRepository;
      _departamentoRepository = departamentoRepository;
    }

    public async Task<Mensagem> ObterEmentaDisciplinaAsync(Mensagem mensagem)
    {
      var disciplina = _disciplinaRepository.ObterDisciplinaStorage(mensagem.Contexto.CodigoDisciplina);

      mensagem.Contexto.CodigoDisciplina = disciplina.RowKey;
      mensagem.Contexto.NomeDisciplina = disciplina.NomeDisciplina;
      mensagem.Contexto.EmentaDisciplina = disciplina.Ementa;

      return await Task.FromResult(mensagem);
    }

    public async Task<Mensagem> ObterPeriodoDisciplinaAsync(Mensagem mensagem)
    {
      var disciplina = _disciplinaRepository.ObterDisciplinaStorage(mensagem.Contexto.CodigoDisciplina);

      mensagem.Contexto.CodigoDisciplina = disciplina.RowKey;
      mensagem.Contexto.NomeDisciplina = disciplina.NomeDisciplina;
      mensagem.Contexto.PeriodoDisciplina = disciplina.Periodo;

      return await Task.FromResult(mensagem);
    }

    public async Task<Mensagem> ObterCargaHorariaDisciplinaAsync(Mensagem mensagem)
    {
      var disciplina = _disciplinaRepository.ObterDisciplinaStorage(mensagem.Contexto.CodigoDisciplina);

      mensagem.Contexto.CodigoDisciplina = disciplina.RowKey;
      mensagem.Contexto.NomeDisciplina = disciplina.NomeDisciplina;
      mensagem.Contexto.HorasCargaHorariaPresencial = disciplina.HorasCargaHorariaPresencial;
      mensagem.Contexto.HorasCargaHorariaVirtual = disciplina.HorasCargaHorariaVirtual;

      return await Task.FromResult(mensagem);
    }

    public async Task<Mensagem> ObterModalidadeDisciplinaAsync(Mensagem mensagem)
    {
      var disciplina = _disciplinaRepository.ObterDisciplinaStorage(mensagem.Contexto.CodigoDisciplina);

      mensagem.Contexto.CodigoDisciplina = disciplina.RowKey;
      mensagem.Contexto.NomeDisciplina = disciplina.NomeDisciplina;
      mensagem.Contexto.Modalidade = ((TipoModalidade)disciplina.Modalidade).ToString();

      return await Task.FromResult(mensagem);
    }

    public async Task<Mensagem> ObterDepartamentoDisciplinaAsync(Mensagem mensagem)
    {
      var disciplina = _disciplinaRepository.ObterDisciplinaStorage(mensagem.Contexto.CodigoDisciplina);

      var departamento = _departamentoRepository.ObterDepartamentoDisciplinaStorage(disciplina.CodigoDepartamento);

      mensagem.Contexto.CodigoDisciplina = disciplina.RowKey;
      mensagem.Contexto.NomeDisciplina = disciplina.NomeDisciplina;
      mensagem.Contexto.Departamento = departamento.NomeDepartamento;

      return await Task.FromResult(mensagem);
    }

    public async Task<Mensagem> ListarDisciplinasAsync(Mensagem mensagem)
    {
      var disciplinas = _disciplinaRepository.ListarDisciplinasStorage();

      mensagem.Contexto.ListaDisciplina = _mapper.Map<List<Disciplina>>(disciplinas);

      return await Task.FromResult(mensagem);
    }

    public async Task<Mensagem> ListarPreRequisitosDisciplinaAsync(Mensagem mensagem)
    {
      var disciplina = _disciplinaRepository.ObterDisciplinaStorage(mensagem.Contexto.CodigoDisciplina);
      mensagem.Contexto.NomeDisciplina = disciplina.NomeDisciplina;

      var disciplinasRequisitos = _disciplinaRepository.ListarRequisitosDisciplinaStorage()
        .FindAll(d => d.CodigoDisciplina == mensagem.Contexto.CodigoDisciplina && !string.IsNullOrEmpty(d.CodigoDisciplinaPreRequisito));

      var disciplinasPreRequisitos = new List<Disciplina>();

      foreach (var disciplinaRequsito in disciplinasRequisitos)
      {
        var novaDisciplina = _mapper.Map<Disciplina>(
          _disciplinaRepository.ObterDisciplinaStorage(disciplinaRequsito.CodigoDisciplinaPreRequisito)
          );

        disciplinasPreRequisitos.Add(novaDisciplina);
      }

      mensagem.Contexto.ListaDisciplina = disciplinasPreRequisitos;

      return await Task.FromResult(mensagem);
    }

    public async Task<Mensagem> ListarCoRequisitosDisciplinaAsync(Mensagem mensagem)
    {
      var disciplina = _disciplinaRepository.ObterDisciplinaStorage(mensagem.Contexto.CodigoDisciplina);
      mensagem.Contexto.NomeDisciplina = disciplina.NomeDisciplina;

      var disciplinasRequisitos = _disciplinaRepository.ListarRequisitosDisciplinaStorage()
        .FindAll(d => d.CodigoDisciplina == mensagem.Contexto.CodigoDisciplina && !string.IsNullOrEmpty(d.CodigoDisciplinaCoRequisito));

      var disciplinasCoRequisitos = new List<Disciplina>();

      foreach (var disciplinaRequsito in disciplinasRequisitos)
      {
        var novaDisciplina = _mapper.Map<Disciplina>(
          _disciplinaRepository.ObterDisciplinaStorage(disciplinaRequsito.CodigoDisciplinaCoRequisito)
          );

        disciplinasCoRequisitos.Add(novaDisciplina);
      }

      mensagem.Contexto.ListaDisciplina = disciplinasCoRequisitos;

      return await Task.FromResult(mensagem);
    }

    public async Task<Mensagem> ListarDisciplinasPeriodoAsync(Mensagem mensagem)
    {
      var disciplinas = _disciplinaRepository.ListarDisciplinasStorage()
        .FindAll(d => d.Periodo == mensagem.Contexto.PeriodoDisciplina);

      mensagem.Contexto.ListaDisciplina = _mapper.Map<List<Disciplina>>(disciplinas);

      return await Task.FromResult(mensagem);
    }
    public async Task<Mensagem> ListarProfessoresDisciplinaAsync(Mensagem mensagem)
    {
      var disciplina = _disciplinaRepository.ObterDisciplinaStorage(mensagem.Contexto.CodigoDisciplina);

      mensagem.Contexto.CodigoDisciplina = disciplina.RowKey;
      mensagem.Contexto.NomeDisciplina = disciplina.NomeDisciplina;
      mensagem.Contexto.ProfessorCoreu = disciplina.ProfessorCoreu;
      mensagem.Contexto.ProfessorPraca = disciplina.ProfessorPraca;

      return await Task.FromResult(mensagem);
    }
  }
}
