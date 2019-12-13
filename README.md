This project is implemented with C# and .NET Core, also used the HtmlAgilityPack (1.11.17) Nuget to scrap the data from the Html page.

I designed two API endpoints for this project.

1.	api/Scraper/QuestionData: This will return top 10 questions either Newest or Most Voted category.
In ScaperService class, the code extract the questions from the web page and the URL’s of those questions. There is a public method named GetQuestionDataList with two string type parameter, first one is the search keyword (Android in this case), and the second one is either category (Newest or Votes in this case). This will return 10 questions for search keyword in given category.

2.	api/Scraper/QuestionThread: This will return question thread for a specific question.
In ScaperService class, There is a public method named GetQuestionDataList with two string type parameter, first one is the search keyword, and the second one is category. Here extract the questions from the web page and the URL’s of those questions. This will return 10 questions for search keyword in given category.


To Run:
Clone this repository to your local drive.
Open the scraper.sln file with Visual Studio 2017 or later.
Run project with Visual Studio.

Frontend for this application can be found at https://github.com/IlmaAfrin/scraper-frontend
