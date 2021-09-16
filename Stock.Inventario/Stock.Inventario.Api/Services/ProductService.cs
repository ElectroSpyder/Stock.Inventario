namespace Stock.Inventario.Api.Services
{

    using Stock.Inventario.Api.DTO;
    using Stock.Inventario.Api.Helper;
    using Stock.Inventario.Api.Mapper;
    using Stock.Inventario.Repositories.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Add(ProductDto dto)
        {
            var result = await _unitOfWork.ProductRepository.Add(new EntityMapper().MapProductoDtoToProduct(dto));
            await _unitOfWork.SaveAsync();

            return new Response
            {
                State = result,
                Messaage = "Ok",
                Result = null
            };
        }

        public async Task<Response> Delete(ProductDto dto)
        {
            try
            {
                var entityToDelete = await _unitOfWork.ProductRepository.GetSingleByFunc(x => x.Name == dto.Name);
                await _unitOfWork.SaveAsync();

                if (entityToDelete != null)
                {
                    await _unitOfWork.ProductRepository.Delete(entityToDelete.Id);
                    return new Response { State = true };
                }

                return new Response { State = false };
            }
            catch (Exception ex)
            {
                return new Response { State = false, Messaage = ex.Message };
            }            

        }

        public async Task<Response> Get(string name)
        {
            try
            {
                var entity = await _unitOfWork.ProductRepository.GetSingleByFunc(x => x.Name == name);
                if(entity != null)
                {
                    return new Response
                    {
                        State = true,
                        Result = entity,
                        Messaage = "Ok"
                    };
                }

                return new Response
                {
                    State = false,
                    Result = null,
                    Messaage = "Not Found"
                };
            }
            catch (Exception ex)
            {
                return new Response { State = false, Messaage = ex.Message };
            }
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var result = await _unitOfWork.ProductRepository.GetAll();

                if (result.Any())
                {
                    var listProduct = new List<ProductDto>();
                    foreach (var item in result)
                    {
                        listProduct.Add(new EntityMapper().MapProductToProductDto(item));
                    }
                    return new Response
                    {
                        State = true,
                        Messaage = "Ok",
                        Result = listProduct
                    };
                }

                return new Response
                {
                    State = true,
                    Messaage = "Not Found",
                    Result = null
                };
            }
            catch (Exception ex)
            {
                return new Response { State = false, Messaage = ex.Message };
            }
        }

        public async Task<Response> Update(ProductDto dto, int id)
        {
            try
            {
                var result = await _unitOfWork.ProductRepository.Update(new EntityMapper().MapProductoDtoToProduct(dto), id);
                await _unitOfWork.SaveAsync();

                return new Response { State = true, Result = result, Messaage = "Ok" };
            }
            catch (Exception ex)
            {
                return new Response { State = false, Messaage = ex.Message };
            }
        }
    }
}
