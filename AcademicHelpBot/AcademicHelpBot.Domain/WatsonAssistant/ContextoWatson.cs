using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcademicHelpBot.Domain.Models.WatsonAssistant
{
  public class ContextoWatson
  {
    [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
    public string Action { get; set; }

    [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
    public object System { get; set; }

    [JsonProperty("conversation_id", NullValueHandling = NullValueHandling.Ignore)]
    public string IdConversa { get; set; }

    [JsonProperty("data_login", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? DataLogin { get; set; }

    [JsonProperty("nome_usuario", NullValueHandling = NullValueHandling.Ignore)]
    public string NomeUsuario { get; set; }

    #region Informações Curso

    [JsonProperty("codigo_curso", NullValueHandling = NullValueHandling.Ignore)]
    public string CodigoCurso { get; set; }

    [JsonProperty("nome_curso", NullValueHandling = NullValueHandling.Ignore)]
    public string NomeCurso { get; set; }

    [JsonProperty("ementa_curso", NullValueHandling = NullValueHandling.Ignore)]
    public string EmentaCurso { get; set; }

    [JsonProperty("unidades_ofertantes", NullValueHandling = NullValueHandling.Ignore)]
    public string UnidadesOfertantes { get; set; }

    #endregion

    #region Informações Disciplina

    [JsonProperty("codigo_disciplina", NullValueHandling = NullValueHandling.Ignore)]
    public string CodigoDisciplina { get; set; }

    [JsonProperty("nome_disciplina", NullValueHandling = NullValueHandling.Ignore)]
    public string NomeDisciplina { get; set; }

    [JsonProperty("ementa_disciplina", NullValueHandling = NullValueHandling.Ignore)]
    public string EmentaDisciplina { get; set; }

    [JsonProperty("carga_horaria_virtual", NullValueHandling = NullValueHandling.Ignore)]
    public int HorasCargaHorariaVirtual { get; set; }

    [JsonProperty("carga_horaria_presencial", NullValueHandling = NullValueHandling.Ignore)]
    public int HorasCargaHorariaPresencial { get; set; }

    [JsonProperty("modalidade", NullValueHandling = NullValueHandling.Ignore)]
    public string Modalidade { get; set; }

    [JsonProperty("departamento", NullValueHandling = NullValueHandling.Ignore)]
    public string Departamento { get; set; }

    [JsonProperty("periodo_disciplina", NullValueHandling = NullValueHandling.Ignore)]
    public int Periodo { get; set; }

    [JsonProperty("lista_disciplina", NullValueHandling = NullValueHandling.Ignore)]
    public List<Disciplina> ListaDisciplina { get; set; }

    [JsonProperty("professor_coreu", NullValueHandling = NullValueHandling.Ignore)]
    public string ProfessorCoreu { get; set; }

    [JsonProperty("professor_praca", NullValueHandling = NullValueHandling.Ignore)]
    public string ProfessorPraca { get; set; }

    #endregion

    [JsonProperty("avaliacao_bot", NullValueHandling = NullValueHandling.Ignore)]
    public Avaliacao AvaliacaoBot { get; set; }
  }
}
