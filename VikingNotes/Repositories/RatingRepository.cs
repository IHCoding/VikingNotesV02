using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VikingNotes.Models;

namespace VikingNotes.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IEnumerable<RatingRepository> GetRatingsFor(string quizId)
        //{
        //    //return _context.Ratings
        //    //.Where(r => r.Id == quizId)
        //    //.Select(r => r.Quiz.Author)
        //    //.ToList();           
        //}

        IEnumerable<Rating> IRatingRepository.GetRatingsFor(string quizId)
        {
            throw new NotImplementedException();
        }
    }
}