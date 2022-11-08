using server.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.DAL.Repository
{
    public class UserRepository :IUserRepository
    {
        private DataDbContext _datacontext;
        public UserRepository(DataDbContext dataContext)
        {
            _datacontext = dataContext;
        }
        public IEnumerable<User>Get()
        {
            return _datacontext.Users;
        }
        public User Get(int Id)
        {
            return _datacontext.Users.Find(Id);
        }
        public void Create(User user)
        {
            _datacontext.Users.Add(user);
            _datacontext.SaveChanges();
        }
        public void Update(User updateduser)
        {
            User currentUser = Get(updateduser.Id);
            currentUser.Id = updateduser.Id;
            currentUser.Name = updateduser.Name;
            currentUser.Password = updateduser.Password;
            _datacontext.Users.Update(currentUser);
            _datacontext.SaveChanges();
        }
        public User Delete(int Id)
        {
            User user = Get(Id);
            if (user != null)
            {
                _datacontext.Users.Remove(user);
                _datacontext.SaveChanges();
            }
            return user;
        }

    }
}
