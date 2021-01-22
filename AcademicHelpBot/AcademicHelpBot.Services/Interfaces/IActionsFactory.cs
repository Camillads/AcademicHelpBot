namespace AcademicHelpBot.Service.Services.Interfaces
{
  public interface IActionsFactory
  {
    IAction Obter(string nomeAction);
  }
}
