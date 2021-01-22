namespace AcademicHelpBot.Service.Services.Actions.Base
{
  public class ActionBase<T>
  {
    public string Nome => typeof(T).Name;
  }
}
