using BabyShopping_FinalAss.Entities;

namespace BabyShopping_FinalAss.DTOs;

public record class ProductsDTO(int ProductId, string ProductName, int RefCategoryId, string DescriptionProduct,
                                    decimal Price, decimal AveragePoint, string Image, DateTime CreatedDate,
                                    string CreatedBy, DateTime UpdatedDate, string UpdatedBy);
// {
   
    // private int _ProductId;
    // private string _ProductName;
    // private int _RefCategoryId;
    // private string _DescriptionProduct;
    // private decimal _Price;
    // private decimal _AveragePoint;
    // private string _Image;
    // private DateTime _CreatedDate;
    // private string _CreatedBy;
    // private DateTime _UpdatedDate;
    // private string _UpdatedBy;


    // public ProductsDTO(int ProductId, string ProductName, int RefCategoryId, string DescriptionProduct,
    //                                 decimal Price, decimal AveragePoint, string Image, DateTime CreatedDate,
    //                                 string CreatedBy, DateTime UpdatedDate, string UpdatedBy)
    // {
    //     _ProductId = ProductId;
    //     _ProductName = ProductName;
    //     _RefCategoryId = RefCategoryId;
    //     _DescriptionProduct = DescriptionProduct;
    //     _Price = Price;
    //     _AveragePoint = AveragePoint;
    //     _Image = Image;
    //     _CreatedDate = CreatedDate;
    //     _CreatedBy = CreatedBy;
    //     _UpdatedDate = UpdatedDate;
    //     _UpdatedBy = UpdatedBy;
        
    // }

    
// }

