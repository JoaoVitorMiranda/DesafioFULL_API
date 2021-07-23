using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using Paschoalotto.Devedor.Domain.Models;
using Paschoalotto.Devedor.Domain.Models.Dapper;
using Paschoalotto.Devedor.Domain.Models.Database;
using Paschoalotto.Devedor.Domain.Models.Parcela;
using Paschoalotto.Devedor.Domain.Models.Devedor;

namespace Paschoalotto.Devedor.API.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Parcela
            CreateMap<Domain.Models.Database.Parcela, ParcelaModel>().ReverseMap();
            CreateMap<Domain.Models.Database.Parcela, ParcelaAddModel>().ReverseMap();
            CreateMap<Domain.Models.Database.Parcela, ParcelaViewModel>().ReverseMap();
            CreateMap<ParcelaViewModel, Domain.Models.Database.Parcela>().ReverseMap();
            CreateMap<ParcelaModel, Domain.Models.Database.Parcela>().ReverseMap();
            CreateMap<ParcelaAddModel, Domain.Models.Database.Parcela>().ReverseMap();
            #endregion

            #region Parcela
            CreateMap<Domain.Models.Database.Devedor, DevedorModel>().ReverseMap();
            CreateMap<Domain.Models.Database.Devedor, DevedorAddModel>().ReverseMap();
            CreateMap<Domain.Models.Database.Devedor, DevedorViewModel>().ReverseMap();
            CreateMap<DevedorViewModel, Domain.Models.Database.Devedor>().ReverseMap();
            CreateMap<DevedorModel, Domain.Models.Database.Devedor>().ReverseMap();
            CreateMap<DevedorAddModel, Domain.Models.Database.Devedor>().ReverseMap();
            #endregion
        }
    }
}
