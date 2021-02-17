using System.Collections.Generic;
using cgregsapi.Models;

namespace cgregsapi.db
{
  public class FAKEDB
  {
    public static List<Car> Cars {get;set;} = new List<Car>();
    public static List<Home> Homes {get;set;} = new List<Home>();
    public static List<Job> Jobs {get;set;} = new List<Job>();
  }
}