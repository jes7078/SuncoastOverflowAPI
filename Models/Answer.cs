using System;

namespace SuncoastOverflowAPI.Models
{
  public class Answer
  {
    public int Id {get;set;}
    public string Body {get;set;}
    public int VoteCount {get;set;}
    public DateTime TimeStamp{get;set;}
    public int QuestionId {get;set;}

    public Question Question {get;set;}
  }
}