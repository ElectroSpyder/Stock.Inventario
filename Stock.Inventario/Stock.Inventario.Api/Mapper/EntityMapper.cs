namespace Stock.Inventario.Api.Mapper
{
    using Stock.Inventario.Api.DTO;
    using Stock.Inventario.Entities.Entities;

    public class EntityMapper
    {
        public Product MapProductoDtoToProduct(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Stock = dto.Stock
            };
            return product;
        }

        public ProductDto MapProductToProductDto(Product product)
        {
            var productDto = new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock
            };
            return productDto;
        }
    }
}
