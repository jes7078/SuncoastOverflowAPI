using System;

namespace SuncoastOverflowAPI.Models
{
  public class SearchQuery
  {
    public int Id {get; set;}
    public string SearchTerm {get; set;}
    public DateTime TimeStamp {get; set;} = DateTime.UtcNow;
  }
}