using server.DAL.Models;
using server.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DAL.Repository
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private DataDbContext _dataContext;
        public QuestionnaireRepository(DataDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Questionnaire> Get()
        {
            return _dataContext.Questionnaires; 
        }
        public Questionnaire Get(int Id)
        {
            return _dataContext.Questionnaires.Find(Id);
        }
        public void Create(Questionnaire questionnaire)
        {
            _dataContext.Questionnaires.Add(questionnaire);
            _dataContext.SaveChanges();
        }
        public void Update(Questionnaire updatedQuestionnaire)
        {
            Questionnaire currentQuestionnaire = Get(updatedQuestionnaire.Id);
            currentQuestionnaire.Id = updatedQuestionnaire.Id;
            currentQuestionnaire.Description = updatedQuestionnaire.Description;
            currentQuestionnaire.Title = updatedQuestionnaire.Title;
            _dataContext.Questionnaires.Update(currentQuestionnaire);
            _dataContext.SaveChanges();
        }
        public Questionnaire Delete(int Id)
        {
            Questionnaire questionnaire = Get(Id);
            if(questionnaire != null)
            {
                _dataContext.Questionnaires.Remove(questionnaire);
                _dataContext.SaveChanges();
            }
            return questionnaire;
        }
    }
}
