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
public class AnswerController : ControllerBase
{
  private readonly DatabaseContext db;
  public AnswerController(DatabaseContext context)
  {
    db=context;
  }

  //Get: api/Answer
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
  {
    return await db.Answers.ToListAsync();
  }

   //Get: api/Answer/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Answer>> GetAnswer(int id)
  {
    var answer = await db.Answers.FindAsync(id);
    if (answer==null)
    {
      return NotFound();
    }
    return answer;
  }

  //PUT: api/Answer/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutAnswer(int id, Answer answer)
  {
    if (id!=answer.Id)
    {
      return BadRequest();
    }
    db.Entry(answer).State=EntityState.Modified;

    try
    {
      await db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!AnswerExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }
    // return NoContent();
    return Ok(answer);
  }

  //POST: api/Answer
  [HttpPost]
  public async Task<ActionResult<Answer>> PostQuestion(Answer answer)
  {
    db.Answers.Add(answer);
    await db.SaveChangesAsync();
    return Ok(answer);
  }

  //DELETE: api/Answer/5
  [HttpDelete("{id}")]
  public async Task<ActionResult<Answer>> DeleteAnswer(int id)
  {
    var answer = await db.Answers.FindAsync(id);
    if (answer==null)
    {
      return NotFound();
    }
    db.Answers.Remove(answer);
    await db.SaveChangesAsync();
    return answer;
  }

  private bool AnswerExists(int id)
  {
    return db.Answers.Any(e=>e.Id == id);
  }
}
}