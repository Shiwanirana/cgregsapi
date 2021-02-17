using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;
using cgregsapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace cgregsapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HomesController : ControllerBase
  {
    private readonly HomesService _hs;
    public HomesController(HomesService hs)
    {
      _hs = hs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Home>> Get()
    {
      try{
      return Ok(_hs.Get());
      }
      catch(System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Home> GetHomeById(string id)
    {
     try{
       return Ok(_hs.GetHomeById(id));
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
    [HttpPost]
    public ActionResult<Home> Create([FromBody] Home newHome)
    {
      try{
        return Ok(_hs.Create(newHome));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Home> Edit(string id, [FromBody] Home editHome)
    {
      try{
        // Home foundHome = FAKEDB.Homes.Find(c=>c.Id==id);
        // editHome.Bedrooms = editHome.Bedrooms;
        // editHome.Bathrooms = editHome.Bathrooms;
        // editHome.Levels = editHome.Levels;
        // editHome.Year = editHome.Year;
        // editHome.Price = editHome.Price;
        // editHome.Description = editHome.Description != null?editHome.Description:foundHome.Description;
        // editHome.ImgUrl = editHome.ImgUrl != null?editHome.ImgUrl:foundHome.ImgUrl;
        editHome.Id=id;
        return Ok(_hs.Edit(editHome));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Home> Delete(string id)
    {
     try{
      //  Home homeToRemove = FAKEDB.Homes.Find(h=> h.Id==id);
      //  if(FAKEDB.Homes.Remove(homeToRemove)){
      //    return Ok("The Home information is deleted permanently!!!");
      //  };
      //  throw new System.Exception("This Home is not here!!");
      return Ok(_hs.Detele(id));
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
  }
}