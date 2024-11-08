using System;
using System.ComponentModel.DataAnnotations;

namespace BabyShopping_FinalAss.Entities;

public class Products
{
    [Key]public int ProductId { get; set; }
    public required string ProductName { get; set; }

    public int CategoryId {get; set;}
    public Categories? Category { get; set; }

    public string Description { get; set; } = String.Empty;

    public decimal AveragePoint { get; set; }
= 0;
    public decimal Price { get; set; }
= 0;
    public required String Image { get; set; }

    public DateTime CreatedDate { get; set; }

    public required String CreatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public required String UpdatedBy { get; set; }

}
