using System;
using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;

namespace cgregsapi.Services
{
  public class CarsService
  {
   // GetAll
   public IEnumerable<Car> Get()
   {
     return FAKEDB.Cars;
   }
   //Get by Id
   public Car GetCarById(string id)
   {
     Car carToReturn = FAKEDB.Cars.Find(c=> c.Id==id);
     if(carToReturn==null)
     {
       throw new Exception("Invalid Id");
     }
     return carToReturn;
   }
   //Create
   public Car Create(Car newCar)
   {
     FAKEDB.Cars.Add(newCar);
     return newCar;
   }
   //Edit
   public Car Edit(Car editCar)
   {
     Car foundCar = FAKEDB.Cars.Find(c=> c.Id==editCar.Id);
     if(foundCar==null)
     {
       throw new Exception("Invalid Id");
     }
     FAKEDB.Cars.Remove(foundCar);
     FAKEDB.Cars.Add(editCar);
     return editCar;
   }
   //Remove
   public string Delete(string id)
   {
     Car carToRemove = FAKEDB.Cars.Find(c=>c.Id==id);
     if(carToRemove==null)
     {
       throw new Exception("Invlid Id");
     }
     FAKEDB.Cars.Remove(carToRemove);
     return "This Car's data is permanently removed";
   }
  }
}