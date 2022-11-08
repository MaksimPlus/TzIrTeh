using server.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DAL.Repository.Interface
{
    public interface IQuestionnaireRepository
    {
        IEnumerable<Questionnaire> Get();
        Questionnaire Get(int id);
        void Create(Questionnaire questionnaire);
        void Update(Questionnaire questionnaire);
        Questionnaire Delete(int id);
    }
}
