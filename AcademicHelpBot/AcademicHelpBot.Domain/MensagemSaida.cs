using AcademicHelpBot.Domain.Models.Base;
using System.Collections.Generic;

namespace AcademicHelpBot.Domain.Models
{
  public class MensagemSaida : MensagemBase
  {
    public List<string> TextosResposta { get; set; }

    public MensagemSaida() { }

    public MensagemSaida(Mensagem mensagem)
    {
      Data = mensagem.Data;
      TextosResposta = mensagem.TextosResposta;
    }
  }
}
