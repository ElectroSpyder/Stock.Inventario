namespace Stock.Inventario.Api.Mapper
{
    using Stock.Inventario.Api.DTO;
    using Stock.Inventario.Entities.Entities;
    using System;

    public class EntityMapper
    {
        public Product MapProductoDtoToProduct(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Stock = dto.Stock,
                DateOfUpdate = DateTime.Now
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

        public Product MapToProduct(Product product, ProductDto dto)
        {
            product.Name = dto.Name;
            product.Stock = dto.Stock;
            product.Description = dto.Description;
            product.DateOfUpdate = DateTime.Now;

            return product;

                  
        }
    }
}
