using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VikingNotes.Models;

namespace VikingNotes.Repositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers(string userId);

    }
}