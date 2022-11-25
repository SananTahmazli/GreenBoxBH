using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DTOs;
using Helpers;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concretes
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {
        public UserService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {
        }

        public override UserDTO Create(UserDTO dto)
        {
            var result = _dbContext.Users.Where(u => u.Username== dto.Username);

            if (result.Any())
            {
                throw new Exception("Username is already taken!");
            }
            dto.Salt = Encryption.GenerateSalt();
            dto.Hash = Encryption.GenerateHash(dto.Password, dto.Salt);
            return base.Create(dto);
        }

        public UserDTO Login(UserDTO dto)
        {
            var result = _dbContext.Users.Where(u => u.Username == dto.Username);

            if (result.Count() == 1)
            {
                var user = result.FirstOrDefault();
                var hash = Encryption.GenerateHash(dto.Password, user.Salt);

                if (hash == user.Hash)
                {
                    var model = _mapper.Map<User, UserDTO>(result.First());
                    return model;
                }
                else
                {
                    throw new Exception("Password is incorrect!");
                }
            }
            else
            {
                throw new Exception("Username is not found!");
            }
        }
    }
}