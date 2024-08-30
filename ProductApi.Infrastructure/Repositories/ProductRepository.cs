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

    public async Task<Response> UpdateAsync(Product entity)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            // Log the original exception
            LogException.LogExceptions(ex);
            
            // display scary-free message to the client
            return new Response(false, "Error occurred adding new product");
        }
    }

    public async Task<Response> DeleteAsync(Product entity)
    {
        try
        {
            var product = await FindByIdAsync(entity.Id);
            if (product is null)
                return new Response(false, $"{entity.Name} not found");

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return new Response(true, $"{entity.Name} is deleted successfully");
        }
        catch (Exception ex)
        {
            // Log the original exception
            LogException.LogExceptions(ex);
            
            // display scary-free message to the client
            return new Response(false, "Error occurred deleting product");
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync(Product entity)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            // Log the original exception
            LogException.LogExceptions(ex);
            
            // display scary-free message to the client
            return new Response(false, "Error occurred adding new product");
        }
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            // Log the original exception
            LogException.LogExceptions(ex);
            
            // display scary-free message to the client
            return new Response(false, "Error occurred adding new product");
        }
    }

    public async Task<Product> GetByAsync(Expression<Func<Product, bool>> predicate)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            // Log the original exception
            LogException.LogExceptions(ex);
            
            // display scary-free message to the client
            return new Response(false, "Error occurred adding new product");
        }
    }
}