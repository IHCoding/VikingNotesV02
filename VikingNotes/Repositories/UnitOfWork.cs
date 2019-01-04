using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VikingNotes.Models;

namespace VikingNotes.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IQuizRepository Quizzes{ get; private set; }

        public IGenreRepository Genres { get; private set; }

        public IApplicationUserRepository Users { get; private set; }

        public IRatingRepository Ratings { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Quizzes = new QuizRepository(context);
            Genres = new GenreRepository(context);
            Users = new ApplicationUserRepository(context);
            Ratings = new RatingRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}