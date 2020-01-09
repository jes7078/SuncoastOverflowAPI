using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuncoastOverflowAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuncoastOverflowAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SearchController: ControllerBase
  {
    private readonly DatabaseContext db;

    public SearchController(DatabaseContext context)
    {
      this.db=context;
    }

    [HttpGet]
    //https://localhost:5001/api/Search?searchTerm=who
    public async Task<ActionResult> SearchQuestions([FromQuery]string searchTerm)
    {
      var results=db.Questions.Where(question=>question.Title.ToLower().Contains(searchTerm.ToLower()) || question.Description.ToLower().Contains(searchTerm.ToLower()) || question.Body.ToLower().Contains(searchTerm.ToLower()));
      var query=new SearchQuery
      {
        SearchTerm = searchTerm
      };
      db.SearchQueries.Add(query);
      await db.SaveChangesAsync();
      return Ok(results);
    }

    [HttpGet("queries")]
    //https://localhost:5001/api/Search/queries
    public async Task<ActionResult> GetRecentSearchQueries()
    {
      var queries = db.SearchQueries.OrderByDescending(o=>o.TimeStamp).Take(10);
      return Ok(queries);
    }
  }
}