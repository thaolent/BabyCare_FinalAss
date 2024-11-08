using System.ComponentModel.DataAnnotations;
using BabyShopping_FinalAss.Entities;

namespace BabyShopping_FinalAss.DTOs;

public record class CreateProductDTO (
                [Required][StringLength(50)]string ProductName, 
                int RefCategoryId, 
                string DescriptionProduct, 
                decimal Price, 
                [Range(1,10)]decimal AveragePoint, 
                string Image, 
                DateTime CreatedDate, 
                string CreatedBy, 
                DateTime UpdatedDate, 
                string UpdatedBy
                );
