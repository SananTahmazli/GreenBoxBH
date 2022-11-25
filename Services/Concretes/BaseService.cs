using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concretes
{
    public class BaseService<TRequestDTO, TEntity, TResponseDTO>
        : IBaseService<TRequestDTO, TEntity, TResponseDTO> where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TResponseDTO> GetAll()
        {
            var entityList = _dbSet.ToList();
            var responseDTO = _mapper.Map<IEnumerable<TResponseDTO>>(entityList);
            return responseDTO;
        }

        public virtual TResponseDTO Get(int id)
        {
            var entity = _dbSet.Find(id);
            var responseDTO = _mapper.Map<TResponseDTO>(entity);
            return responseDTO;
        }

        public virtual TResponseDTO Create(TRequestDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedTime = DateTime.UtcNow;
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            var responseDTO = _mapper.Map<TResponseDTO>(entity);
            return responseDTO;
        }

        public virtual void Update(TRequestDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.UpdatedTime = DateTime.UtcNow;
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public virtual int Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
    }
}