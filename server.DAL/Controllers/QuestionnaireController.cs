using Microsoft.AspNetCore.Mvc;
using server.DAL.Models;
using server.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DAL.Controllers
{
    [Route("api/[controller]")]
    public class QuestionnaireController : ControllerBase 
    {
        IQuestionnaireRepository QuestionnaireRepository;
        public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
        {
            QuestionnaireRepository = questionnaireRepository;
        }
        [HttpGet(Name = "GetAllQuestionnaire")]
        public IEnumerable<Questionnaire> Get()
        {
            return QuestionnaireRepository.Get();
        }
        [HttpGet("{Id}", Name = "GetQuestionnaire")]
        public IActionResult Get(int Id)
        {
            Questionnaire questionnaire = QuestionnaireRepository.Get(Id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            return new ObjectResult(questionnaire);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Questionnaire questionnaire)
        {
            if (questionnaire == null)
            {
                return BadRequest();
            }
            QuestionnaireRepository.Create(questionnaire);
            return CreatedAtRoute("GetQuestionnaire", new {Id = questionnaire.Id}, questionnaire);
        }
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody] Questionnaire updatedQuestionnaire)
        {
            if (updatedQuestionnaire == null || updatedQuestionnaire.Id != Id)
            {
                return BadRequest();
            }
            var questionnaire = QuestionnaireRepository.Get(Id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            QuestionnaireRepository.Update(updatedQuestionnaire);
            return RedirectToRoute("GetAllQuestionnaire");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var deletedQuestionnaire = QuestionnaireRepository.Delete(Id);
            if (deletedQuestionnaire == null)
            {
                return BadRequest();
            }
            return new ObjectResult(deletedQuestionnaire);
        }
    }
}








