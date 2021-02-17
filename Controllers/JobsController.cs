using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace cgregsapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try{
      return Ok(FAKEDB.Jobs);
      }
      catch(System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Job> GetJobById(string id)
    {
     try{
       Job jobToReturn = FAKEDB.Jobs.Find(j=>j.Id==id);
       return Ok(jobToReturn);
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try{
        FAKEDB.Jobs.Add(newJob);
        return Ok(newJob);
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Job> Edit(string id, [FromBody] Job editJob)
    {
      try{
        Job foundJob = FAKEDB.Jobs.Find(c=>c.Id==id);
        editJob.Company = editJob.Company != null?editJob.Company:foundJob.Company;
        editJob.JobTitle = editJob.JobTitle != null?editJob.JobTitle:foundJob.JobTitle;
        editJob.Hours = editJob.Hours;
        editJob.Salary = editJob.Salary;
        editJob.Description = editJob.Description != null?editJob.Description:foundJob.Description;
        editJob.Rate = editJob.Rate;
        FAKEDB.Jobs.Remove(foundJob);
        FAKEDB.Jobs.Add(editJob);
        return Ok(editJob);
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Job> Delete(string id)
    {
     try{
       Job jobToRemove = FAKEDB.Jobs.Find(j=> j.Id==id);
       if(FAKEDB.Jobs.Remove(jobToRemove)){
         return Ok("The Job information is deleted permanently!!!");
       };
       throw new System.Exception("This Job is not here!!");
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
  }
}