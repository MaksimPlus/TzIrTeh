using server.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DAL.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(int id);
        void Create(User user);
        void Update(User user);
        User Delete(int id);
    }
}
