using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SimpleFastReport.API.Data;
using SimpleFastReport.API.DTOs;
using SimpleFastReport.API.Models.ProductionSchema;

namespace SimpleFastReport.API.Services
{
    public class ReportServices : IReportServices
    {

        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;

        public ReportServices(AppDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<List<ProductReponseDTO>> ListProductAsync()
            => await _dBContext.Products.Take(1000).ProjectTo<ProductReponseDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<Product> FulldetailProductByIDAsync(int productID)
        {
            var product = await _dBContext.Products
                .Include(_ => _.ProductModel)
                .Include(_ => _.ProductSubcategory)
                .Include(_ => _.SizeUnitMeasureCodeNavigation)
                .Include(_ => _.WeightUnitMeasureCodeNavigation)
                .Where(p => p.ProductId == productID)
                .AsSplitQuery()
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new Exception("ProductID is invalid");
            }

            return product;

        }

    }
}
