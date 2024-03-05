
using Com.Core.EntitiesException;
using Com.Core.Reposetory;
using Com.Data;
using Microsoft.EntityFrameworkCore;

namespace Com.Services.GlobalRepo
{
    public class Repository<T>:IReposetory<T> where T : class
    {

        public readonly MyAppDbContext _context;
        public readonly DbSet<T> _dbset;

        public Repository(MyAppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }


        public async Task<IEnumerable<T>> List()
        {
            try
            {
                var items = await _dbset.AsNoTracking().ToListAsync();
                if (items is not null)
                {
                    return items;
                }
                return Enumerable.Empty<T>();
            }
            catch
            {
                throw new BadRequestException("the error happend when make list from DB");

            }
        }

        public async Task<bool> Add(T obj)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _dbset.Add(obj);
                    if (await _context.SaveChangesAsync() >= 1)
                    {
                        transaction.Commit();
                        return true;

                    }

                    return false;

                }
                catch
                {
                    transaction.Rollback();
                    throw new BadRequestException("the error happend when make Add from DB");

                }
            }
        }

        public async Task<T> Get(int id)
        {
            try
            {
                var x = await _dbset.FindAsync(id);
                return (x != null) ? x : null;
            }
            catch
            {
                throw new BadRequestException("the error happend when make get from DB");

            }
        }

        public async Task<bool> Remove(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var entityToRemove = await _dbset.FindAsync(id);
                    if (entityToRemove != null)
                    {
                        _dbset.Remove(entityToRemove);
                        if (await _context.SaveChangesAsync() >= 1)
                        {
                            transaction.Commit();
                            return true;

                        }
                        return false;
                    }
                    return false;
                }
                catch
                {
                    transaction.Rollback();
                    throw new BadRequestException("the error happend when make Delete from DB");


                }
            }
        }

        public async Task<bool> Update(T obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (obj != null)
                    {
                        _dbset.Update(obj);
                        if (await _context.SaveChangesAsync() >= 1)
                        {
                            transaction.Commit();
                            return true;

                        }
                        return false;
                    }

                    return false;
                }
                catch
                {
                    transaction.Rollback();
                    throw new BadRequestException("the error happend when make Updata from DB");
                }

            }

        }

        public Task<IEnumerable<T>> ListWithDetails()
        {
            throw new NotImplementedException();
        }
    }
}
