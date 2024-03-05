

using Com.Core.Entities;
using Com.Core.Reposetory;
using Com.Data;
using Microsoft.EntityFrameworkCore;

namespace Com.Services.Query
{
    public interface IRepo_UserInfo : IReposetory<UserInfo>
    {
    }


    public class Repo_UserInfo : IRepo_UserInfo
    {
        private readonly IReposetory<UserInfo> _reposetory;
        public readonly MyAppDbContext _context;
   
        
        public Repo_UserInfo(IReposetory<UserInfo> reposetory, MyAppDbContext  context)
        {
            _reposetory = reposetory;
            _context = context;

        }
        public async Task<bool> Add(UserInfo obj)
        {
            if (obj == null)
            {
                return false;
            }

            bool x = await _reposetory.Add(obj);

            return x;

        }

        public async Task<UserInfo> Get(int id)
        {
            UserInfo x = await _reposetory.Get(id);

            return x;
        }

        public async Task<IEnumerable<UserInfo>> List()
        {
            var x = await _reposetory.List();
            return x;
        }

        public async Task<IEnumerable<UserInfo>> ListWithDetails()
        {
            var users = await _context.UserInfos
                               .Include(x => x.UserState)
                               .AsNoTracking().ToListAsync();

            return users;
        }

        public async Task<bool> Remove(int id)
        {
            var result = await _reposetory.Remove(id);
            return result;

        }

        public async Task<bool> Update(UserInfo obj)
        {
            if (obj == null)
            {
                return false;
            }

            bool x = await _reposetory.Update(obj);

            return x;
        }
    }
}
