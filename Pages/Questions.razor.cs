using Labb3_Databse_Blazor.Data;
using MongoDB.Bson.Serialization.Attributes;

namespace Labb3_Databse_Blazor.Pages
{
    public partial class Questions
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Statement { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }

        MongoCRUD db = new MongoCRUD("QuizDB");


        List<Questions> questionList;

        protected override Task OnInitializedAsync()
        {
            questionList = db.ReadQuestionsDB("Question");

            return base.OnInitializedAsync();
        }

        public void Edit(Questions question)
        {
            Program.QuestionToEdit = question;
            nav.NavigateTo("/EditQuestion");
        }

        //public void ANumberOfQuestions()
        //{
        //    Questions q1 = new Questions
        //    {

        //        Statement = "Vem är världens mest kända fotbollsspelare?",
        //        Options = new List<string> { "Lionel Messi", "Cristiano Ronaldo", "Neymar", "Andrés Iniesta" },
        //        CorrectAnswer = "Cristiano Ronaldo"



        //    };
        //    Questions q2 = new Questions
        //    {
        //        Statement = "Vilket land vann fotbolls-VM 2018?",
        //        Options = new List<string> { "Argentina", "Tyskland", "Frankrike", "Brasilien" },
        //        CorrectAnswer = "Frankrike"

        //    };
        //    Questions q3 = new Questions
        //    {
        //        Statement = "Vilket lag vann UEFA Champions League 2020-2021?",
        //        Options = new List<string> { "Real Madrid", "Manchester City", "Chelsea", "Barcelona" },
        //        CorrectAnswer = "Chelsea"

        //    };
        //    Questions q4 = new Questions
        //    {
        //        Statement = "Vem är känd som 'Kungen' inom fotbollen?",
        //        Options = new List<string> { "Zinedine Zidane", "Pele", "Diego Maradona", "Thierry Henry" },
        //        CorrectAnswer = "Pele"

        //    };
        //    Questions q5 = new Questions
        //    {
        //        Statement = "Vilket år hölls det första officiella fotbolls-VM?",
        //        Options = new List<string> { "1928", "1930", "1934", "1940" },
        //        CorrectAnswer = "1930"

        //    };
        //    Questions q6 = new Questions
        //    {
        //        Statement = "Vilken position spelar en målvakt i fotboll?",
        //        Options = new List<string> { "Anfallare", "Mittfältare", "Försvarare", "Målvakt" },
        //        CorrectAnswer = "Målvakt"

        //    };
        //    Questions q7 = new Questions
        //    {
        //        Statement = "Vilket lag har flest vinster i Premier League-historien?",
        //        Options = new List<string> { "Manchester United", "Liverpool", "Chelsea", "Arsenal" },
        //        CorrectAnswer = "Manchester United"

        //    };
        //    Questions q8 = new Questions
        //    {
        //        Statement = "Vilken fotbollsklubb har 'Galácticos' som smeknamn?",
        //        Options = new List<string> { "Real Madrid", "Barcelona", "AC Milan", "Bayern München" },
        //        CorrectAnswer = "Real Madrid"

        //    };
        //    Questions q9 = new Questions
        //    {
        //        Statement = "Vem är tränare för Liverpool FC i skrivande stund?",
        //        Options = new List<string> { "Pep Guardiola", "Jürgen Klopp", "Zinedine Zidane", "Carlo Ancelotti" },
        //        CorrectAnswer = "Jürgen Klopp"

        //    };
        //    Questions q10 = new Questions
        //    {
        //        Statement = "Vem är känd för att ha gjort 'Handen Guds' mål under VM 1986?",
        //        Options = new List<string> { "Ronaldo", "Diego Maradona", "Pelé", "Zinedine Zidane" },
        //        CorrectAnswer = "Diego Maradona"

        //    };

        //}
    }
}
