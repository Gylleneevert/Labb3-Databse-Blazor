using Labb3_Databse_Blazor.Data;

namespace Labb3_Databse_Blazor.Pages
{
    public partial class CreateQuestion
    {
        string statement = string.Empty;
        List<string> options = new List<string>
        {
            "",
            "",
            "",
            ""
        };
        string correctAnswer = string.Empty;





        MongoCRUD db = new MongoCRUD("QuizDB");
        public void SaveQuestion()
        {






            Questions question = new Questions
            {
                Id = Guid.NewGuid(),
                Statement = statement,
                Options = options,
                CorrectAnswer = correctAnswer
            };

            db.AddQuestionDB("Question", question);
        }

    }
}



