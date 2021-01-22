using System;

namespace OrquestradorAcademicHelpBot.Model.AcademicHelpBot
{
  public class MensagemEntrada
  {
    public string IdUsuario { get; set; }
    public DateTime Data { get; set; }
    public string TextoPergunta { get; set; }

    public MensagemEntrada(string idUsuario, DateTime data, string textoPergunta)
    {
      IdUsuario = idUsuario;
      Data = data;
      TextoPergunta = textoPergunta;
    }
  }
}
