using AcademicHelpBot.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AcademicHelpBot.Service.Services
{
  public class ActionsFactory : IActionsFactory
  {
    private readonly IEnumerable<IAction> _actions;

    public ActionsFactory(IEnumerable<IAction> actions)
    {
      _actions = actions;
    }

    public IAction Obter(string nomeAction)
    {
      if (string.IsNullOrEmpty(nomeAction))
        return null;

      return _actions.FirstOrDefault(action => action.Nome.Equals(nomeAction));
    }
  }
}
