using System;
using System.Collections.Generic;

namespace scraper.Models
{
    public class QuestionData
    {
        public string Question { get; set; }
        public string Link { get; set; }
    }

    public class QuestionThread
    {
        public QuestionDetail QuestionDetail { get; set; }
        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }

    public class QuestionAnswer
    {
        public DateTime Date { get; set; }
        public int Votes { get; set; }
        public string Answer { get; set; }
    }

    public class QuestionDetail
    {
        public DateTime Date { get; set; }
        public int Votes { get; set; }
        public string Question { get; set; }
    }
}