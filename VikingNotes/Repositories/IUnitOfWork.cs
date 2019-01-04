using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VikingNotes.Repositories;

namespace VikingNotes.Repositories
{
    public interface IUnitOfWork
    {
        IQuizRepository Quizzes { get; }

        IGenreRepository Genres { get; }

        IApplicationUserRepository Users { get; }

        IRatingRepository Ratings { get; }

        void Complete();

    }
}