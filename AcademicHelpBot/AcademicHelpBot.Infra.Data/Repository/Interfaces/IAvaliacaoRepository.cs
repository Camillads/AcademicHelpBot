using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;

namespace AcademicHelpBot.Infra.Data.Repository.Interfaces
{
  public interface IAvaliacaoRepository
  {
    AvaliacaoEntity ObterAvaliacaoStorage(string idAvaliacao);
    string InserirAvaliacaoStorage(Mensagem mensagem);
    void AtualizarAvaliacaoStorage(Mensagem mensagem);
  }
}
