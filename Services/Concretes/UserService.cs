﻿using DataAccess.Entities;
using DTOs;
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
        public UserDTO Login(UserDTO dto)
        {
            return default(UserDTO);
        }
    }
}