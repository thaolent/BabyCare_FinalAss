using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyShopping_FinalAss.DTOs;
public record class ProductSummaryDto(
    int ProductId,
    string ProductName,
    int CategoryId,
    string Description,
    decimal AveragePoint,
    decimal Price,
    String Image
);
