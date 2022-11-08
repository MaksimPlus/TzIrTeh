using server.DAL.Models;
using server.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.DAL.Controllers
{
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository UserRepository;
        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        [HttpGet(Name = "GetAllUser")]
        public IEnumerable<User> Get()
        {
            return UserRepository.Get();
        }
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int Id)
        {
            User user = UserRepository.Get(Id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            UserRepository.Create(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
        [HttpPut("{Id}")]
        public IActionResult Update (int Id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || updatedUser.Id != Id)
            {
                return BadRequest();
            }
            var user = UserRepository.Get(Id);  
            if (user == null)
            {
                return NotFound();
            }
            UserRepository.Update(updatedUser);
            return RedirectToRoute("GetAllUser");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var deletedUser = UserRepository.Get(Id);
            if (deletedUser == null)
            {
                return BadRequest();
            }
            return new ObjectResult(deletedUser);   
        }
    }
}
