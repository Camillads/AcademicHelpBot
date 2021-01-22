using AcademicHelpBot.Domain.Models.Base;
using AcademicHelpBot.Domain.Models.WatsonAssistant;
using System.Collections.Generic;

namespace AcademicHelpBot.Domain.Models
{
  public class Mensagem : MensagemBase
  {
    public string IdMensagem { get; set; }
    public string TextoPergunta { get; set; }
    public List<string> TextosResposta { get; set; }
    public ContextoMensagem Contexto { get; set; }
    public ActionWatson[] Actions { get; set; }

    public Mensagem() { }

    public Mensagem(MensagemEntrada mensagemEntrada)
    {
      Data = mensagemEntrada.Data;
      IdUsuario = mensagemEntrada.IdUsuario;
      TextoPergunta = mensagemEntrada.TextoPergunta;
    }

    public Mensagem(Mensagem mensagem, OutputConversaWatson outputConversaWatson)
    {
      Data = mensagem.Data;
      TextoPergunta = mensagem.TextoPergunta;
      IdUsuario = mensagem.IdUsuario;
      TextosResposta = outputConversaWatson?.Output.TextosResposta;

      Contexto = new ContextoMensagem(outputConversaWatson.Contexto, mensagem);
    }
  }
}
