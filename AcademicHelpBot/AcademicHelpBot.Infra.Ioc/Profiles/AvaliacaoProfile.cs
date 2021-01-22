using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;
using AutoMapper;

namespace AcademicHelpBot.Infra.Ioc.Profiles
{
  public class AvaliacaoProfile : Profile
  {
    public AvaliacaoProfile()
    {
      CreateMap<Avaliacao, AvaliacaoEntity>().ReverseMap()
        .ForMember(d => d.IdAvaliacao, opts => opts.MapFrom(s => s.IdAvaliacao))
        .ForMember(d => d.IdConversa, opts => opts.MapFrom(s => s.IdConversa))
        .ForMember(d => d.ObjetivoAlcancado, opts => opts.MapFrom(s => s.ObjetivoAlcancado))
        .ForMember(d => d.Satisfacao, opts => opts.MapFrom(s => s.Satisfacao))
        .ForMember(d => d.UsariaNovamente, opts => opts.MapFrom(s => s.UsariaNovamente))
        .ForMember(d => d.FacilidadeUso, opts => opts.MapFrom(s => s.FacilidadeUso))
        .ForMember(d => d.Comentario, opts => opts.MapFrom(s => s.Comentario))
        .ForMember(d => d.IdUsuario, opts => opts.MapFrom(s => s.IdUsuario));
    }
  }
}
