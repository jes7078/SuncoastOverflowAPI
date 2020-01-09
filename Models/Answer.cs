using System;
using System.Text.Json.Serialization;

namespace SuncoastOverflowAPI.Models
{
  public class Answer
  {
    public int Id {get;set;}
    public string Body {get;set;}
    public int VoteCount {get;set;}
    public DateTime TimeStamp{get;set;} = DateTime.UtcNow;
    public int QuestionId {get;set;}
[JsonIgnore]
    public Question Question {get;set;}
  }
}