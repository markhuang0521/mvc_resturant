using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Spicyness { get; set; }

        public enum  ESpicy  { NA=0,NotSpicy=1, Spicy=2,verySpicy=3}
        public string Image { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "price should greater than $1")]
        public double Price { get; set; }


        [Display(Name = "category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "sub category")]
        public int SubCateId { get; set; }
        [ForeignKey("SubCateId")]
        public virtual SubCategory SubCategory { get; set; }


    }
}
