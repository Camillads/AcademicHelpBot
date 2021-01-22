using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;
using AcademicHelpBot.Service.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services
{
  public class AvaliacaoService : IAvaliacaoService
  {
    private readonly IAvaliacaoRepository _avaliacaoRepository;
    private readonly IMapper _mapper;

    public AvaliacaoService(IMapper mapper, IAvaliacaoRepository avaliacaoRepository)
    {
      _mapper = mapper;
      _avaliacaoRepository = avaliacaoRepository;
    }

    public async Task<Mensagem> InserirOuAtualizarAvaliacao(Mensagem mensagem)
    {
      if (string.IsNullOrEmpty(mensagem.Contexto.AvaliacaoBot.IdAvaliacao))
      {
        mensagem.Contexto.AvaliacaoBot.IdUsuario = mensagem.Contexto.IdUsuario;
        mensagem.Contexto.AvaliacaoBot.IdConversa = mensagem.Contexto.IdConversa;

        var idAvaliacao = _avaliacaoRepository.InserirAvaliacaoStorage(mensagem);
        mensagem.Contexto.AvaliacaoBot.IdAvaliacao = idAvaliacao;
      }
      else
        _avaliacaoRepository.AtualizarAvaliacaoStorage(mensagem);

      return await Task.FromResult(mensagem);
    }
  }
}
