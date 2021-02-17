using System;
using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;

namespace cgregsapi.Services
{
  public class JobsService
  {
   //GetAll
   public IEnumerable<Job> Get()
   {
     return FAKEDB.Jobs;
   }
   //GetById
   public Job GetJobById(string id)
   {
    Job jobToReturn = FAKEDB.Jobs.Find(h=>h.Id==id);
    if(jobToReturn==null)
    {
      throw new Exception("Invalid Id");
    }
    return jobToReturn;
   }
   //Create
   public Job Create(Job newJob)
   {
     FAKEDB.Jobs.Add(newJob);
     return newJob;
   }
   //Edit
   public Job Edit(Job editJob)
   {
     Job foundJob = FAKEDB.Jobs.Find(h=>h.Id==editJob.Id);
     if(foundJob==null)
     {
       throw new Exception("Invalid Id");
     }return editJob;
   }
   //Delete
   public string Detele(string id)
   {
     Job jobToRemove = FAKEDB.Jobs.Find(h=>h.Id==id);
     if(jobToRemove==null)
     {
      throw new Exception("Invalid Id");
     }
     FAKEDB.Jobs.Remove(jobToRemove);
     return "This Job is removed.";
   }
  }
}