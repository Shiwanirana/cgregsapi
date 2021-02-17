using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;
using cgregsapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace cgregsapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;
    public JobsController(JobsService js)
    {
      _js=js;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try{
      return Ok(_js.Get());
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
      //  Job jobToReturn = FAKEDB.Jobs.Find(j=>j.Id==id);
       return Ok(_js.GetJobById(id));
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try{
        // FAKEDB.Jobs.Add(newJob);
        return Ok(_js.Create(newJob));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Job> Edit(string id, [FromBody] Job editJob)
    {
      try{
        // Job foundJob = FAKEDB.Jobs.Find(c=>c.Id==id);
        // editJob.Company = editJob.Company != null?editJob.Company:foundJob.Company;
        // editJob.JobTitle = editJob.JobTitle != null?editJob.JobTitle:foundJob.JobTitle;
        // editJob.Hours = editJob.Hours;
        // editJob.Salary = editJob.Salary;
        // editJob.Description = editJob.Description != null?editJob.Description:foundJob.Description;
        // editJob.Rate = editJob.Rate;
        // FAKEDB.Jobs.Remove(foundJob);
        // FAKEDB.Jobs.Add(editJob);
        editJob.Id=id;
        return Ok(_js.Edit(editJob));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Job> Delete(string id)
    {
     try{
      //  Job jobToRemove = FAKEDB.Jobs.Find(j=> j.Id==id);
      //  if(FAKEDB.Jobs.Remove(jobToRemove)){
      //    return Ok("The Job information is deleted permanently!!!");
      //  };
      //  throw new System.Exception("This Job is not here!!");
      return Ok(_js.Detele(id));
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
  }
}