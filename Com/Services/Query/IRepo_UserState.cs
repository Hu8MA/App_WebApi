
using Com.Core.Entities;
using Com.Core.EntitiesException;
using Com.Core.Reposetory;

namespace Com.Services.Query
{
    public interface IRepo_UserState : IReposetory<UserState>
    {
    }

    public class Repo_UserState : IRepo_UserState
    {
        private readonly IReposetory<UserState> _reposetory;
        public Repo_UserState(IReposetory<UserState> reposetory)
        {
            _reposetory = reposetory;
        }
        public async Task<bool> Add(UserState obj)
        {
            if (obj == null)
            {
                return false;
            }

            bool x = await _reposetory.Add(obj);
             
            return x;

        }

        public async Task<UserState> Get(int id)
        {
            UserState x = await _reposetory.Get(id);
            
            return x;
        }

        public async Task<IEnumerable<UserState>> List()
        {
            var x = await _reposetory.List();
            return x;
        }

        public Task<IEnumerable<UserState>> ListWithDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int id)
        {
            var result = await _reposetory.Remove(id);
            return result;
           
        }

        public async Task<bool> Update(UserState obj)
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
