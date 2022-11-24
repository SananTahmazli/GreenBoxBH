using DataAccess.Entities;
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
        public virtual IEnumerable<TResponseDTO> GetAll()
        {
            return new List<TResponseDTO>();
        }

        public virtual TResponseDTO Get(int id)
        {
            return default(TResponseDTO);
        }

        public virtual TResponseDTO Create(TRequestDTO dto)
        {
            return default(TResponseDTO);
        }

        public virtual void Update(TRequestDTO dto)
        {
        }

        public virtual int Delete(int id)
        {
            return 0;
        }
    }
}