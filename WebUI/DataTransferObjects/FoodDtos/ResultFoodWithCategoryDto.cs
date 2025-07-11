﻿namespace WebUI.DataTransferObjects.FoodDtos
{
    public class ResultFoodWithCategoryDto
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool FoodStatus { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
