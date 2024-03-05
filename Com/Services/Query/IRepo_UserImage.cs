
using Com.Core.Entities;
using Com.Core.Reposetory;
using Com.Core.ValueObject;
using Com.Services.File;
using Com.Services.GlobalRepo;

namespace Com.Services.Query
{
    public interface IRepo_UserImage:IReposetory<UserImage>
    {
        public Task<UserImage> GetImagesbyId(int id);
    }

    public class Repo_UserImage : IRepo_UserImage
    {

        private readonly IReposetory<UserImage> _reposetory;


        public Repo_UserImage(IReposetory<UserImage> reposetory )
        {
            _reposetory = reposetory;
            
        }
         
        public async Task<bool> Add(UserImage obj)
        {
            if (obj == null)
            {
                return false;
            }


             bool x = await _reposetory.Add(obj);

             return x;

        }

        public async Task<UserImage> Get(int id)
        {
            UserImage x = await _reposetory.Get(id);

            return x;
        }
       
        public async Task<UserImage> GetImagesbyId(int id)
        {
            var List = await _reposetory.List();

            return List.FirstOrDefault(x=>x.IdUser==id);
        }

        public async Task<IEnumerable<UserImage>> List()
        {
            var x = await _reposetory.List();
            return x;
        }

        public Task<IEnumerable<UserImage>> ListWithDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int id)
        {
            var result = await _reposetory.Remove(id);
            return result;

        }

        public async Task<bool> Update(UserImage obj)
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
