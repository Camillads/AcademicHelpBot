using Microsoft.WindowsAzure.Storage.Table;

namespace AcademicHelpBot.Domain.Models.Entities
{
  public class AvaliacaoEntity : TableEntity
  {
    public string IdAvaliacao { get; set; }
    public string IdUsuario { get; set; }
    public string IdConversa { get; set; }
    public int? FacilidadeUso { get; set; }
    public int? UsariaNovamente { get; set; }
    public int? ObjetivoAlcancado { get; set; }
    public int? Satisfacao { get; set; }
    public string Comentario { get; set; }
  }
}
