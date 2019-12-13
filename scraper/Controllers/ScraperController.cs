using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using scraper.Models;
using scraper.Services;

namespace scraper.Controllers
{    
    [Route("api/[controller]")]
    public class ScraperController : Controller
    {
        public ScraperService ScraperService { get; set; }
        public ScraperController()
        {
            ScraperService = new ScraperService();
        }
        [HttpGet("QuestionData")]
        public List<QuestionData> GetQuestionData(string keyword, string category)
        {
            return ScraperService.GetQuestionDataList(keyword, category);
        }
        [HttpGet("QuestionThread")]
        public QuestionThread GetQuestionThread(string url)
        {
            return ScraperService.GetQuestionThread(url);
        }
        
        
    }
}
