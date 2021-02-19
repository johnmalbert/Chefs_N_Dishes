using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId{get;set;}

        [Required(ErrorMessage="Required: ")]
        public string Name{get;set;}

        [Required(ErrorMessage="Required: ")]
        [DoB(ErrorMessage="Must be at least 18 Years Old")]
        public DateTime DOB{get;set;}
        public List<Dish> CreatedDishes {get;set;} = null;
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;

        

    }
    public class DoBAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return true;
            }
            var val = (DateTime)value;
            return (val.AddYears(18) < DateTime.Now);
        }
    }
}