using System;
using System.Collections.Generic;
using cgregsapi.db;
using cgregsapi.Models;

namespace cgregsapi.Services
{
  public class HomesService
  {
   //GetAll
   public IEnumerable<Home> Get()
   {
     return FAKEDB.Homes;
   }
   //GetById
   public Home GetHomeById(string id)
   {
    Home homeToReturn = FAKEDB.Homes.Find(h=>h.Id==id);
    if(homeToReturn==null)
    {
      throw new Exception("Invalid Id");
    }
    return homeToReturn;
   }
   //Create
   public Home Create(Home newHome)
   {
     FAKEDB.Homes.Add(newHome);
     return newHome;
   }
   //Edit
   public Home Edit(Home editHome)
   {
     Home foundHome = FAKEDB.Homes.Find(h=>h.Id==editHome.Id);
     if(foundHome==null)
     {
       throw new Exception("Invalid Id");
     }return editHome;
   }
   //Delete
   public string Detele(string id)
   {
     Home homeToRemove = FAKEDB.Homes.Find(h=>h.Id==id);
     if(homeToRemove==null)
     {
      throw new Exception("Invalid Id");
     }
     FAKEDB.Homes.Remove(homeToRemove);
     return "This home is removed.";
   }
  }
}