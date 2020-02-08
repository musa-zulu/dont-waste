﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DontWaste.DB.Domain;

namespace DontWaste.Contracts.Interfaces.Services
{
    public interface IFoodCategoryService
    {
        Task<List<FoodCategory>> GetFoodCategoriesAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateFoodCategoryAsync(FoodCategory foodCategory);
        Task<FoodCategory> GetFoodCategoryByIdAsync(Guid foodCategoryId);
        Task<bool> UpdateFoodCategoryAsync(FoodCategory foodCategoryToUpdate);
        Task<bool> DeleteFoodCategoryAsync(Guid foodCategoryId);
    }
}
