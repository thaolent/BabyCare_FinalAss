using System;
using BabyShopping_FinalAss.Data;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;
using BabyShopping_FinalAss.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BabyShopping_FinalAss.EndPoints;

public static class CategoriesEndPoint
{
    // private static readonly List <CategoryDTO> categories = [
    //                     new (1, "Diapers", "Diaper for infant and baby"),
    //                     new (2, "Powdered Milk", "A dairy product made by evaporating milk to dryness"),
    //                     new (3, "Reconstituted milk", "Mixing milk powder with water to create liquid milk")
    // ];

    const string GetCategoryEndPointName = "Get Category";
    public static RouteGroupBuilder MapCategoriesEndPoint (this WebApplication app)
    {
        var group = app.MapGroup("categories");

        //Get categories, products and ratings
        // group.MapGet("/",()=>categories);

        group.MapGet("/", async (BabyCareContext dbContext) => 
            await dbContext.Categories
                     .Select(cate => cate.toCateSummaryDto())
                     .AsNoTracking()
                     .ToListAsync());

        //get category with id = 1
        group.MapGet("/{categoryId}",async (int cateId, BabyCareContext babyCareContext) => 
        {
            // CategoryDTO? cate = categories.Find(categories =>categories.CategoryID == categoryId);
            // return cate is null ? Results.NotFound(): Results.Ok(cate);

            Categories? cates = await babyCareContext.Categories.FindAsync(cateId);

            return cates is null ? 
                Results.NotFound() : Results.Ok(cates.toCateSummaryDto());
        }
        ).WithName(GetCategoryEndPointName);

        //POST Category
        group.MapPost("/",(CreateCategories newcat, BabyCareContext dbContext) => 
        {
            // get max id
            Categories? categoryEntity = dbContext.Categories.OrderByDescending(cate => cate.CategoryId).FirstOrDefault();
            // next id = max id + 1
            int categoryID = categoryEntity is null ? 1 : categoryEntity.CategoryId + 1;
            // Categories cateEntity = new Categories {
            //     CategoryId = categoryID, 
            //     CategoryName = newcat.CategoryName,
            //     Description = newcat.Description
            // };

            Categories cate = newcat.ToEntity();
            // insert new product
            dbContext.Categories.Add(cate);
            dbContext.SaveChanges();
            return Results.CreatedAtRoute(GetCategoryEndPointName, new {id = categoryID}, cate.toCateSummaryDto());

        }).WithName(GetCategoryEndPointName);

        //Put Category
        group.MapPut ("/{_categoryId}",async (int id, UpdateProductDTO updatedProduct, BabyCareContext dbContext)=>
        {

            var existingCate = await dbContext.Categories.FindAsync(id);

            if (existingCate is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingCate)
                     .CurrentValues
                     .SetValues(updatedProduct.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();

        }
        );

        //Delete cate
        group.MapDelete("/{Cate_Id}", async (int id, BabyCareContext dbContext) =>
        {
            await dbContext.Categories
                     .Where(cate => cate.CategoryId == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        }
        );

        return group;
    }



}
