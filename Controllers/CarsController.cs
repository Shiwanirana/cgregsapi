using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace cgregsapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try{
      return Ok(FAKEDB.Cars);
      }
      catch(System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(string id)
    {
     try{
       Car carToReturn = FAKEDB.Cars.Find(c=>c.Id==id);
       return Ok(carToReturn);
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try{
        FAKEDB.Cars.Add(newCar);
        return Ok(newCar);
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Car> Edit(string id, [FromBody] Car editCar)
    {
      try{
        Car foundCar = FAKEDB.Cars.Find(c=>c.Id==id);
        editCar.Make = editCar.Make != null?editCar.Make:foundCar.Make;
        editCar.Model = editCar.Model != null?editCar.Model:foundCar.Model;
        editCar.Year = editCar.Year;
        editCar.Price = editCar.Price;
        editCar.Description = editCar.Description != null?editCar.Description:foundCar.Description;
        editCar.ImgUrl = editCar.ImgUrl != null?editCar.ImgUrl:foundCar.ImgUrl;
        FAKEDB.Cars.Remove(foundCar);
        FAKEDB.Cars.Add(editCar);
        return Ok(editCar);
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Car> Delete(string id)
    {
     try{
       Car carToRemove = FAKEDB.Cars.Find(c=> c.Id==id);
       if(FAKEDB.Cars.Remove(carToRemove)){
         return Ok("The car information is deleted permanently!!!");
       };
       throw new System.Exception("This Car is not here!!");
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
  }
}