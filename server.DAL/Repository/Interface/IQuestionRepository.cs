using server.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DAL.Repository.Interface
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> Get();
        Question Get(int id);
        void Create(Question question);
        void Update(Question question);
        Question Delete(int id);
    }
}
