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
  public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
  {
    return await db.Questions.OrderBy(o=>o.Title).ToListAsync();
  }

   //Get: api/Question/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Question>> GetQuestion(int id)
  {
    var question = await db.Questions.FindAsync(id);
    if (question==null)
    {
      return NotFound();
    }
    return question;
  }

  //PUT: api/Question/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutQuestion(int id, Question question)
  {
    if (id!=question.Id)
    {
      return BadRequest();
    }
    db.Entry(question).State=EntityState.Modified;

    try
    {
      await db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!QuestionExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }
    return NoContent();
  }

  //POST: api/Question
  [HttpPost]
  public async Task<ActionResult<Question>> PostQuestion(Question question)
  {
    db.Questions.Add(question);
    await db.SaveChangesAsync();
    return Ok(question);
  }

  //DELETE: api/Question/5
  [HttpDelete("{id}")]
  public async Task<ActionResult<Question>> DeleteQuestion(int id)
  {
    var question = await db.Questions.FindAsync(id);
    if (question==null)
    {
      return NotFound();
    }
    db.Questions.Remove(question);
    await db.SaveChangesAsync();
    return question;
  }

  private bool QuestionExists(int id)
  {
    return db.Questions.Any(e=>e.Id == id);
  }
}
}