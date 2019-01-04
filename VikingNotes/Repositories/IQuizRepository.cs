using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VikingNotes.Models;

namespace VikingNotes.Repositories
{
    public interface IQuizRepository
    {
        Quiz GetQuiz(int quizId);

        IEnumerable<Quiz> GetQuizzesByUser(string userId);

        void Add(Quiz quiz);

        IEnumerable<Quiz> GetRecentQuizzes(string searchValue = null);

    }
}