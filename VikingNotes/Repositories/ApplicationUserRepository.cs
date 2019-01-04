using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VikingNotes.Models;

namespace VikingNotes.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetUsers(string userId)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<ApplicationUser> GetUsers(string userId)
        //{
        //    //return _context.Guizzes
        //    //    .Where(f => f.AuthorId == userId)
        //    //    .Select(f => f.Title)
        //    //    .ToList();
        //}
    }
}