using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId{get;set;}

        [Required(ErrorMessage="Required: ")]
        public string Name{get;set;}
        [Required(ErrorMessage="Required: ")]
        public int Calories{get;set;}
        [Required(ErrorMessage="Required: ")]
        public int Tastiness{get;set;}
        public string Description{get;set;}        
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;
        public int ChefId {get;set;}
        public Chef ChefName{get;set;}

    }
}