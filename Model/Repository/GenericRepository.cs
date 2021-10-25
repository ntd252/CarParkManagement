﻿using Microsoft.EntityFrameworkCore;
using Model.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Properties
        private readonly CarParkDbContext _context;
        #endregion Properties

        #region Constructor
        public GenericRepository(CarParkDbContext context)
        {
            _context = context;
        }
        #endregion Constructor

        #region Public Methods
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        #endregion Public Methods
    }
}
