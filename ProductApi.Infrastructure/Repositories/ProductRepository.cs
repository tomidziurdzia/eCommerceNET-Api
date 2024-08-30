using System.Linq.Expressions;
using eCommerce.SharedLibrary.Logs;
using eCommerce.SharedLibrary.Response;
using ProductApi.Application.Interfaces;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Data;

namespace ProductApi.Infrastructure.Repositories;

public class ProductRepository(ProductDbContext context) : IProduct
{
    public async Task<Response> CreateAsync(Product entity)
    {
        try
        {
            var getProduct = await GetByAsync(_ => _.Name!.Equals(entity.Name));
            if (getProduct is not null && !string.IsNullOrEmpty(getProduct.Name))
                return new Response(false, $"{entity.Name} already added");

            var currentEntity = context.Products.Add(entity).Entity;
            await context.SaveChangesAsync();
            if (currentEntity is not null && currentEntity.Id > 0)
                return new Response(true, $"{entity.Name} added successfully");
            else
                return new Response(false, $"Error occurred while adding {entity.Name}");
        }
        catch (Exception ex)
        {
            // Log the original exception
            LogException.LogExceptions(ex);
            
            // display scary-free message to the client
            return new Response(false, "Error occurred adding new product");
        }
    }

    public Task<Response> UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<Product> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByAsync(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}