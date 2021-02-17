using System;
using System.ComponentModel.DataAnnotations;

namespace cgregsapi.Models
{
  public class Car
  {
   public Car(string make, string model, int year, int price, string description, string imgUrl)
   {
     Make = make;
     Model = model;
     Year = year;
     Price = price;
     Description = description;
     ImgUrl = imgUrl;
   }
   [Required]
   [MinLength(3)]
   public string Make {get;set;}
   [MinLength(4)]
   public string Model {get;set;}
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