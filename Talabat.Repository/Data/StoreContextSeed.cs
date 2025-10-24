using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            //Brands
            if (!context.ProductBrands.Any())
            {
                var BrandData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);
                foreach (var Brand in Brands)
                {
                    await context.Set<ProductBrand>().AddAsync(Brand);
                }
                await context.SaveChangesAsync();
            }

            //Types
            if (!context.ProductTypes.Any())
            {
                var TypesData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                foreach (var Type in Types)
                {
                    await context.Set<ProductType>().AddAsync(Type);
                }
                await context.SaveChangesAsync();
            }

            //Products
            if (!context.Products.Any())
            {
                var ProductsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                foreach (var product in products)
                {
                    await context.Set<Product>().AddAsync(product);
                }
                await context.SaveChangesAsync();
            }

        }

    }
}
