using AutoMapper;
using AutomobileSeller.Models;
using AutomobileSeller.DTO.Selling;
using AutomobileSeller.DTO.Brand;
using AutomobileSeller.DTO.CarModel;
using AutomobileSeller.DTO.Customer;
using AutomobileSeller.DTO.Inventory;
using AutomobileSeller.DTO.Service;
using AutomobileSeller.DTO.Insurance;

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
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<SellingCreateDto, SellingHistory>();

            // Response
            CreateMap<SellingHistory, SellingResponseDto>()
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.CarModelName,
                    opt => opt.MapFrom(src => src.CarModel.Name));
            CreateMap<ServiceCreateDto, ServiceHistory>();

            CreateMap<ServiceHistory, ServiceResponseDto>()
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.CarModelName,
                    opt => opt.MapFrom(src => src.CarModel.Name));
            CreateMap<InsuranceCreateDto, Insurance>();
            CreateMap<Insurance, InsuranceResponseDto>()
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.CarModelName,
                    opt => opt.MapFrom(src => src.CarModel.Name));

        }
    }
}
