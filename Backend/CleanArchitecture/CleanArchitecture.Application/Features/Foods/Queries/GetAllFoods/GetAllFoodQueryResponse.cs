using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Foods.Queries.GetAllFoods
{
    public class GetAllFoodQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }
        public int? FoodImageFileId { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
    }
}
