using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuncoastOverflowAPI.Models;

namespace SuncoastOverflowAPI.Controllers
{
 [Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
  private readonly DatabaseContext db;
  public QuestionController(DatabaseContext context)
  {
    db=context;
  }

  //Get: api/Question
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Question>>>GetQuestions()
  {
    return await db.Questions.OrderBy(o=>o.Title).ToListAnsync();
  }
  
}
}