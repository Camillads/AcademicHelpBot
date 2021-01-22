using AcademicHelpBot.Domain.Models.Entities;
using AcademicHelpBot.Domain.Models.WatsonAssistant;
using System;
using System.Collections.Generic;

namespace AcademicHelpBot.Domain.Models
{
  public class ContextoMensagem
  {
    public string IdUsuario { get; set; }
    public string NomeUsuario { get; set; }
    public string CodigoCurso { get; set; }
    public string NomeCurso { get; set; }
    public string EmentaCurso { get; set; }
    public string CodigoDisciplina { get; set; }
    public string NomeDisciplina { get; set; }
    public string EmentaDisciplina { get; set; }
    public string ProfessorCoreu { get; set; }
    public string ProfessorPraca { get; set; }
    public int PeriodoDisciplina { get; set; }
    public int HorasCargaHorariaPresencial { get; set; }
    public int HorasCargaHorariaVirtual { get; set; }
    public string Modalidade { get; set; }
    public string Departamento { get; set; }
    public List<Disciplina> ListaDisciplina { get; set; }
    public DateTimeOffset? DataLogin { get; set; }
    public string IdConversa { get; set; }
    public string System { get; set; }
    public string Action { get; set; }
    public Avaliacao AvaliacaoBot { get; set; }
    public string IdAvaliacao { get; set; }

    public ContextoMensagem() { }

    public ContextoMensagem(ContextoMensagemEntity contextoMensagemEntity)
    {
      IdUsuario = contextoMensagemEntity.RowKey;
      NomeUsuario = contextoMensagemEntity.NomeUsuario;
      IdConversa = contextoMensagemEntity.IdConversa;
      DataLogin = contextoMensagemEntity.DataLogin;
      System = contextoMensagemEntity.System;
      IdAvaliacao = contextoMensagemEntity.IdAvaliacao;
      
    }

    public ContextoMensagem(ContextoWatson contextoWatson, Mensagem mensagem)
    {
      IdUsuario = mensagem.Contexto.IdUsuario;
      NomeUsuario = contextoWatson.NomeUsuario;
      CodigoCurso = contextoWatson.CodigoCurso;
      EmentaCurso = contextoWatson.EmentaCurso;
      CodigoDisciplina = contextoWatson.CodigoDisciplina;
      NomeDisciplina = contextoWatson.NomeDisciplina;
      EmentaDisciplina = contextoWatson.EmentaDisciplina;
      PeriodoDisciplina = contextoWatson.Periodo;
      Departamento = contextoWatson.Departamento;
      HorasCargaHorariaPresencial = contextoWatson.HorasCargaHorariaPresencial;
      HorasCargaHorariaVirtual = contextoWatson.HorasCargaHorariaVirtual;
      Modalidade = contextoWatson.Modalidade;
      ListaDisciplina = contextoWatson.ListaDisciplina;
      IdConversa = contextoWatson.IdConversa;
      DataLogin = contextoWatson.DataLogin;
      System = contextoWatson.System.ToString();
      Action = contextoWatson.Action;
      AvaliacaoBot = contextoWatson.AvaliacaoBot;
      ProfessorCoreu = contextoWatson.ProfessorCoreu;
      ProfessorPraca = contextoWatson.ProfessorPraca;
    }
  }
}
