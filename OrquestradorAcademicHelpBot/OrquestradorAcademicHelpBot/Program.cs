using Flurl.Http;
using OrquestradorAcademicHelpBot.Model;
using OrquestradorAcademicHelpBot.Model.AcademicHelpBot;
using System;
using System.Threading.Tasks;

namespace OrquestradorAcademicHelpBot
{
  class Program
  {
    static void Main(string[] args)
    {
      int? updateId = null;

      while (true)
      {
        var mensagens = ObterMensagemsUsuarioTelegram(updateId);
        var dados = mensagens.Result;

        if (dados != null)
        {
          foreach (var dado in dados.Result)
          {
            updateId = dado.UpdateId;
            var textoPergunta = dado.Message.Text;

            var chatId = dado.Message.From.Id;

            var ehPrimeiraMensagem = dado.Message.MessageId == 1;

            var respostaBot = ObterRespostaAcademicHelpBot(new MensagemEntrada(chatId.ToString(), new DateTime(), textoPergunta));

            if (respostaBot.Result == null)
              Task.FromResult(Responder(chatId.ToString(), "Desculpe, ocorreu um erro! Tente novamente mais tarde"));
            else
            {
              foreach (var mensagem in respostaBot.Result?.TextosResposta)
              {
                Task.FromResult(Responder(chatId.ToString(), mensagem));

                Task.Delay(3000);
              }
            }

            Task.Delay(3000);
          }
        }
      }
    }

    public static async Task<MensagemTelegramResponse> ObterMensagemsUsuarioTelegram(int? updateId)
    {
      MensagemTelegramResponse mensagemTelegramResponse;

      //var url_base = ObterPath(ObterToken(), "getUpdates?timeout=100");

      //if (updateId != null)
        //url_base = ObterPath(ObterToken(), $"getUpdates?&offset={updateId + 1}");

      var url_base = ObterPath(ObterToken(), $"getUpdates?&offset={updateId + 1}");

      var responseString = await url_base
        .GetJsonAsync<MensagemTelegramResponse>();

      return responseString;
    }

    public static async Task<MensagemSaida> ObterRespostaAcademicHelpBot(MensagemEntrada mensagemEntrada)
    {
      var url_base = "https://academichelpbot.azurewebsites.net/api/Mensagem";

      var mensagemSaida = await url_base
          .WithHeader("Content-Type", "application/json")
          .PostJsonAsync(mensagemEntrada)
          .ReceiveJson<MensagemSaida>();

      return mensagemSaida;
    }

    public static async Task Responder(string chatId, string resposta)
    {
      var url_base = ObterPath(ObterToken(), $"sendMessage?chat_id={chatId}&text={resposta}");

      var responseString = await url_base
        .GetJsonAsync();

    }

    public static string ObterToken()
    {
      return "1491848818:AAE93NTQN9Xr4VGGCyFxLIrWQfyz5LDOZv4";
    }

    public static string ObterPath(string token, string metodo)
    {
      return string.Format($"https://api.telegram.org/bot{token}/{metodo}", token, metodo);
    }
  }
}
