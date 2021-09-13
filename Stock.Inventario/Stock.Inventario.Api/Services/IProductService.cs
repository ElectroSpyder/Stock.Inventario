namespace Stock.Inventario.Api.Services
{
    using Stock.Inventario.Api.DTO;
    using Stock.Inventario.Api.Helper;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<Response> Add(ProductDto dto);
        Task<Response> Get(string name);
        Task<Response> Update(ProductDto dto, int id);
        Task<Response> Delete(ProductDto dto);
        Task<Response> GetAll();
    }
}
