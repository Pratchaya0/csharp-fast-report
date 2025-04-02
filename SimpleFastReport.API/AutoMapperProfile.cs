using AutoMapper;
using SimpleFastReport.API.DTOs;
using SimpleFastReport.API.Models.ProductionSchema;

namespace SimpleFastReport.API
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<Product, ProductReponseDTO>();

        }
    }
}
