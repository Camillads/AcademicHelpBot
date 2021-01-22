using System;
using System.Collections.Generic;

namespace OrquestradorAcademicHelpBot.Model.AcademicHelpBot
{
  public class MensagemSaida
  {
    public string IdUsuario { get; set; }
    public DateTime Data { get; set; }
    public List<string> TextosResposta { get; set; }
  }
}
