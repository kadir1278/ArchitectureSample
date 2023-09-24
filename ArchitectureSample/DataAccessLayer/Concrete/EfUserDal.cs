﻿using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Dto;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfUserDal : EfEntityRepository<User, UserDto, SystemContext>, IUserDal
    {
        public EfUserDal(SystemContext context) : base(context)
        {

        }
    }
}
