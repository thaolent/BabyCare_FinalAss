using System;
using BabyShopping_FinalAss.Data;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BabyShopping_FinalAss.Mapping;

public static class ProductMapping
{
    public static Products ToEntity(this CreateProductDTO product)
    { 
        
        return new Products()
        {
            ProductName = product.ProductName,
            CategoryId = product.RefCategoryId,
            Description = product.DescriptionProduct,
            Price = product.Price,
            AveragePoint = product.AveragePoint,
            Image = product.Image,
            CreatedDate = DateTime.Now,
            CreatedBy = product.CreatedBy,
            UpdatedDate = DateTime.Now,
            UpdatedBy = product.UpdatedBy
        };
    }

    public static Products ToEntity (this UpdateProductDTO updateproduct, int product_Id)
    {
        return new Products()
        {
            ProductId = product_Id,
            ProductName = updateproduct.ProductName,
            CategoryId = updateproduct.RefCategoryId,
            Description = updateproduct.DescriptionProduct,
            Price = updateproduct.Price,
            AveragePoint = updateproduct.AveragePoint,
            Image = updateproduct.Image,
            CreatedDate = DateTime.Now,
            CreatedBy = updateproduct.CreatedBy,
            UpdatedDate = DateTime.Now,
            UpdatedBy = updateproduct.UpdatedBy
        };
    }

    public static ProductSummaryDto toProductSummaryDto (this Products products)
    {
        return new (
            products.ProductId,
            products.ProductName,
            products.CategoryId,
            products.Description,
            products.Price,
            products.AveragePoint,
            products.Image
        );
    }

    public static ProductDetailDto toProductDetailDto (this Products products)
    {
        return new (
            products.ProductId,
            products.ProductName,
            products.CategoryId,
            products.Description,
            products.Price,
            products.AveragePoint,
            products.Image
        );
    }
}
