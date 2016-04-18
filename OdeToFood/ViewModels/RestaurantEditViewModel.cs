﻿using System.ComponentModel.DataAnnotations;
using OdeToFood.Enums;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
