using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace cgregsapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HomesController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Home>> Get()
    {
      try{
      return Ok(FAKEDB.Homes);
      }
      catch(System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Home> GetCarById(string id)
    {
     try{
       Home homeToReturn = FAKEDB.Homes.Find(h=>h.Id==id);
       return Ok(homeToReturn);
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
    [HttpPost]
    public ActionResult<Home> Create([FromBody] Home newHome)
    {
      try{
        FAKEDB.Homes.Add(newHome);
        return Ok(newHome);
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Home> Edit(string id, [FromBody] Home editHome)
    {
      try{
        Home foundHome = FAKEDB.Homes.Find(c=>c.Id==id);
        editHome.Bedrooms = editHome.Bedrooms;
        editHome.Bathrooms = editHome.Bathrooms;
        editHome.Levels = editHome.Levels;
        editHome.Year = editHome.Year;
        editHome.Price = editHome.Price;
        editHome.Description = editHome.Description != null?editHome.Description:foundHome.Description;
        editHome.ImgUrl = editHome.ImgUrl != null?editHome.ImgUrl:foundHome.ImgUrl;
        FAKEDB.Homes.Remove(foundHome);
        FAKEDB.Homes.Add(editHome);
        return Ok(editHome);
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Home> Delete(string id)
    {
     try{
       Home homeToRemove = FAKEDB.Homes.Find(h=> h.Id==id);
       if(FAKEDB.Homes.Remove(homeToRemove)){
         return Ok("The Home information is deleted permanently!!!");
       };
       throw new System.Exception("This Home is not here!!");
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
  }
}