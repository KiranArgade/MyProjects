using AutoMapper;
using Inventory.Common;

namespace Inventory.Models
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(g => g.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Price, map => map.ConvertUsing(new CurrencyDecimalToStringFormatter()))
                .ForMember(g => g.CreatedDate, map => map.ConvertUsing(new DateConverter()))
                .ForMember(g => g.Quantity, map => map.MapFrom(vm => vm.Quantity));
        }
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
    }
}