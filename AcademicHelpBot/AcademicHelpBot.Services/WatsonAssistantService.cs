using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.WatsonAssistant;
using AcademicHelpBot.Infra.CrossCutting.WatsonAssistant.Interfaces;
using AcademicHelpBot.Service.Services.Interfaces;
using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AcademicHelpBot.Service.Services
{
  public class WatsonAssistantService : IWatsonAssistantService
  {
    private readonly IWatsonAssistantAgent _watsonAgent;
    private readonly IMapper _mapper;

    public WatsonAssistantService(IWatsonAssistantAgent watsonAgent, IMapper mapper)
    {
      _watsonAgent = watsonAgent;
      _mapper = mapper;
    }

    public async Task<OutputConversaWatson> EnviarMensagemAoWatsonAsync(InputConversaWatson mensagem)
    {
      try
      {
        var mensagemRespostaWatson = await _watsonAgent.EnviarMensagemAoWatsonAsync(mensagem);
        return mensagemRespostaWatson;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public InputConversaWatson PreencherMensagemWatson(Mensagem mensagem)
    {
      var conversaWatson = new InputConversaWatson
      {
        Input = new UserInput
        {
          TextoPergunta = SanitizarMensagemWatson(mensagem.TextoPergunta)
        },
        AlternateIntents = false
      };

      if (ExisteIdConversa(mensagem.Contexto?.IdConversa))
        return PreencherMensagemWatsonIniciada(mensagem, conversaWatson);

      return conversaWatson;
    }

    private InputConversaWatson PreencherMensagemWatsonIniciada(Mensagem mensagem, InputConversaWatson conversaWatson)
    {
      try
      {
        object system = null;

        if (!string.IsNullOrEmpty(mensagem.Contexto?.System))
          system = JObject.Parse(mensagem.Contexto.System);

        conversaWatson.Contexto = new ContextoWatson
        {
          IdConversa = mensagem.Contexto.IdConversa,
          DataLogin = mensagem.Contexto.DataLogin,
          NomeUsuario = mensagem.Contexto.NomeUsuario,
          CodigoCurso = mensagem.Contexto.CodigoCurso,
          NomeCurso = mensagem.Contexto.NomeCurso,
          EmentaCurso = mensagem.Contexto.EmentaCurso,
          CodigoDisciplina = mensagem.Contexto.CodigoDisciplina,
          NomeDisciplina = mensagem.Contexto.NomeDisciplina,
          EmentaDisciplina = mensagem.Contexto.EmentaDisciplina,
          Periodo = mensagem.Contexto.PeriodoDisciplina,
          Departamento = mensagem.Contexto.Departamento,
          HorasCargaHorariaPresencial = mensagem.Contexto.HorasCargaHorariaPresencial,
          HorasCargaHorariaVirtual = mensagem.Contexto.HorasCargaHorariaVirtual,
          Modalidade = mensagem.Contexto.Modalidade,
          ListaDisciplina = mensagem.Contexto.ListaDisciplina,
          AvaliacaoBot = mensagem.Contexto.AvaliacaoBot,
          ProfessorCoreu = mensagem.Contexto.ProfessorCoreu,
          ProfessorPraca = mensagem.Contexto.ProfessorPraca,
          System = system
        };
      }
      catch
      {
        conversaWatson.Contexto = new ContextoWatson
        {
          IdConversa = mensagem.Contexto.IdConversa,
          DataLogin = mensagem.Contexto.DataLogin,
          NomeUsuario = mensagem.Contexto.NomeUsuario,
          CodigoCurso = mensagem.Contexto.CodigoCurso,
          NomeCurso = mensagem.Contexto.NomeCurso,
          EmentaCurso = mensagem.Contexto.EmentaCurso,
          CodigoDisciplina = mensagem.Contexto.CodigoDisciplina,
          NomeDisciplina = mensagem.Contexto.NomeDisciplina,
          EmentaDisciplina = mensagem.Contexto.EmentaDisciplina,
          Periodo = mensagem.Contexto.PeriodoDisciplina,
          Departamento = mensagem.Contexto.Departamento,
          HorasCargaHorariaPresencial = mensagem.Contexto.HorasCargaHorariaPresencial,
          HorasCargaHorariaVirtual = mensagem.Contexto.HorasCargaHorariaVirtual,
          Modalidade = mensagem.Contexto.Modalidade,
          ListaDisciplina = mensagem.Contexto.ListaDisciplina,
          AvaliacaoBot = mensagem.Contexto.AvaliacaoBot,
          ProfessorCoreu = mensagem.Contexto.ProfessorCoreu,
          ProfessorPraca = mensagem.Contexto.ProfessorPraca
        };
      }

      return conversaWatson;
    }

    private bool ExisteIdConversa(string idConversa)
    {
      return !string.IsNullOrEmpty(idConversa);
    }

    private string SanitizarMensagemWatson(string texto)
    {
      Regex.Replace(texto, "\n|\r|\t", " ");
      return texto;
    }
  }
}
