using AcademicHelpBot.Domain.Models.Base;

namespace AcademicHelpBot.Domain.Models
{
  public class MensagemEntrada : MensagemBase
  {
    public string TextoPergunta { get; set; }
  }
}
