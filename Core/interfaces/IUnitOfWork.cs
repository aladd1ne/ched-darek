using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity :
         BaseEntity;
        Task<int> Complete();
    } 
}