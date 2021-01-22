using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Infra.Data.Repository.Interfaces;
using AcademicHelpBot.Service.Services.Interfaces;
using AcademicHelpBot.Shared.Util.Constants;
using AcademicHelpBot.Shared.Util.Interfaces;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services
{
  public class MensagemService : IMensagemService
  {
    private readonly IMapper _mapper;
    private readonly IApplicationSettings _config;
    private readonly IContextoMensagemRepository _contextoMensagemRepository;
    private readonly IMensagemRepository _mensagemRepository;
    private readonly IAvaliacaoRepository _avaliacaoRepository;
    public MensagemService(IMapper mapper, IApplicationSettings config, IContextoMensagemRepository contextoMensagemRepository, IMensagemRepository mensagemRepository,
      IAvaliacaoRepository avaliacaoRepository)
    {
      _mapper = mapper;
      _config = config;
      _contextoMensagemRepository = contextoMensagemRepository;
      _mensagemRepository = mensagemRepository;
      _avaliacaoRepository = avaliacaoRepository;
    }

    public async Task<Mensagem> ProcessarMensagemAsync(Mensagem mensagem)
    {
      mensagem.Contexto = mensagem.Contexto ?? BuscarContextoStorage(mensagem);

      if (mensagem.Contexto != null)
      {
        mensagem.Contexto.AvaliacaoBot = mensagem.Contexto.AvaliacaoBot ?? 
          _mapper.Map<Avaliacao>(BuscarAvaliacaoStorage(mensagem));
      }

      return await Task.FromResult(mensagem);
    }

    public void GravarContextoMensagem(Mensagem mensagem)
    {
      var idUsuario = mensagem.IdUsuario;

      _contextoMensagemRepository.AtualizarContextoMensagemStorage(mensagem, idUsuario);
    }

    public void GravarMensagens(Mensagem mensagem)
    {
      mensagem.IdMensagem = Guid.NewGuid().ToString();
      _mensagemRepository.AtualizarMensagemStorage(mensagem);
    }

    private ContextoMensagem BuscarContextoStorage(Mensagem mensagem)
    {
      var idUsuario = mensagem.IdUsuario;

      var contextoEntity = _contextoMensagemRepository.ObterContextoMensagemStorage(idUsuario);

      contextoEntity = LimparContexto(contextoEntity, idUsuario);

      contextoEntity = contextoEntity ?? _contextoMensagemRepository.GravarNovoContextoMensagemStorage(mensagem, idUsuario);

      return new ContextoMensagem(contextoEntity);
    }

    private AvaliacaoEntity BuscarAvaliacaoStorage(Mensagem mensagem)
    {
      var idUsuario = mensagem.IdUsuario;

      var contextoEntity = _contextoMensagemRepository.ObterContextoMensagemStorage(idUsuario);

      AvaliacaoEntity avaliacao;

      if (contextoEntity != null && !string.IsNullOrEmpty(contextoEntity.IdAvaliacao))
      {
        avaliacao = _avaliacaoRepository.ObterAvaliacaoStorage(contextoEntity.IdAvaliacao);
        if (avaliacao != null && string.IsNullOrEmpty(avaliacao.IdAvaliacao))
          avaliacao.IdAvaliacao = contextoEntity.IdAvaliacao;
      }
      else
        avaliacao = null;

      return avaliacao;
    }

    private ContextoMensagemEntity LimparContexto(ContextoMensagemEntity contextoEntity, string idUsuario)
    {
      var dataConvertida = contextoEntity?.Timestamp.ToOffset(new TimeSpan(-3, 0, 0));
      var diferencaContexto = DateTimeOffset.Now - dataConvertida ?? new TimeSpan(0);

      if (diferencaContexto.TotalHours > Constantes.HORAS_VALIDADE_CONTEXTO)
      {
        _contextoMensagemRepository.ExcluirContextoMensagemStorage(idUsuario);
        contextoEntity = null;
      }

      return contextoEntity;
    }
  }
}
