using Microsoft.AspNetCore.Mvc;
using server.DAL.Models;
using server.DAL.Repository;
using server.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DAL.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        IQuestionRepository QuestionRepository;
        public QuestionController(IQuestionRepository questionRepository)
        {
            QuestionRepository = questionRepository;
        }
        [HttpGet(Name = "GetAllQuestion")]
        public IEnumerable<Question> Get()
        {
            return QuestionRepository.Get();
        }
        [HttpGet("{Id}", Name = "GetQuestion")]
        public IActionResult Get(int Id)
        {
            Question question = QuestionRepository.Get(Id);
            if (question == null)
            {
                return NotFound();
            }
            return new ObjectResult(question);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest();
            }
            QuestionRepository.Create(question);
            return CreatedAtRoute("GetQuestion", new { Id = question.Id }, question);
        }
        [HttpPut("Id")]
        public IActionResult Update(int Id, [FromBody] Question updatedQuestion)
        {
            if (updatedQuestion == null || updatedQuestion.Id != Id)
            {
                return BadRequest();
            } 
            var question = QuestionRepository.Get(Id);
            if (question == null)
            {
                return NotFound();
            }
            QuestionRepository.Update(updatedQuestion);
            return RedirectToRoute("GetAllQuestion");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var deletedQuestion = QuestionRepository.Delete(Id);
            if (deletedQuestion == null)
            {
                return BadRequest();
            }
            return new ObjectResult(deletedQuestion);
        }
    }
}
