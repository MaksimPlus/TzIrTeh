using server.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.DAL.Models;    

namespace server.DAL.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private DataDbContext _dataContext;
        public QuestionRepository(DataDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Question> Get()
        {
            return _dataContext.Questions;
        }
        public Question Get(int Id)
        {
            return _dataContext.Questions.Find(Id);
        }
        public void Create(Question question)
        {
            _dataContext.Questions.Add(question);
            _dataContext.SaveChanges();
        }
        public void Update(Question updatedQuestion)
        {
            Question currentQuestion = Get(updatedQuestion.Id);
            currentQuestion.Id = updatedQuestion.Id;
            currentQuestion.Questionnaire = updatedQuestion.Questionnaire;
            currentQuestion.QuestionText = updatedQuestion.QuestionText;
            currentQuestion.QuestionnaireId = updatedQuestion.QuestionnaireId;
            currentQuestion.AnswerA = updatedQuestion.AnswerA;
            currentQuestion.AnswerB = updatedQuestion.AnswerB;
            currentQuestion.AnswerC = updatedQuestion.AnswerC;
            currentQuestion.AnswerD = updatedQuestion.AnswerD;
            _dataContext.Questions.Update(currentQuestion);
            _dataContext.SaveChanges();
        }
        public Question Delete(int Id)
        {
            Question question = Get(Id);
            if(question != null)
            {
                _dataContext.Questions.Remove(question);
                _dataContext.SaveChanges();
            }
            return question;
        }
    }
}
