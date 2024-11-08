using System;
using BabyShopping_FinalAss.Data;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;
using BabyShopping_FinalAss.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BabyShopping_FinalAss.EndPoints;

public static class ProductsEndPoint
{
    // private static readonly List <ProductsDTO> products = [
    //                 new (1, "Huggies Nature Made", 1, "Platinum", 195000.0m, 7.5m,  @"D:\.NET\BabyShopping_Image\Diaper\Huggies.jpg", DateTime.Now, "Admin", DateTime.Now, "Admin"),
    //                 new (6, "Aptamil", 2, "Aptamil NewZeland", 567000.0m, 7.7m,  @"D:\.NET\BabyShopping_Image\Milk\Powdered milk\aptamil_bac.jpg", DateTime.Now, "Admin", DateTime.Now, "Admin"),
    //                 new (11, "Abott Grow", 3, "Abott Grow", 356000.0m, 7.9m, @"D:\.NET\BabyShopping_Image\Milk\Liquid milk\abottgrow.jpg", DateTime.Now, "Admin", DateTime.Now, "Admin")
    // ];

    const string GetProductEndPointName = "GetProduct";
    public static RouteGroupBuilder MapProductsEndpoint (this WebApplication app)
    {
        var group = app.MapGroup("products").WithParameterValidation();

        group.MapGet("/", async (BabyCareContext dbContext) => 
            await dbContext.Products
                     .Include(product => product.Category)
                     .Select(product => product.toProductSummaryDto())
                     .AsNoTracking()
                     .ToListAsync());


        //get products = 1
        group.MapGet("/{productId}", async (int productId, BabyCareContext babyCareContext)=>
        {
            Products? products = await babyCareContext.Products.FindAsync(productId);

            return products is null ? 
                Results.NotFound() : Results.Ok(products.toProductSummaryDto());
        }
        ).WithName(GetProductEndPointName);

        //POST product
        group.MapPost("/", async (CreateProductDTO newproduct, BabyCareContext dbContext) => 
        {
            // get max id
            Products? productEntity = dbContext.Products.OrderByDescending(product => product.ProductId).FirstOrDefault();
            // next id = max id + 1
            int productID = productEntity is null ? 1 : productEntity.ProductId + 1;
            // find category
            Categories? category = dbContext.Categories.Find(newproduct.RefCategoryId);
            // return error
            if(category is null) {
                return Results.NotFound();
            }

            Products product = newproduct.ToEntity();
            // insert new product
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return Results.CreatedAtRoute(GetProductEndPointName, new {id = productID}, product.toProductSummaryDto());


        });
        

        // PUT /products
        group.MapPut("/{id}", async (int id, UpdateProductDTO updatedProduct, BabyCareContext dbContext) =>
        {
            var existingProduct = await dbContext.Products.FindAsync(id);

            if (existingProduct is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingProduct)
                     .CurrentValues
                     .SetValues(updatedProduct.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //Delete products
        group.MapDelete("/{id}", async (int id, BabyCareContext dbContext) =>
        {
            await dbContext.Products
                     .Where(product => product.ProductId == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;

    }

}
