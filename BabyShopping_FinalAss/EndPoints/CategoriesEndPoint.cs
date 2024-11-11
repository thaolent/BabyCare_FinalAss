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

    const string GetCategoryEndPointName = "GetCategory";
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
        group.MapGet("/{cateId}", async (int cateId, BabyCareContext babyCareContext) => 
        {
            // CategoryDTO? cate = categories.Find(categories =>categories.CategoryID == categoryId);
            // return cate is null ? Results.NotFound(): Results.Ok(cate);

            Categories? cates = await babyCareContext.Categories.FindAsync(cateId);

            return cates is null ? 
                Results.NotFound() : Results.Ok(cates.toCateDetailDto());
        }
        ).WithName(GetCategoryEndPointName);

        //POST Category
        group.MapPost("/", async (CreateCategories newcat, BabyCareContext dbContext) => 
        {
            Categories? categoryEntity = dbContext.Categories.OrderByDescending(cate => cate.CategoryId).FirstOrDefault();
            // next id = max id + 1
            int cateID = categoryEntity is null ? 1 : categoryEntity.CategoryId + 1;
            Categories categories = newcat.ToEntity();
            // insert new product
            dbContext.Categories.Add(categories);
            await dbContext.SaveChangesAsync();
            return Results.CreatedAtRoute(GetCategoryEndPointName, new {cateId = cateID}, categories.toCateSummaryDto());

        });

        //Put Category
        group.MapPut ("/{cateId}",async (int cateId, UpdateCategoryDTO updatedCate, BabyCareContext dbContext)=>
        {

            var existingCate = await dbContext.Categories.FindAsync(cateId);

            if (existingCate is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingCate)
                     .CurrentValues
                     .SetValues(updatedCate.ToEntity(cateId));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();

        }
        );

        //Delete cate
        group.MapDelete("/{cateId}", async (int cateId, BabyCareContext dbContext) =>
        {
            await dbContext.Categories
                     .Where(cate => cate.CategoryId == cateId)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        }
        );

        return group;
    }



}
