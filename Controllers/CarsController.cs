using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;
using cgregsapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace cgregsapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;
    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try{
      return Ok(_cs.Get());
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
       Car carToReturn = _cs.GetCarById(id);
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
        return Ok(_cs.Create(newCar));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Car> Edit(string id, [FromBody] Car editCar)
    {
      try{
        // Car foundCar = FAKEDB.Cars.Find(c=>c.Id==id);
        // editCar.Make = editCar.Make != null?editCar.Make:foundCar.Make;
        // editCar.Model = editCar.Model != null?editCar.Model:foundCar.Model;
        // editCar.Year = editCar.Year;
        // editCar.Price = editCar.Price;
        // editCar.Description = editCar.Description != null?editCar.Description:foundCar.Description;
        // editCar.ImgUrl = editCar.ImgUrl != null?editCar.ImgUrl:foundCar.ImgUrl;
        editCar.Id=id;
        return Ok(_cs.Edit(editCar));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Car> Delete(string id)
    {
     try{
       _cs.Delete(id);
       return Ok("This car is no longer in the database!!");
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
  }
}