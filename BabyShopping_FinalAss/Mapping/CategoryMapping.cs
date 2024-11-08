using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;

namespace BabyShopping_FinalAss.Mapping
{
    public static class CategoryMapping
    {
        public static Categories ToEntity (this CreateCategories _cate)
        {
            return new Categories()
            {
                CategoryName = _cate.CategoryName,
                Description = _cate.CategoryName
            };
        }

        public static Categories ToEntity (this UpdateCategoryDTO _updatcate, int cate_Id)
        {
            return new Categories()
            {
                CategoryId = cate_Id,
                CategoryName = _updatcate.CategoryName,
                Description = _updatcate.CategoryName
            };
        }

        public static CategorySumaryDTO toCateSummaryDto (this Categories cates)
        {
            return new (
                cates.CategoryId,
                cates.CategoryName,
                cates.Description
            );
        }
        
    }
}