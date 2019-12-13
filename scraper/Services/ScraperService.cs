using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using scraper.Models;

namespace scraper.Services
{
    public class ScraperService
    {
        public string GetResult(string url)
        {
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var result = reader.ReadToEnd();
                return result;
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                reader?.Close();
                response?.Close();
            }
        }
        public List<QuestionData> GetQuestionDataList(string searchwith, string tab)
        {
            var url = $"https://stackoverflow.com/questions/tagged/{searchwith}?tab={tab}";
            const string questionHyperlink = "question-hyperlink";
            var questions = new List<QuestionData>();
            var result = GetResult(url);
            var startIndex = 0;
            for (var i = 0; i < 10; i++)
            {
                var classIndex = result.IndexOf(questionHyperlink, startIndex, StringComparison.Ordinal);
                questions.Add(GetQuestionData(result, questionHyperlink, classIndex, out startIndex));
            }
            return questions;
        }
        private static QuestionData GetQuestionData(string result, string questionHyperlink, int classIndex, out int startIndex)
        {
            var qIndex = classIndex + questionHyperlink.Length + 2;
            var qLastIndex = result.IndexOf("</a>", qIndex, StringComparison.Ordinal);
            var question = result.Substring(qIndex, qLastIndex - qIndex);
            startIndex = qLastIndex + 1;
            var lLastIndex = classIndex - 10;
            var lFirstIndex = lLastIndex;
            while (result[lFirstIndex] != '"') lFirstIndex--;
            var link = result.Substring(lFirstIndex + 1, lLastIndex - lFirstIndex - 1);
            link = $"https://stackoverflow.com{link}";
            return new QuestionData { Question = question, Link = link };
        }

        public QuestionThread GetQuestionThread(string url)
        {            
            var web = new HtmlWeb();
            var htmlDoc = web.Load(url);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='post-text']");
            var answers = nodes.Skip(1).Select(node => new QuestionAnswer{Answer = node.InnerText.Replace("\n","<br>") }).ToList();
            var question = new QuestionDetail {Question = nodes.First().InnerText.Replace("\n", "<br>") };
            return new QuestionThread{QuestionDetail = question, QuestionAnswers = answers};
        }
    }
}
