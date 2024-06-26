﻿using Deltapply.Models.Nihongo.Kanjis;

namespace Deltapply.Repositories.Nihongo.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> Exists(string property, object value, int? parentId);
        Task<List<TEntity>> GetAll(int? id);
        Task<TEntity> GetById(int id);
        Task<TEntity> Post(TEntity entity);
        Task<TEntity> Put(TEntity entity);
        Task Delete(TEntity entity);
    }
}
