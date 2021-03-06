using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuncoastOverflowAPI.Models{
  public class Question
  {
    public int Id {get;set;}
    public string Title{get;set;}
    public string Body{get;set;}
    public string Description{get;set;}

    public DateTime TimeStamp{get;set;} = DateTime.UtcNow;

    public int VoteCount{get;set;}

    public List<Answer> Answers {get;set;} = new List<Answer>();
  }
}