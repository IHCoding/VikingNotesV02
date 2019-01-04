using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using VikingNotes.Models;
using VikingNotes.Repositories;

namespace VikingNotes.Controllers.API
{
    // step 41c:
    [Authorize]
    public class QuizsController : ApiController
    {
        private ApplicationDbContext _context; // getting the context from the database

        private readonly IUnitOfWork _unitOfWork;

        public QuizsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public QuizsController() // initializing the constructor
        //{
        //    _context = new ApplicationDbContext();
        //}

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var quiz = _unitOfWork.Quizzes.GetQuiz(id);

            // when unit testing this line will faill as the quiz might be null. Usefullness of testing to catch this bug.
            if (quiz == null || quiz.Cancel)
                return NotFound();

            if (quiz.AuthorId != userId)
                return Unauthorized();

            quiz.Cancel = true;

            _unitOfWork.Complete();


            //// getting the quiz related to only the creator user.
            //var quiz = _context.Guizzes.Single(m => m.Id == id && m.AuthorId == userId); 
            //quiz.Cancel = true; // call cancel
            //_context.SaveChanges(); // save to the database

            return Ok();
        }
    }
}
