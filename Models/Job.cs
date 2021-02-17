using System;
using System.ComponentModel.DataAnnotations;

namespace cgregsapi.Models
{
  public class Job
  {
   public Job(string company, string jobTitle, int hours, int salary, string description, int rate)
   {
     Company = company;
     JobTitle = jobTitle;
     Hours = hours;
     Salary = salary;
     Description = description;
     Rate = rate;
   }
   [Required]
   [MinLength(3)]
   public string Company {get;set;}
   [MinLength(4)]
   public string JobTitle {get;set;}
   [Range(5,20)]
   public int Hours {get;set;}
   [Range(100,1000000000000000)]
   public int Salary {get;set;}
   [MaxLength(50)]
   public string Description {get;set;}
   [Range(0,20)]
   public int Rate {get;set;}
   public string Id {get;set;} = Guid.NewGuid().ToString();
  }
}