using Labb3_Databse_Blazor.Pages;
using MongoDB.Driver;

namespace Labb3_Databse_Blazor.Data
{
    public class MongoCRUD
    {

        private IMongoDatabase db;

        //public static List<Pages.Questions> questions { get; set; }
        //public static List<Quiz> quizzes { get; set; }

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);

        }
        //CRUD questions----------------------------------------
        public void AddQuestionDB(string table, Pages.Questions question)
        {
            var collection = db.GetCollection<Pages.Questions>(table);
            collection.InsertOne(question);
        }

        public List<Pages.Questions> ReadQuestionsDB(string table)
        {
            var collection = db.GetCollection<Pages.Questions>(table);
            return collection.Find(_ => true).ToList();
        }

        public Pages.Questions GetQuestionByIDDB(string table, Guid id)
        {
            var collection = db.GetCollection<Pages.Questions>(table);
            return collection.AsQueryable().ToList().Find(q => q.Id == id);
        }

        public void UpsertQuestionDB(string table, Questions question)
        {


            var collection = db.GetCollection<Pages.Questions>(table);
            var selectedQuestion = collection.AsQueryable().FirstOrDefault(q => q.Id == question.Id);

            if (selectedQuestion != null)
            {
                selectedQuestion.Statement = question.Statement;
                selectedQuestion.Options = question.Options;
                selectedQuestion.CorrectAnswer = question.CorrectAnswer;



                collection.ReplaceOne(q => q.Id == question.Id, question, new ReplaceOptions { IsUpsert = true });
            }
            else
            {

            }

            //collection.ReplaceOne(x => x.Id == question.Id, question, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteQuestionDB(string table, Pages.Questions question)
        {
            var collection = db.GetCollection<Pages.Questions>(table);
            collection.DeleteOne(q => q.Id == question.Id);
        }

        //Crud Quizes---------------------------------------------

        //public void AddQuiz(string table, Quiz quiz)
        //{
        //    var collection = db.GetCollection<Quiz>(table);
        //    collection.InsertOne(quiz);
        //}

        //public void ReadQuizes(string table, Quiz quiz)
        //{
        //    var collection = db.GetCollection<Quiz>(table);
        //    collection.Find(_ => true);
        //}

        //public void GetQuizById(string table, Guid id)
        //{
        //    var collection = db.GetCollection<Quiz>(table);
        //    collection.AsQueryable().ToList().Find(q => q.Id == id);
        //}

        //public void UpsertQuiz()
        //{

        //}

        //public void DeleteQuizById(string table, Guid id)
        //{
        //    var collection = db.GetCollection<Quiz>(table);
        //    collection.DeleteOne(q => q.Id == id);
        //}
    }
}

