using System;
using System.Collections.Generic;
using System.Linq;
using VikingNotes.Models;
using System.Data.Entity;
using VikingNotes.Repositories;

namespace VikingNotes.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Quiz GetQuiz(int quizId)
        {
            return _context.Guizzes
                    .Include(g => g.Author)
                    .Include(g => g.Genre)
                    .SingleOrDefault(g => g.Id == quizId);
        }

        public IEnumerable<Quiz> GetQuizzesByUser(string userId)
        {
            return _context.Guizzes
                .Where(g =>
                    g.AuthorId == userId &&
                    g.Creation > DateTime.Now &&
                    !g.Cancel)
                .Include(g => g.Genre)
                .ToList();
        }

       public void Add(Quiz quiz)
        {
            _context.Guizzes.Add(quiz);
        }

        public IEnumerable<Quiz> GetRecentQuizzes(string searchValue = null)
        {
            var recentQuizzes = _context.Guizzes
                .Include(g => g.Author)
                .Include(g => g.Genre)
                .Where(g => g.Creation > DateTime.Now && !g.Cancel);

            if (!String.IsNullOrWhiteSpace(searchValue))
            {
                recentQuizzes = recentQuizzes
                    .Where(g =>
                            g.Author.Name.Contains(searchValue) ||
                            g.Genre.Name.Contains(searchValue) ||
                            g.Title.Contains(searchValue));
            }

            return recentQuizzes.ToList();
        }

    }
}