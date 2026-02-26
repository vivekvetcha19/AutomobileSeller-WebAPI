using AutoMapper;
using AutomobileSeller.DTO;
using AutomobileSeller.DTOs;
using AutomobileSeller.Models;

namespace AutomobileSeller.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<BrandUpdateDto, Brand>();
            CreateMap<Brand, BrandResponseDto>();
            CreateMap<CarModelCreateDto, CarModel>();
            CreateMap<CarModelUpdateDto, CarModel>();

            CreateMap<CarModel, CarModelResponseDto>()
                .ForMember(dest => dest.BrandName,
                           opt => opt.MapFrom(src => src.Brand.Name));
            CreateMap<InventoryCreateDto, Inventory>();
            CreateMap<InventoryUpdateDto, Inventory>();
            CreateMap<Inventory, InventoryResponseDto>()
                .ForMember(dest => dest.CarModelName,
                           opt => opt.MapFrom(src => src.CarModel.Name));

        }
    }
}
