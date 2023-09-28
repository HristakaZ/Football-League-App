using DataAccess.Contracts;
using DataStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public IQueryable<T> GetAll<T>() where T : BaseEntity
        {
            return _applicationDbContext.Set<T>();
        }

        public T GetByID<T>(int id) where T : BaseEntity
        {
            return _applicationDbContext.Set<T>().FirstOrDefault(x => x.ID == id);
        }

        public int Create<T>(T model) where T : BaseEntity
        {
            _applicationDbContext.Set<T>().Add(model);
            _applicationDbContext.SaveChanges();

            return model.ID;
        }

        public void Update<T>(T model) where T : BaseEntity
        {
            _applicationDbContext.Update<T>(model);
            _applicationDbContext.SaveChanges();
        }

        public void Delete<T>(T model) where T : BaseEntity
        {
            _applicationDbContext.Remove<T>(model);
            _applicationDbContext.SaveChanges();
        }
    }
}
