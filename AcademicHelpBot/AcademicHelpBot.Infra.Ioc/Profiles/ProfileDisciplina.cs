using AcademicHelpBot.Domain.Models;
using AcademicHelpBot.Domain.Models.Entities;
using AutoMapper;

namespace AcademicHelpBot.Infra.Ioc.Profiles
{
  public class ProfileDisciplina : Profile
  {
    public ProfileDisciplina()
    {
      CreateMap<Disciplina, DisciplinaEntity>().ReverseMap()
                .ForMember(d => d.CodigoCurriculo, opts => opts.MapFrom(s => s.CodigoCurriculo))
                .ForMember(d => d.CodigoCurso, opts => opts.MapFrom(s => s.CodigoCurso))
                .ForMember(d => d.CodigoDepartamento, opts => opts.MapFrom(s => s.CodigoDepartamento))
                .ForMember(d => d.NomeDisciplina, opts => opts.MapFrom(s => s.NomeDisciplina))
                .ForMember(d => d.Ementa, opts => opts.MapFrom(s => s.Ementa))
                .ForMember(d => d.Periodo, opts => opts.MapFrom(s => s.Periodo))
                .ForMember(d => d.Modalidade, opts => opts.MapFrom(s => s.Modalidade))
                .ForMember(d => d.HorasCargaHorariaPresencial, opts => opts.MapFrom(s => s.HorasCargaHorariaPresencial))
                .ForMember(d => d.HorasCargaHorariaVirtual, opts => opts.MapFrom(s => s.HorasCargaHorariaVirtual));

      CreateMap<RequisitosDisciplina, RequisitosDisciplinaEntity>().ReverseMap()
        .ForMember(d => d.CodigoDisciplina, opts => opts.MapFrom(s => s.CodigoDisciplina))
        .ForMember(d => d.CodigoDisciplinaPreRequisito, opts => opts.MapFrom(s => s.CodigoDisciplinaPreRequisito))
        .ForMember(d => d.CodigoDisciplinaCoRequisito, opts => opts.MapFrom(s => s.CodigoDisciplinaCoRequisito));
    }
  }
}
