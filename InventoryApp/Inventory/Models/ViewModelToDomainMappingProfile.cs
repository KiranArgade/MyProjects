using AutoMapper;
using Inventory.Common;

namespace Inventory.Models
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Price, map => map.ConvertUsing(new CurrencyStringToDecimalFormatter()))
                .ForMember(g => g.Quantity, map => map.MapFrom(vm => vm.Quantity));
        }
    }
}