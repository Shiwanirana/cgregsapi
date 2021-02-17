using System;
using System.ComponentModel.DataAnnotations;

namespace cgregsapi.Models
{
  public class Home
  {
   public Home(int bedrooms, int bathrooms, int levels,int year, int price, string description, string imgUrl)
   {
     Bedrooms = bedrooms;
     Bathrooms = bathrooms;
     Levels = levels;
     Year = year;
     Price = price;
     Description = description;
     ImgUrl = imgUrl;
   }
   [Required]
   [Range(0,15)]
   public int Bedrooms {get;set;}
   [Range(0,15)]
   public int Bathrooms {get;set;}
   [Range(0,20)]
   public int Levels {get;set;}
   public int Year {get;set;}
   [Range(100,1000000000000000)]
   public int Price {get;set;}
   [MaxLength(50)]
   public string Description {get;set;}
   [MinLength(3)]
   public string ImgUrl {get;set;}
   public string Id {get;set;} = Guid.NewGuid().ToString();
  }
}