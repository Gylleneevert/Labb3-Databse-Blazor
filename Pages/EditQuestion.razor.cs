using Labb3_Databse_Blazor.Data;

namespace Labb3_Databse_Blazor.Pages
{
    public partial class EditQuestion
    {

        MongoCRUD db = new MongoCRUD("QuizDB");
        private int selectedAnswer = -1;
        public void SaveQuestion()
        {
            var selsectedQuestion = Program.QuestionToEdit;

            selsectedQuestion.Statement = Program.QuestionToEdit.Statement;
            selsectedQuestion.Options = Program.QuestionToEdit.Options.Where(o => o != null).ToList();
            selsectedQuestion.CorrectAnswer = Program.QuestionToEdit.CorrectAnswer;



            db.UpsertQuestionDB("Question", selsectedQuestion);

            StateHasChanged();
        }

        public bool correctAnswer(int radioIndex)
        {


            return selectedAnswer == radioIndex;

        }

        public void DeleteQuestion()
        {

            db.DeleteQuestionDB("Question", Program.QuestionToEdit);

            StateHasChanged();
            nav.NavigateTo("/Questions");

        }




        public void Cancel()
        {
            nav.NavigateTo($"/Questions");
        }
    }
}


