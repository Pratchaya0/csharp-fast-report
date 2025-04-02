using SimpleFastReport.API.DTOs;
using SimpleFastReport.API.Models.ProductionSchema;

namespace SimpleFastReport.API.Services
{
    public interface IReportServices
    {
        Task<Product> FulldetailProductByIDAsync(int productID);
        Task<List<ProductReponseDTO>> ListProductAsync();
    }
}