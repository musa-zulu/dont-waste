﻿using System;

namespace OnlineStore.Contracts.V1.Requests
{
    public class CreateFoodItemRequest
    {
        public Guid FoodItemId { get; set; }
        public string DishName { get; set; }
        public string FoodItemDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        public Guid FoodCategoryId { get; set; }
        public virtual CreateFoodCategoryRequest FoodCategory { get; set; }
    }
}
