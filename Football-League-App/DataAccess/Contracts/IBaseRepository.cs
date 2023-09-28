using DataStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IBaseRepository
    {
        IQueryable<T> GetAll<T>() where T : BaseEntity;

        T GetByID<T>(int id) where T : BaseEntity;

        int Create<T>(T model) where T : BaseEntity;

        void Update<T>(T model) where T : BaseEntity;

        void Delete<T>(T model) where T : BaseEntity;
    }
}
